using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server = localhost;user id=root;password=root;port=8889;database=jimmy_zebroski_test;";

    }
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

  [TestMethod]
  public void GetAll_StylistEmptyAtFirst_List()
  {
    //Arrange, Act
    int result = Stylist.GetAll().Count;

    //Assert
    Assert.AreEqual(0, result);
  }
  [TestMethod]
public void Equals_ReturnsTrueIfNamesAreTheSame_Category()
{
  //Arrange, Act
  Stylist firstStylist = new Stylist("Shannon");
  Stylist secondStylist = new Stylist("Shannon");

  //Assert
  Assert.AreEqual(firstStylist, secondStylist);
}
[TestMethod]
public void Save_SavesStylistToDatabase_StylistList()
{
  //Arrange
  Stylist testStylist = new Stylist("Shannon");
  testStylist.Save();

  //Act
  List<Stylist> result = Stylist.GetAll();
  List<Stylist> testList = new List<Stylist>{testStylist};

  //Assert
  CollectionAssert.AreEqual(testList, result);
}
[TestMethod]
public void Save_DatabaseAssignsIdToStylist_Id()
{
  //Arrange
  Stylist testStylist = new Stylist("Shannon");
  testStylist.Save();

  //Act
  Stylist savedStylist = Stylist.GetAll()[0];

  int result = savedStylist.GetId();
  int testId = testStylist.GetId();

  //Assert
  Assert.AreEqual(testId, result);
}
[TestMethod]
public void Find_ReturnsStylistInDatabase_Stylist()
{
  //Arrange
  Stylist testStylist = new Stylist("Barb");
  testStylist.Save();

  //Act
  Stylist foundStylist = Stylist.Find(testStylist.GetId());

  //Assert
  Assert.AreEqual(testStylist, foundStylist);
    }
    public void GetId_ReturnsId_Int()
    {
      
    }
  }
}
