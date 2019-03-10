using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylist = Stylist.GetAll();
      return View(allStylist);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClient = selectedStylist.GetClient();
      model.Add("stylist", selectedStylist);
      model.Add("client", stylistClient);
      return View(model);
    }
    [HttpPost("/stylists/{id}/delete")]
      public ActionResult Delete(int id)
      {
        Stylist selectedStylist = Stylist.Find(id);
        selectedStylist.Delete(id);
        return RedirectToAction("Index");
      }

    // This one creates new Items within a given Stylist, not new Stylist:
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string clientName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      // foundStylist.AddClient(newClient);
      List<Client> stylistClients = foundStylist.GetClient();
      model.Add("client", stylistClients);
      model.Add("stylist", foundStylist);
      return View("Show", model);
    }


  }
}
