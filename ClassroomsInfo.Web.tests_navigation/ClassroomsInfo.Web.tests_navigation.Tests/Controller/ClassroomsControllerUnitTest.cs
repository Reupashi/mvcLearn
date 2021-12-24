using ClassroomsInfo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClassroomsInfo.Web.tests_navigation.Controllers;
using ClassroomsInfo.Web.tests_navigation.Tests.Controller;

namespace ClassroomsInfo.Web.tests.navigation.Tests.Controllers
{
  [TestClass]
  public class ClassroomsControllerUnitTest
  {
    [TestMethod]
    public void ClassroomsByNamesInfo_ResultIsViewResult()
    {
      var controller = new FlatsInfoController()
      {
        Objects = TestClassroomsData.Objects
      };

      var result = controller.ClassroomsByNamesInfo();

      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    //[TestMethod]
    //public void ClassroomsByNamesInfo_ViewBagAreEqualParam_True()
    //{
    //  var controller = new ClassroomsInfoController()
    //  {
    //    Objects = TestClassroomsData.Objects
    //  };
    //  string categoryName = "";
    //  var result = controller.ClassroomsByNamesInfo(categoryName) as ViewResult;
    //  var selectedCategoryName = result.ViewBag.SelectedCategoryName as string;

    //  Assert.AreEqual(categoryName, selectedCategoryName);
    //}

    [TestMethod]
    public void ClassroomsByNamesInfo_ModelIsEnumerableOfClassroom()
    {
      var controller = new FlatsInfoController()
      {
        Objects = TestClassroomsData.Objects
      };

      var result = controller.ClassroomsByNamesInfo() as ViewResult;
      var model = result.Model;

      Assert.IsInstanceOfType(model, typeof(IEnumerable<Classroom>));
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_NoParam_ModelContainsAllObjects()
    {
      var controller = new FlatsInfoController()
      {
        Objects = TestClassroomsData.Objects
      };

      var result = controller.ClassroomsByNamesInfo() as ViewResult;
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(TestClassroomsData.Objects.Count, model.Count());
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_CATEGORIES_ModelContainsAllObjects()
    {
      var controller = new FlatsInfoController()
      {
        Objects = TestClassroomsData.Objects
      };

      var result = controller.ClassroomsByNamesInfo(
          NavigationController.ALL_CATEGORIES) as ViewResult;
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(TestClassroomsData.Objects.Count, model.Count());
    }

    [TestMethod]
    public void ClassroomsByNamesInfo_ParamProfessorName_ModelContains2Object()
    {
      var controller = new FlatsInfoController()
      {
        Objects = TestClassroomsData.Objects
      };
      string categoryName = "Ігнатьєв В'ячеслав Робертович";

      ViewResult result = controller.ClassroomsByNamesInfo(categoryName);
      var model = result.Model as IEnumerable<Classroom>;

      Assert.AreEqual(2, model.Count());
    }
  }
}

