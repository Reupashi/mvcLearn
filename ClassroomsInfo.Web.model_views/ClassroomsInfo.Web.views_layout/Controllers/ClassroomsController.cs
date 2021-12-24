using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassroomsInfo.Data;
using ClassroomsInfo.Entities;
using ClassroomsInfo.Web.Models;



namespace ClassroomsInfo.Web.views_layout.Controllers
{
    public class ClassroomsController : Controller
    {
        public IEnumerable<Classroom> objects;
        public int ItemsPerPage { get; set; }
        private IEnumerable<ClassroomTableModel> tableModelObjects;
      
        public IEnumerable<Classroom> Objects
        {
            get { return objects; }
            set
            {
                objects = value;
                tableModelObjects = objects.Select(e => (ClassroomTableModel)e)
                    .OrderBy(e => e.Name);
            }
        }
        List<SelectListItem> CreateProfessorNameSelectList()
        {
            List<string> values = new List<string>();
            values.Add(ALL_VALUES);
            values.AddRange(Objects
                .Select(e => e.ProfessorName).Distinct());
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e
                });
            }
            return list;
        }
        public ClassroomsController()
        {
            Objects = StaticDataContext.classrooms;
            
        }
        // GET: Classrooms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Selection()
        {
            ViewBag.selProfessorName = CreateProfessorNameSelectList();
            return View(tableModelObjects);
        }
        public ViewResult ObjectsInfo()
        {
            return View(Objects);
        }
        const string ALL_VALUES = "...";
        public const string ALL_PAGE_LINK_NAME = "..";

        public PartialViewResult _SelectData(string selName, string selProfessorName,
                     double? areaFrom, double? areaTo, string selLetter)
        {
            var model = tableModelObjects;
            if (!string.IsNullOrWhiteSpace(selName))
                model = model.Where(e => e.Name.ToLower()
                    .StartsWith(selName.ToLower()));

            if (selProfessorName != null && selProfessorName != ALL_VALUES)
                model = model.Where(e => e.ProfessorName == selProfessorName);
            if (areaFrom.HasValue)
                model = model.Where(e => e.Area >= areaFrom.Value);
            if (areaTo.HasValue)
                model = model.Where(e => e.Area <= areaTo.Value);
            if (selLetter != null && selLetter != ALL_PAGE_LINK_NAME)
                model = model.Where(e => e.Name[0] == selLetter[0]);
            System.Threading.Thread.Sleep(2000);
            return PartialView("_Selection", model);
        }
        public PartialViewResult _DescriptiveInfo(int id)
        {
            var obj = Objects.First(e => e.Id == id);
            string[] model = null;
            return PartialView(model);
        }
        public ViewResult InfoWithPaging(string pageKey = "..", int pageNumber = 0)
        {
            IEnumerable<Classroom> model = Objects; //.OrderBy(e => e.Name)
            if (!string.IsNullOrEmpty(pageKey) && pageKey != "..")
            {
                model = model.Where(e => e.Name[0].ToString() == pageKey);
            }
            if (pageNumber != 0)
            {
                model = model
                    .Skip((pageNumber - 1) * ItemsPerPage)
                    .Take(ItemsPerPage);
            }
            return View(model);
        }
        public ViewResult ClassroomsByProfessorNamesInfo(
                string categoryName = NavigationController.ALL_CATEGORIES)
        {
            IEnumerable<Classroom> models = Objects.OrderBy(e => e.Name);
            if (!string.IsNullOrEmpty(categoryName) &&
                categoryName != NavigationController.ALL_CATEGORIES)
            {
                models = models
                    .Where(e => e.ProfessorName == categoryName);
            }
            ViewBag.SelectedCategoryName = categoryName;
            return View(models);
        }

        public ActionResult BrowseByLetters()
        {
            ViewBag.selProfessorName = CreateProfessorNameSelectList();
            ViewBag.Letters = new[] { ALL_PAGE_LINK_NAME }
                .Concat(Objects
                    .Select(e => e.Name[0].ToString())
                    .Distinct().OrderBy(e => e));

            return View(tableModelObjects);
        }
        public ViewResult _Details(int id)
        {
            var obj = tableModelObjects.First(e => e.Id == id);
            return View(obj);
        }
        public ViewResult Browse()
        {
            return View(tableModelObjects);
        }
       
        [HttpPost]
        public JsonResult JsonInfo(int id)
        {
            var info = GetInfo(id);
            System.Threading.Thread.Sleep(1000);
            return Json(info);
        }
        string[] GetInfo(int id)
        {
            var obj = Objects.First(e => e.Id == id);
            string s = null;
            if (!string.IsNullOrWhiteSpace(obj.Note))
            {
                s += "Примітка: " + obj.Note + "\n";
            }

            string[] info = null;
            if (s != null)
            {
                info = s.Split(new[] { '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            }
            return info;
        }
        [HttpPost]
        public JsonResult JsonIdInfo(int id)
        {
            var info = GetInfo(id);
            return Json(new { Id = id, Info = info }); //, JsonRequestBehavior.AllowGet
        }
    }
}