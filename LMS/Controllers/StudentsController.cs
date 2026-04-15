using StudentApp.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View("JQuery");
        }

        public ActionResult JQuery()
        {
            return View();
        }

        public JsonResult GetStudents()
        {
            try
            {
                var data = db.Students
                    .ToList()
                    .Select(s => new { s.Id, s.Name, s.Email, s.Age });
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = ex.GetBaseException().Message;
#if !DEBUG
                msg = "Database error. Check Web.config connection string, SQL Server is running, and the Students table matches the model (e.g. Password column).";
#endif
                return Json(new { __error = msg }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddStudent(Student s)
        {
            if (string.IsNullOrWhiteSpace(s.Password))
            {
                return Json(false);
            }

            db.Students.Add(s);
            db.SaveChanges();
            return Json(true);
        }

        public JsonResult GetStudentById(int id)
        {
            var s = db.Students.Find(id);
            if (s == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(new { s.Id, s.Name, s.Email, s.Age }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateStudent(Student s)
        {
            var existing = db.Students.Find(s.Id);
            if (existing == null)
            {
                return Json(false);
            }

            existing.Name = s.Name;
            existing.Email = s.Email;
            existing.Age = s.Age;
            if (!string.IsNullOrWhiteSpace(s.Password))
            {
                existing.Password = s.Password;
            }

            db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            var data = db.Students.Find(id);
            if (data == null)
            {
                return Json(false);
            }

            db.Students.Remove(data);
            db.SaveChanges();
            return Json(true);
        }
    }
}
