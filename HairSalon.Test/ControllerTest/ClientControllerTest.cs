using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {
    [TestMethod]
    public void DeleteAll_ReturnCorrectView()
    {
      //Arrange
      ClientsController controller = new ClientsController();
      //Act
      ActionResult indexView = controller.DeleteAll();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
