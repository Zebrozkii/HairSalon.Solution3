using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest
  {
  public void Dispose()
  {
    Client.ClearAll();
  }
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server = localhost;user id=root;password=root;port=8889;database=jimmy_zebroski_test;";
    }

    [TestMethod]

    public void GetName()
    {
      string name = "Jimmy Zebroski";
      int id = 1;
      Client test = new Client(name,id);
      string result = test.GetName();
      Assert.AreEqual(result,name);
    }

    [TestMethod]
    public void GetId()
    {
      string name = "Jimmy Zebroski";
      int id = 1;
     Client test = new Client(name,id);
      int result = test.GetId();
      Assert.AreEqual(result,1);
    }


  }
}
