using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jimmy_zebroski_test;";
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
      Assert.AreEqual(result,0);
    }
    [TestMethod]
    public void ClientConstructor_Test()
    {

      Client newClient = new Client("test", 1);
      Assert.AreEqual(typeof(Client),newClient.GetType());
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
    Client firstClient = new Client("Shannon",1);
    Client secondClient = new Client("Shannon",1);

    //Assert
    Assert.AreEqual(firstClient, secondClient);
  }
  [TestMethod]
  public void GetAll_ReturnsEmptyList_Clients()
  {
    List<Client> newList = new List<Client> {};
    List<Client> result = Client.GetAll();
    CollectionAssert.AreEqual(newList, result);
  }
  [TestMethod]
  public void Save_SavesToDataBase()
  {
    Client testClient = new Client("jimmy", 1);
    testClient.Save();
    Client foundClient = Client.Find(testClient.GetId());
    Assert.AreEqual(testClient,foundClient);
  }
  [TestMethod]
  public void GetAllReturnsClientList()
  {
    string name1 = "jimmy";
    string name2 = "john";
    Client newClient1 = new Client(name1,1);
    newClient1.Save();
    Client newClient2 = new Client(name2,1);
    newClient2.Save();
    List<Client> newList = new List<Client> { newClient1, newClient2 };
    List<Client> result = Client.GetAll();
    Console.WriteLine(newList);
    Console.WriteLine(result);
    result.ForEach(Console.WriteLine);
    newList.ForEach(Console.WriteLine);
    CollectionAssert.AreEqual(newList,newList);
  }
  [TestMethod]
  public void Find_ReturnsCorrectClientFromDatase_Client()
  {
      Client testClient = new Client("brenda", 1);
      testClient.Save();
      Client foundClient = Client.Find(testClient.GetId());
      Assert.AreEqual(testClient, foundClient);
  }
  [TestMethod]
public void Save_SavesToDatabase_ClientList()
  {
      Client testClient = new Client("brenda", 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client> { testClient };
      CollectionAssert.AreEqual(testList, result);
  }
  [TestMethod]
  public void Save_AssignsIdToObject_Id()
    {
        Client testClient = new Client("brenda", 1);
        testClient.Save();
        Client savedClient = Client.GetAll()[0];
        int result = savedClient.GetId();
        int testId = testClient.GetId();
        Assert.AreEqual(testId, result);
    }

        [TestMethod]
      public void GetStylistId_ReturnsClientsParentStylistId_Int()
      {
          Stylist newStylist = new Stylist("jane");
          Client newClient = new Client("brenda", 0, newStylist.GetId());
          int result = newClient.GetStylistId();
          Assert.AreEqual(newStylist.GetId(), result);
      }





  }
}
