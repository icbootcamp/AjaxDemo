using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDemo.Models;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        SchoolEntities db = new SchoolEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetCourseList()
        {
            var model = db.Courses.ToList().
                Select(x => new CourseViewModel { Id = x.CourseID, Title = x.Title }).
                ToList();
            return View(model);
        }

        public ActionResult GetCourseById(int id)
        {
            var getCourse = db.Courses.Find(id);
            CourseViewModel model = new CourseViewModel()
            {
                Id = getCourse.CourseID,
                Title = getCourse.Title
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveData(CourseViewModel model)
        {
            return Json(new { success = true });
        }
    }
}