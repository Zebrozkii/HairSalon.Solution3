using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
  private string _name;
  private int _id;

  public Stylist(string name, int id)
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
  public static List<Stylist> GetAll()
  {
    List<Stylist> allItems = new List<Stylist>{};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM stylist;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int stylistId = rdr.GetInt32(0);
      string stylistName = rdr.GetString(1);
      Stylist newStylist = new Stylist(stylistName, stylistId);
      allItems.Add(newStylist);
    }
    if(conn != null)
    {
      conn.Dispose();
    }
    return allItems;
  }
  public static void ClearALL()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM stylist;";
    cmd.ExecuteNonQuery();
    conn.Close();
    if(conn != null)
    {
      conn.Dispose();
    }
  }
  
  }

}
