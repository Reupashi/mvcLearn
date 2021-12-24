using ClassroomsInfo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClassroomsInfo.Web.tests_navigation.Controllers;

namespace ClassroomsInfo.Web.tests.navigation.Tests.Controllers
{
  [TestClass]
  public class ClassroomsControllerUnitTest
  {
    List<Classroom> objects = new List<Classroom>
        {
            new Classroom() {
            Name = "Лабораторія",
            ProfessorName = "Ігнатьєв В'ячеслав Робертович",
            },
            new Classroom()
            {
             Name = "Навчальна аудиторія",
             ProfessorName = "Фомічова Агнеса Наумівна",
            },
            new Classroom()
            {
                Name = "Лабораторія ",
                ProfessorName = "Рябова Весняна Михайлівна",
            },
            new Classroom() {
            Name = "Приёмное отделение",
            ProfessorName = "Ігнатьєв В'ячеслав Робертович",
            },

        };
    [TestMethod]
    public void ClassroomsByNamesInfo_ResultIsViewResult()
    {
      var controller = new ClassroomsInfoController()
      {
        Objects = objects
      };
      var result = controller.ClassroomsByNamesInfo();

      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    //[TestMethod]
    //public void ClassroomsByNamesInfo_ViewBagAreEqualParam_True()
    //{
    //  var controller = new ClassroomsInfoController()
    //  {
    //    Objects = objects
    //  };
    //  string categoryName = "";
    //  var result = controller.ClassroomsByNamesInfo(categoryName) as ViewResult;
    //  var selectedCategoryName = result.ViewBag.SelectedCategoryName as string;

    //  Assert.AreEqual(categoryName, selectedCategoryName);
    //}

    [TestMethod]
    public void ClassroomsByNamesInfo_ModelIsEnumerableOfClassroom()
    {
      var controller = new ClassroomsInfoController()
      {
        Objects = objects
      };

      var result = controller.ClassroomsByNamesInfo() as ViewResult;
      var model = result.Model;

      Assert.IsInstanceOfType(model, typeof(IEnumerable<Classroom>));
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_NoParam_ModelContainsAllObjects()
    {
      var controller = new ClassroomsInfoController()
      {
        Objects = objects
      };

      var result = controller.ClassroomsByNamesInfo() as ViewResult;
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(objects.Count, model.Count());
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_CATEGORIES_ModelContainsAllObjects()
    {
      var controller = new ClassroomsInfoController()
      {
        Objects = objects
      };

      var result = controller.ClassroomsByNamesInfo(
          NavigationController.ALL_CATEGORIES) as ViewResult;
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(objects.Count, model.Count());
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_ParamProfessorName_ModelContains2Object()
    {
      var controller = new ClassroomsInfoController()
      {
        Objects = objects
      };
      string categoryName = "Ігнатьєв В'ячеслав Робертович";

      var result = controller.ClassroomsByNamesInfo(categoryName);
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(2, model.Count());
    }
  }
}

