using ClassroomsInfo.Data;
using ClassroomsInfo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClassroomsInfo.Web.tests_navigation.Controllers
{
  public class NavigationController : Controller
  {

    public IEnumerable<Classroom> classrooms { get; set; }

    public NavigationController()
    {
      classrooms = StaticDataContext.classrooms;
    }

    public const string ALL_CATEGORIES = "...";

    [ChildActionOnly]
    public PartialViewResult ClassroomsByNamesMenu(string categoryName = ALL_CATEGORIES)
    {
      ViewBag.SelectedCategoryName = categoryName;
      List<string> categoryNames = new List<string>();

      categoryNames.Add(ALL_CATEGORIES);
      categoryNames.AddRange(classrooms.Select(e => e.ProfessorName).Distinct().OrderBy(e => e));

      return PartialView(categoryNames);
    }
  }
}



