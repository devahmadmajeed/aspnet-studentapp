using System.Web.Mvc;

namespace LMS.Controllers
{
    [Authorize]
    public class StudentPortalController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Title = "My courses";
            return View();
        }

        public ActionResult Assignments()
        {
            ViewBag.Title = "Assignments";
            return View();
        }

        public ActionResult Grades()
        {
            ViewBag.Title = "Grades";
            return View();
        }

        public ActionResult Schedule()
        {
            ViewBag.Title = "Schedule";
            return View();
        }

        public ActionResult Announcements()
        {
            ViewBag.Title = "Announcements";
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Title = "Profile";
            return View();
        }
    }
}
