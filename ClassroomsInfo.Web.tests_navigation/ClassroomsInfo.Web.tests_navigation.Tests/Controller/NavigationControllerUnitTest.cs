using ClassroomsInfo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClassroomsInfo.Web.tests_navigation.Controllers;


namespace ClassroomsInfo.Web.tests_navigation.Tests.Controller
{
  [TestClass]
  public class NavigationControllerUnitTest
  {
    [TestMethod]
    public void ClassroomsByNamesMenu_ResultIsPartialViewResult()
    {
      var controller = new NavigationController()
      {
        classrooms = TestClassroomsData.Objects
      };

      var result = controller.ClassroomsByNamesMenu();

      Assert.IsInstanceOfType(result, typeof(PartialViewResult));
    }

    [TestMethod]
    public void ClassroomsByNamesMenu_ParamProfessorName_ModelReturnDistinctResults()
    {
      var controller = new NavigationController()
      {
        classrooms = TestClassroomsData.Objects
      };

      string categoryName = "Ігнатьєв В'ячеслав Робертович";

      var result = controller.ClassroomsByNamesMenu(categoryName);
      IEnumerable<string> model = result.Model as IEnumerable<string>;

      Assert.IsTrue(model.Count(element => element == categoryName) == 1);
    }

    [TestMethod]
    public void ClassroomsByNamesMenu_ParamProfessorName_ModelAlwaysReturnAllCategories()
    {
      var controller = new NavigationController();

      var result = controller.ClassroomsByNamesMenu();
      IEnumerable<string> model = result.Model as IEnumerable<string>;

      Assert.IsTrue(model.Count(element => element == NavigationController.ALL_CATEGORIES) == 1);
    }

    [TestMethod]
    public void ClassroomsByNamesMenu_ParamProfessorName_ModelReturnSortedResults()
    {
      var controller = new NavigationController()
      {
        classrooms = TestClassroomsData.Objects
      };
      List<string> testData = new List<string>();
      testData.Add(NavigationController.ALL_CATEGORIES);
      testData.AddRange(TestClassroomsData.Objects.Select(element => element.ProfessorName));
      testData.Sort();
      testData = testData.Distinct().ToList();

      var result = controller.ClassroomsByNamesMenu();
      IEnumerable<string> model = result.Model as IEnumerable<string>;

      Assert.IsTrue(IsSameElementsOrder(testData, model));
    }


    private bool IsSameElementsOrder(IEnumerable<string> left, IEnumerable<string> right)
    {
      int length = left.Count();

      if (right.Count() != length)
        return false;

      for (int i = 0; i < length; i++)
      {
        if (left.ElementAt(i) != right.ElementAt(i))
          return false;
      }

      return true;
    }
  }
}
