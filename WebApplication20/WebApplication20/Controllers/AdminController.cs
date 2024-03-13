using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private FlowerContext _context;
        public AdminController(FlowerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            var b = _context.Mehsuls.Include(x => x.Photos).ToList();
            return View(b);
        }

        public IActionResult AdminData(string search)
        {
            var d = _context.Mehsuls.Include(x => x.Photos).Include(y=>y.MehsulCategory).Where(x => x.MehsulAd.Contains(search)).ToList();
            return Ok(d);
        }

        public IActionResult YeniUser()
        {
            ViewBag.Gender = new SelectList(_context.Genders.ToList(), "GenderId", "GenderName");
            ViewBag.Telefon = new SelectList(_context.Telefons.ToList(), "TelefonId", "TelefonHead");
            var v = _context.Users.ToList();
            return View(v);
        }

        public IActionResult YeniMehsul()
        {
            Random random = new Random();
            var r = random.Next(100000000, 900000000);
            TempData["Token"] = r.ToString();

            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.SubCategory = new SelectList(_context.SubCategories.ToList(), "SubCategoryId", "SubCategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult YeniMehsul(Mehsul mehsul, List<IFormFile> Sekil, string UserToken)
        {
            if (UserToken == TempData["PostToken"].ToString())
            {
            _context.Mehsuls.Add(mehsul);
            _context.SaveChanges();              
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View();
            }

            mehsul.MehsulLove = "Beyenilmeyib";
            mehsul.MehsulStatus = "DeActive";

            if (Sekil != null)
            {
                foreach (FormFile s in Sekil)
                {
                    string filename = Path.GetRandomFileName() + Path.GetExtension(s.FileName);
                    using (FileStream stream = new FileStream("wwwroot/img/" + filename, FileMode.Create))
                    {
                        s.CopyTo(stream);
                    };
                    Photo photo = new Photo();
                    photo.PhotoUrl = filename;
                    photo.PhotoMehsulId = mehsul.MehsulId;
                    _context.Photos.Add(photo);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult Silmek(int id)
        {
            var e = _context.Mehsuls.SingleOrDefault(x => x.MehsulId == id);
            var list = _context.Photos.Where(x => x.PhotoMehsulId == id).ToList();
            _context.Photos.RemoveRange(list);

            _context.Mehsuls.Remove(e);
            _context.SaveChanges();
            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult YeniCategory()
        {
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.SubCategory = _context.SubCategories.ToList();
            return View();
        }

        public IActionResult Active(int id)
        {
            if (_context.Mehsuls.SingleOrDefault(x => x.MehsulId == id).MehsulStatus == "Active")
            {
                _context.Mehsuls.SingleOrDefault(x => x.MehsulId == id).MehsulStatus = "DeActive";
            }
            else
            {
                _context.Mehsuls.SingleOrDefault(x => x.MehsulId == id).MehsulStatus = "Active";
            }
            _context.SaveChanges();
            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult Duzelis(int id)
        {
            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            var d = _context.Mehsuls.Include(x => x.Photos).SingleOrDefault(x => x.MehsulId == id);
            return View(d);
        }

        [HttpPost]
        public IActionResult Duzelis(int id, Mehsul mehsul, IFormFile[] Sekil)
        {
            var KohneMehsul = _context.Mehsuls.Include(x => x.Photos).SingleOrDefault(x => x.MehsulId == id);
            KohneMehsul.MehsulAd = mehsul.MehsulAd;
            KohneMehsul.MehsulunKodu = mehsul.MehsulunKodu;
            KohneMehsul.MehsulQiymeti = mehsul.MehsulQiymeti;
            KohneMehsul.MehsulSekil = mehsul.MehsulSekil;
            KohneMehsul.MehsulCategoryId = mehsul.MehsulCategoryId;
            foreach (FormFile s in Sekil)
            {
                string filename = Path.GetRandomFileName() + Path.GetExtension(s.FileName);
                using (FileStream stream = new FileStream("wwwroot/img/" + filename, FileMode.Create))
                {
                    s.CopyTo(stream);
                };
                Photo photo = new Photo();
                photo.PhotoUrl = filename;
                photo.PhotoMehsulId = id;
                _context.Photos.Add(photo);
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return RedirectToAction("AdminPanel", "Admin");
        }

    }
}
