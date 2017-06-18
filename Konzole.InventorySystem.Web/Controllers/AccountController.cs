using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Konzole.InventorySystem.Web.Models;

namespace Konzole.InventorySystem.Web.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }
        //
        // GET: /Account/Login
        //[AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

       // POST: /Account/Login
       [HttpPost]
       //[AllowAnonymous]
       //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //string strPass = KonzoleUtilities.KonzoleCryptor.Decrypt(_context.Users.Where(x => x.Password == model.Password).Select(x=>x.Password);
                User user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                string strPass = KonzoleUtilities.KonzoleCryptor.Decrypt(user.Password);
                if (user != null && strPass == model.Password)
                    return RedirectToLocal(returnUrl);
            }
            catch (Exception ex)
            {

                //throw;
            }
            TempData["InvalidAccount"] = "Invalid username or password.";
            return View();
        }

        //
        // GET: /Account/Register
        //[AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
     
    }
}