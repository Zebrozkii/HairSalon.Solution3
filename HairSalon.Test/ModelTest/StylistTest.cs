using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest
  {
    [TestMethod]

    public void GetName()
    {
      string name = "Jimmy Zebroski";
      int id = 1;
      Stylist test = new Stylist(name,id);
      string result = test.GetName();
      Assert.AreEqual(result,name);
    }

    [TestMethod]
    public void GetId()
    {
      string name = "Jimmy Zebroski";
      int id = 1;
      Stylist test = new Stylist(name,id);
      int result = test.GetId();
      Assert.AreEqual(result,1);
    }
  }
}
