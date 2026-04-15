using LMS.Models;
using StudentApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "StudentPortal");
            }

            ViewBag.ReturnUrl = returnUrl ?? string.Empty;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl ?? string.Empty;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var student = db.Students.FirstOrDefault(
                s => s.Email == model.Email && (s.Password ?? string.Empty) == model.Password);

            if (student == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // Store the student email as the logged-in user name.
            FormsAuthentication.SetAuthCookie(student.Email, model.RememberMe);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "StudentPortal");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
