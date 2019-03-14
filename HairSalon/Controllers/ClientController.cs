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
        [HttpGet("/clients/{clientsId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist newStylist = Stylist.Find(stylistId);
          Client newClient = Client.Find(clientId);
          model.Add("client",newClient);
          model.Add("stylist",newStylist);
          return View(model);
        }

  }
}
