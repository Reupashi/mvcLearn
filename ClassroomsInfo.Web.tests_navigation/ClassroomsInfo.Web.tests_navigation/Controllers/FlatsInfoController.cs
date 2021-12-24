using ClassroomsInfo.Data;
using ClassroomsInfo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClassroomsInfo.Web.tests_navigation.Controllers
{
  public class FlatsInfoController : Controller
  {
    public IEnumerable<Classroom> Objects { get; set; }

    public FlatsInfoController()
    {
      Objects = StaticDataContext.classrooms;
    }
    // GET: ClassroomsInfo
    public ActionResult Index()
    {
      return View();
    }

    public ViewResult ClassroomsByNamesInfo(string categoryName = NavigationController.ALL_CATEGORIES)
    {
      IEnumerable<Classroom> models = Objects.OrderBy(e => e.Name);

      if (!string.IsNullOrEmpty(categoryName) && categoryName != NavigationController.ALL_CATEGORIES)
      {
        models = models.Where(element => element.ProfessorName == categoryName);
      }

      ViewBag.SelectedCategryName = categoryName;

      return View(models);
    }
  }
}