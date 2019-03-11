using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
       Stylist stylist = Stylist.Find(stylistId);
       return View(stylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("clients", client);
      model.Add("stylists", stylist);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
     public ActionResult Delete(int stylistId, int clientId)
     {
       Client client = Client.Find(clientId);
       Console.WriteLine("Client found " + client.GetId().ToString());
       client.Delete();

       return RedirectToAction("Show", "Stylist", new { id = stylistId });
     }


    [HttpPost("/clients/delete")]
    public ActionResult DeleteAll()
    {
      Client.ClearAll();
      return View();
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
      public ActionResult Edit(int stylistId, int clientId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistId);
        model.Add("stylists", stylist);
        Client item = Client.Find(clientId);
        model.Add("clients", item);
        return View(model);
      }

      [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Update(int stylistId, int clientId, string newName)
        {
          Client item = Client.Find(clientId);
          item.Edit(newName);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist stylist = Stylist.Find(stylistId);
          model.Add("stylists", stylist);
          model.Add("clients", item);
          return View("Show", model);
        }

  }
}
