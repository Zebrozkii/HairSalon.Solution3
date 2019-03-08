using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;
    private int _stylistId;

    public Client(string name,int stylistId, int id=0 )
    {
      _name = name;
      _id = id;
      _stylistId = stylistId;

    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int StylistId()
    {
      return _stylistId;
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

    public static List<Client> GetAll()
    {
      Client dummyItem = new Client("dummy",1);
      List<Client> allClients = new List<Client>{dummyItem};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientStylistID = rdr.GetInt32(2);
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        Client newClient = new Client(clientName, clientId, clientStylistID);
        allClients.Add(newClient);
      }
      if(conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }
    public static Client Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM client WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int ClientId = 0;
        int ClientStylistID = 0;
        string ClientName = "";
        while(rdr.Read())
        {
          ClientId = rdr.GetInt32(0);
          ClientName = rdr.GetString(1);
          ClientStylistID = rdr.GetInt32(2);
        }
        Client newClient = new Client(ClientName, ClientId, ClientStylistID);
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return newClient;
      }
      public void Save()
{
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @GetStylistId);";
    MySqlParameter name = new MySqlParameter();
    name.ParameterName = "@name";
    name.Value = this._name;
    cmd.Parameters.Add(name);
    MySqlParameter stylistId = new MySqlParameter();
    stylistId.ParameterName = "@GetStylistId";
    stylistId.Value = this._stylistId;
    cmd.Parameters.Add(stylistId);
    cmd.ExecuteNonQuery();
    _id = (int)cmd.LastInsertedId;
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
}



  }
}
