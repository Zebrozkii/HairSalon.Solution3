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

        [HttpGet("/clients/new")]
        public ActionResult New()
        {
          return View();
        }
      [HttpGet("/clients/deleteall")]
      public ActionResult DeleteAll()
      {
        Client.ClearAll();
        return View();
      }

       [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View( model);
        }

  }
}
