using StudentApp.Models;
using System.Web.Mvc;
using System.Linq;

public class StudentsController : Controller
{
    private AppDbContext db = new AppDbContext();

    // Default route for /Students -> show jQuery CRUD view
    public ActionResult Index()
    {
        return View("JQuery");
    }

    // Simple jQuery-based CRUD page
    public ActionResult JQuery()
    {
        return View();
    }

    // GET ALL
    public JsonResult GetStudents()
    {
        var data = db.Students.ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
    }

    // ADD
    [HttpPost]
    public JsonResult AddStudent(Student s)
    {
        db.Students.Add(s);
        db.SaveChanges();
        return Json(true);
    }

    // GET BY ID
    public JsonResult GetStudentById(int id)
    {
        var data = db.Students.Find(id);
        return Json(data, JsonRequestBehavior.AllowGet);
    }

    // UPDATE
    [HttpPost]
    public JsonResult UpdateStudent(Student s)
    {
        db.Entry(s).State = System.Data.Entity.EntityState.Modified;
        db.SaveChanges();
        return Json(true);
    }

    // DELETE
    [HttpPost]
    public JsonResult DeleteStudent(int id)
    {
        var data = db.Students.Find(id);
        db.Students.Remove(data);
        db.SaveChanges();
        return Json(true);
    }
}