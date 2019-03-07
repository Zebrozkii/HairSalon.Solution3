using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;

    public Client(string name, int id=0)
    {
      _name = name;
      _id = id;

    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
 {
   MySqlConnection conn = DB.Connection();
   conn.Open();
   var cmd = conn.CreateCommand() as MySqlCommand;
   cmd.CommandText = @"DELETE FROM items;";
   cmd.ExecuteNonQuery();
   conn.Close();
   if (conn != null)
   {
    conn.Dispose();
   }
}

    // public static List<Client> GetAll()
    // {
    //   Client dummyItem = new Client("dummy",1);
    //   List<Client> allClients = new List<Client>{dummyItem};
    //   // MySqlConnection conn = DB.Connection();
    //   // conn.Open();
    //   // MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   // cmd.CommandText = @"SELECT * FROM stylist;";
    //   // MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   // while(rdr.Read())
    //   // {
    //   //   int clientId = rdr.GetInt32(0);
    //   //   string clientName = rdr.GetString(1);
    //   //   Client newClient = new Client(clientName, clientId);
    //   //   allItems.Add(newClient);
    //   // }
    //   // if(conn != null)
    //   // {
    //   //   conn.Dispose();
    //   // }
    //   return allClients;
    // }



  }
}
