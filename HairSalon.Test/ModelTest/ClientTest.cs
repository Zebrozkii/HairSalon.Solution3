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
    [TestMethod]
    public void GetAll_ClientEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }
    [TestMethod]
  public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
  {
    //Arrange, Act
    Client firstClient = new Client("Shannon");
    Client secondClient = new Client("Shannon");

    //Assert
    Assert.AreEqual(firstClient, secondClient);
  }
  [TestMethod]
  public void Save_SavesClientToDatabase_ClientList()
  {
    //Arrange
    Client testClient = new Client("Shannon");
    testClient.Save();

    //Act
    List<Client> result = Client.GetAll();
    List<Client> testList = new List<Client>{testClient};

    //Assert
    CollectionAssert.AreEqual(testList, result);
  }
  [TestMethod]
  public void Save_DatabaseAssignsIdToClient_Id()
  {
    //Arrange
    Client testClient = new Client("Shannon");
    testClient.Save();

    //Act
    Client savedClient = Client.GetAll()[0];

    int result = savedClient.GetId();
    int testId = testClient.GetId();

    //Assert
    Assert.AreEqual(testId, result);
  }
  [TestMethod]
  public void Find_ReturnsClientInDatabase_Client()
  {
    //Arrange
    Client testClient = new Client("Barb");
    testClient.Save();

    //Act
    Client foundClient = Client.Find(testClient.GetId());

    //Assert
    Assert.AreEqual(testClient, foundClient);
  }


  }
}
