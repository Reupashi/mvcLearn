using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassroomsInfo.Data;
using ClassroomsInfo.Entities;

namespace ClassroomsInfo.Web.views_layout.Controllers
{
    public class NavigationController : Controller
    {
        public IEnumerable<Classroom> Classrooms { get; set; }
        public const string ALL_CATEGORIES = "...";
        public NavigationController()
        {
            Classrooms = StaticDataContext.classrooms;
        }

        // GET: Navigation
        //public ActionResult Index()
        //{
        //    return View();
        //}


    [ChildActionOnly] 
        public PartialViewResult ClassroomsByProfessorsNamesMenu(
                string categoryName = ALL_CATEGORIES)
        {
            ViewBag.SelectedCategoryName = categoryName;
            List<string> categoryNames = new List<string>();
            categoryNames.Add(ALL_CATEGORIES);
            categoryNames.AddRange(Classrooms
                    .Where(e => !string.IsNullOrEmpty(e.ProfessorName))
                    .Select(e => e.ProfessorName)
                    .Distinct().OrderBy(e => e));

            return PartialView(categoryNames);
        }
      
    }
}