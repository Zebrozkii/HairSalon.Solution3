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


  }
}
