using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
  private string _name;
  private int _id;

  public Stylist(string name, int id=0)
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
    cmd.CommandText = @"DELETE FROM stylist;";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
    conn.Dispose();
    }
  }
  public static List<Stylist> GetAll()
  {
    List<Stylist> allStylists = new List<Stylist>{};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM stylist;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      string stylistName = rdr.GetString(1);
      int stylistId = rdr.GetInt32(0);
      Stylist newStylist = new Stylist(stylistName, stylistId);
      allStylists.Add(newStylist);
    }
    if (conn != null)
    {
      conn.Dispose();
    }
    return allStylists;
  }
  public override bool Equals(System.Object otherStylist)
  {
    if (!(otherStylist is Stylist))
    {
      return false;
    }
    else
    {
      Stylist newStylist = (Stylist) otherStylist;
      bool idEquality = this.GetId().Equals(newStylist.GetId());
      bool nameEquality = this.GetName().Equals(newStylist.GetName());
      return (idEquality && nameEquality);
    }
  }
  public void Save(){
  MySqlConnection conn = DB.Connection();
  conn.Open();
  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"INSERT INTO stylist (name) VALUES (@name);";
  MySqlParameter name = new MySqlParameter();
  name.ParameterName = "@name";
  name.Value = this._name;
  cmd.Parameters.Add(name);
  cmd.ExecuteNonQuery();
  _id = (int) cmd.LastInsertedId;
  conn.Close();
    if(conn != null)
    {
      conn.Dispose();
    }
  }
  public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int StylistId = 0;
      string StylistName = "";
      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
      }
      Stylist newStylist = new Stylist(StylistName, StylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }
    public List<Client> GetClient()
{
    List<Client> allStylistClients = new List<Client> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
    MySqlParameter stylistId = new MySqlParameter();
    stylistId.ParameterName = "@stylist_id";
    stylistId.Value = _id;
    cmd.Parameters.Add(stylistId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    while (rdr.Read())
    {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, clientStylistId, clientId);
        allStylistClients.Add(newClient);
    }
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
    return allStylistClients;
  }
  public void Edit(string newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylist SET name = @newName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newStylist;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _name = newStylist;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  public void Delete(int id)
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM stylist WHERE id = @thisId;";
    MySqlParameter thisId = new MySqlParameter();
    thisId.ParameterName = "@thisId";
    thisId.Value = id;
    cmd.Parameters.Add(thisId);
    cmd.ExecuteNonQuery();
    conn.Close();
    if(conn != null)
    {
      conn.Dispose();
    }
    }

    //adding new stuff below this!!!!!!<<<<-----
    public List<Specialty> GetSpecialty()
 {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT specialty.* FROM stylist
         JOIN stylist_specialty ON (stylist_id = stylist_specialty.stylist_id)
         JOIN specialty ON (stylist_specialty.specialty_id = specialty.id)
         WHERE stylist.id = @StylistId;";
     MySqlParameter stylistId = new MySqlParameter();
     stylistId.ParameterName = "@StylistId";
     stylistId.Value = _id;
     cmd.Parameters.Add(stylistId);
     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     List<Specialty> specialties = new List<Specialty> { };
     while (rdr.Read())
     {
         int thisSpecialtyId = rdr.GetInt32(0);
         string specialtyName = rdr.GetString(1);
         Specialty foundSpecialty = new Specialty(specialtyName, thisSpecialtyId);
         specialties.Add(foundSpecialty);
     }
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     return specialties;

  }
  public void AddSpecialty(Specialty newSpecialty)
{
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO stylist_specialty (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
    MySqlParameter stylist_id = new MySqlParameter();
    stylist_id.ParameterName = "@StylistId";
    stylist_id.Value = _id;
    cmd.Parameters.Add(stylist_id);
    MySqlParameter specialty_id = new MySqlParameter();
    specialty_id.ParameterName = "@SpecialtyId";
    specialty_id.Value = newSpecialty.GetId();
    cmd.Parameters.Add(specialty_id);
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
}

}
}
