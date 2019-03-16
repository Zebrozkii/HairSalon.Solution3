using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }
      [HttpGet("/clients/deleteall")]
      public ActionResult DeleteAll()
      {
        Client.ClearAll();
        return View();
      }

       [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }
        [HttpGet("/clients/{clientId}")]
        public ActionResult Show(int clientId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Client newClient = Client.Find(clientId);
          Stylist newStylist = Stylist.Find(newClient.GetStylistId());
          model.Add("client",newClient);
          model.Add("stylist",newStylist);
          return View(model);
        }
        [HttpGet("stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(clientId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }
        [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
      public ActionResult Update(int stylistId, int clientId, string newName)
      {
          Client client = Client.Find(clientId);
          client.Edit(newName);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist stylist = Stylist.Find(stylistId);
          model.Add("stylist", stylist);
          model.Add("client", client);
          return View("Show", model);
      }


  }
}
