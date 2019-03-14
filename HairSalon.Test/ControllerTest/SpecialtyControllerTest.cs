using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorretView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult newView = controller.Create("john");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult newView = controller.Show(0);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddStylist_ReturnRedirectToCorrectAction_Show()
        {
            SpecialtyController controller = new SpecialtyController();
            RedirectToActionResult newView = controller.AddStylist(1, 1) as RedirectToActionResult;
            string result = newView.ActionName;
            Assert.AreEqual("Show", result);
        }
    }
}
