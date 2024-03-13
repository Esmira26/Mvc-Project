using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApplication20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication20.Controllers
{
    public class UserController : Controller
    {
        public readonly FlowerContext _sql;
        public UserController(FlowerContext sql)
        {
            _sql = sql;
        }

		public IActionResult Login()
        {
			ViewBag.Telefons = new SelectList(_sql.Telefons.ToList(), "TelefonId", "TelefonHead");
			return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var user = _sql.Users.Include(x=>x.UserStatus).SingleOrDefault(x =>x.UserPassword == u.UserPassword && (x.UserEmail == u.UserEmail  || x.UserPhone == u.UserPhone));
            if (user != null)
            {
                List<Claim> claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim(ClaimTypes.Sid,user.UserId.ToString()),
                    new Claim(ClaimTypes.Role,user.UserStatus.StatusName),
                };
                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var prims = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prims, props).Wait();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Sign()
        {
            ViewBag.Telefons = new SelectList(_sql.Telefons.ToList(), "TelefonId", "TelefonHead");
            ViewBag.Gender = new SelectList(_sql.Genders.ToList(), "GenderId", "GenderName");
			return View();
        }

        [HttpPost]
        public IActionResult Sign(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userRepate=_sql.Users.SingleOrDefault(x=>x.UserName==user.UserName);
            if (userRepate!=null)
            {
                ModelState.AddModelError("UserName", "bu adam qeydiyyatdan kecib");
            }
            var md5Pas = CreateMD5Hash(user.UserPassword);
            var b = _sql.Users.Where(x => x.UserPassword == md5Pas).ToList();
            var c= _sql.Users.Where(x=>x.UserName == user.UserName).ToList();

            if (b.Count != 0)
            {
                ModelState.AddModelError("UserPassword", "Boş ola bilməz!");
                return View();
            }else if (c.Count != 0)
            {
                
                ModelState.AddModelError("UserName", "Boş ola bilməz!");
                return View();

            }
            else
            {
                user.UserPassword = CreateMD5Hash(user.UserPassword);
                user.UserStatusId = 2;
                _sql.Users.Add(user);
                _sql.SaveChanges();
                return RedirectToAction("Login", "User");
            }
        }

        public static string CreateMD5Hash(string inputNew)
        {
            using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputNew);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        public IActionResult Cixis()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
