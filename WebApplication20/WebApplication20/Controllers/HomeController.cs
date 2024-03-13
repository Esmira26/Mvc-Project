using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    public class HomeController : Controller
    {
        public readonly FlowerContext _sql;
        public HomeController(FlowerContext sql)
        {
            _sql = sql;
        }

        public class IndexModel
        {
            public Musteri Musteri { get; set; }
            public List<Sebet> Sebets  { get; set; }
            public List<Catdirilma> Catdirilmas  { get; set; }
        }

        public IActionResult Index()
        {
           var mehsullar=_sql.Mehsuls.Include(x => x.Photos).Take(8).ToList();
            return View(mehsullar);
        }
        [Authorize]
        public IActionResult Elaqe()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Elaqe(Elaqe elaqe)
        {
            _sql.Elaqes.Add(elaqe);
            _sql.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Melumat(int id)
        {
            var t = _sql.Mehsuls.Include(x=>x.Photos).SingleOrDefault(x => x.MehsulId == id);
            return View(t);
        }
        public IActionResult Mehsul()
		{

            ViewBag.PageCount = Math.Ceiling((decimal)_sql.Mehsuls.Count() / 9);

            ViewBag.Category = _sql.Categories.Include(x => x.SubCategories).ThenInclude(p=>p.Mehsuls).Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
                sub = x.SubCategories.Select(s=>new {
                    s.SubCategoryId,
                    s.SubCategoryName,
                    say=s.Mehsuls.Count
                })
            }).ToList();
            var mehsul=_sql.Mehsuls.Include(x=>x.Photos).Take(9).ToList();
            return View(mehsul);
        }
        public IActionResult Hediyyeler(int? id, int page=0)
        {
            ViewBag.PageCount = Math.Ceiling((decimal)_sql.Mehsuls.Where(x=>x.MehsulCategoryId==id).Count() / 4);
            ViewBag.Category = _sql.Categories.Include(x => x.SubCategories).Where(x => x.CategoryId == id).ToList();
            var e = _sql.Mehsuls.Where(x => x.MehsulCategoryId == id).Skip(page * 4).Take(4).ToList();

            return View(e);
        }
        public IActionResult MehsulData(int? id, int page = 0)
        {
			var mehsul=new List<Mehsul>();
            if (id != 0)
            {
                mehsul = _sql.Mehsuls.Where(x => x.MehsulCategoryId == id).Include(x => x.Photos).Skip(page * 9).Take(9).ToList();
            }
            else
            {
                mehsul = _sql.Mehsuls.Include(x => x.Photos).Skip(page * 9).Take(9).ToList();
            }
            //return Ok(_sql.Mehsuls.Where(x => x.MehsulCategoryId == id).Include(x => x.Photos).ToList());
            return Ok(mehsul);
        }
        public IActionResult MehsulSubCatData(int? id , int page = 0)
        {
            var mehsul = new List<Mehsul>();
            if (id != 0)
            {
                mehsul = _sql.Mehsuls.Where(x => x.MehsulSubCategoryId == id).Include(x => x.Photos).Skip(page * 9).Take(9).ToList();
            }
            else
            {
                mehsul = _sql.Mehsuls.Include(x => x.Photos).Skip(page * 9).Take(9).ToList();
            }
            //return Ok(_sql.Mehsuls.Where(x => x.MehsulCategoryId == id).Include(x => x.Photos).ToList());
            return Ok(mehsul);
        }

        public IActionResult HData(int? id)
        {
            return Ok(_sql.Mehsuls.Where(x => x.MehsulSubCategoryId == id).Include(x => x.Photos).ToList());
        }
        [Authorize]
        public IActionResult Remove(int id)
        {
            var f = _sql.Sebets.SingleOrDefault(x => x.SebetMehsulId == id);
            _sql.Sebets.Remove(f);
            _sql.SaveChanges();
            return RedirectToAction("Sebet", "Home");
        }

        [Authorize]
        public IActionResult Sebet()
        {
            var k = _sql.Sebets.Include(x => x.SebetMehsul).Where(x=>x.SebetUserId == int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).ToList();
            return View(k);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Sebet(int id)
        {
            Sebet a = _sql.Sebets.SingleOrDefault(x => x.SebetMehsulId == id);
            if (a == null)
            {
                Sebet b = new Sebet();
                b.SebetMehsulId = id;
                b.SebetMehsulCount = 1;
                b.SebetUserId = int.Parse(User.FindFirst(ClaimTypes.Sid).Value);
                _sql.Sebets.Add(b);
            }
            else
            {
                a.SebetMehsulCount++;
            }
            _sql.SaveChanges();
            return RedirectToAction("Sebet","Home");
        }
        [Authorize]
        public IActionResult Sifaris()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.Sebets = _sql.Sebets.Include(x=>x.SebetMehsul).ThenInclude(x=>x.Photos).Where(x=>x.SebetUserId==int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).ToList();           
            ViewBag.Catdirilma = new SelectList(_sql.Catdirilmas.ToList(),"CatdirilmaId", "CatdirilmaAd");
            return View(indexModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Sifaris(IndexModel m)
        {
            _sql.Musteris.Add(m.Musteri);
            _sql.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult plus(int id)
        {
            var t = _sql.Sebets.SingleOrDefault(x => x.SebetId == id);
            t.SebetMehsulCount++;
            _sql.Sebets.Count();
            _sql.SaveChanges();
            return RedirectToAction("Sebet","Home");
        }

        public IActionResult minus(int id)
        {
            var r = _sql.Sebets.SingleOrDefault(x => x.SebetId == id);
            if (r.SebetMehsulCount==1)
            {
                _sql.Sebets.Remove(r);
            }
            else
            {
                r.SebetMehsulCount--;
            }
            _sql.Sebets.Count();
            _sql.SaveChanges();
            return RedirectToAction("Sebet", "Home");
        }


        [Authorize]
        public IActionResult Love()
        {
            var k = _sql.Loves.Include(x => x.LoveMehsul).Include(x=>x.LoveMehsul.Photos).Where(x => x.LoveUserId == int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).ToList();

            return View(k);
        }
        [Authorize]
        public IActionResult LoveGet(int id)
        {
            Lofe a = _sql.Loves.SingleOrDefault(x => x.LoveMehsulId == id && x.LoveUserId == int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
            if (a == null)
            {
                Lofe b = new Lofe();
                 b.LoveMehsulId= id;
              
                b.LoveUserId = int.Parse(User.FindFirst(ClaimTypes.Sid).Value);
                _sql.Loves.Add(b);
            }
            else
            {
                _sql.Loves.Remove(a);
            }
           
            _sql.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult BizimleElaqe()
        {
            return View(_sql.Elaqes.ToList());
        }

        public IActionResult PostData(string q)
        {
            var cat = _sql.Categories.Where(x => x.CategoryName.ToLower().Contains(q.ToLower())).Take(4).ToList();
            var prp = _sql.Mehsuls.Include(x=>x.Photos).Where(x => x.MehsulAd.Contains(q)).Take(5).ToList();
            return Ok(new {cat,prp});
        }

        public IActionResult Haqqimizda()
        {
            return View();
        }

    }
}