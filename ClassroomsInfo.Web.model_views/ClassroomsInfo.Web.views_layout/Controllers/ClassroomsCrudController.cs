
using ClassroomsInfo.Data;
using ClassroomsInfo.Entities;
using ClassroomsInfo.Web.views_layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassroomsInfo.Web.Controllers
{
    public class ClassroomsCrudController : Controller
    {
        private ICollection<Classroom> objects;
        private IEnumerable<ClassroomSelectionModel> selectionModelObjects { get; set; }
        private IEnumerable<ClassroomEditingModel> editingModelObjects { get; set; }
        public ICollection<Classroom> Objects
        {
            get { return objects; }
            set
            {
                objects = value;
                selectionModelObjects = objects
                    .Select(e => (ClassroomSelectionModel)e).OrderBy(e => e.Number);
                editingModelObjects = objects
                    .Select(e => (ClassroomEditingModel)e).OrderBy(e => e.Number);
            }
        }
        public IEnumerable<ProfessorName> ProfessorName { get; set; }

        public ClassroomsCrudController()
        {
            Objects = StaticDataContext.classrooms;
            ProfessorName = StaticDataContext.professorsNames;
        }

        public ActionResult Index()
        {
            return View(selectionModelObjects);
        }

        public ActionResult Create()
        {
            ViewBag.ProfessorName = CreateProfessorNamesSelectList();
            return View(new ClassroomEditingModel());
        }

        [HttpPost]
        public ActionResult Create(ClassroomEditingModel model)
        {
            Objects.Add((Classroom)model);
            StaticDataContext.professorsNames.Add(new ProfessorName() { NameP = model.ProfessorName });
            return RedirectToAction("Index");

        }



        public ActionResult Edit(int id)
        {
            var model = editingModelObjects.First(e => e.Id == id);
            ViewBag.ProfessorName = CreateProfessorNamesSelectList(model.ProfessorName);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ClassroomEditingModel model)
        {
            var entityObject = Objects.First(e => e.Id == model.Id);
            UpdateEntityObject(entityObject, model);
            return RedirectToAction("Index");
        }

        private void UpdateEntityObject(Classroom entityObject,
                ClassroomEditingModel model)
        {
            entityObject.Number = model.Number;
            entityObject.ProfessorName = model.ProfessorName;
            entityObject.TypeName = model.TypeName;
            entityObject.Seats = model.Seats;
            entityObject.Note = model.Note;


        }

        public ActionResult Delete(int id)
        {
            var model = editingModelObjects.First(e => e.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Classroom model)
        {
            Classroom entityObject = Objects.First(e => e.Id == model.Id);
            Objects.Remove(entityObject);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = editingModelObjects.First(e => e.Id == id);
            return View(model);
        }

        List<SelectListItem> CreateProfessorNamesSelectList(string selectedValue = "")
        {
            List<string> values = new List<string>();
            values.AddRange(ProfessorName.Select(e => e.NameP));
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }
    }
}