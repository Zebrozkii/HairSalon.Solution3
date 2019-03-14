using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Create_ReturnsCorrectActionType_RedirctToActionResult()
        {
            StylistController controller = new StylistController();
            ActionResult view = controller.Create("style their hair");
            Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Create_RedirectToCorrectAction_Index()
        {
            StylistController controller = new StylistController();
            RedirectToActionResult actionResult = controller.Create("cut the hair") as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual(result, "Index");
        }
    }
}
