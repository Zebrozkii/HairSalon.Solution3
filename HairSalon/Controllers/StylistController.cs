using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpGet("/stylists/deleteall")]
    public ActionResult DeleteAll()
    {
      Stylist.ClearAll();
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
      List<Specialty> stylistSpecialty = selectedStylist.GetSpecialty();
      List<Specialty> allSpecialty = Specialty.GetAll();
      model.Add("stylistSpecialty",stylistSpecialty);
      model.Add("allSpecialty",allSpecialty);
      model.Add("stylist", selectedStylist);
      model.Add("client", stylistClient);
      return View(model);
    }
    [HttpGet("/stylists/{id}/delete")]
      public ActionResult Delete(int id)
      {
        Stylist selectedStylist = Stylist.Find(id);
        selectedStylist.Delete(id);
        return RedirectToAction("Index");
      }


    // This one creates new Items within a given Stylist, not new Stylist:
    [HttpPost("/stylists/{stylistId}/clients")]
     public ActionResult Create(string clientName, int stylistId)
     {
       Dictionary<string, object> model = new Dictionary<string, object>();
       Stylist foundStylist = Stylist.Find(stylistId);
       Client newClient = new Client(clientName, stylistId);
       newClient.Save();
       List<Client> stylistClients = foundStylist.GetClient();
       model.Add("client", stylistClients);
       model.Add("stylist", foundStylist);
       return View("Show", model);
     }
     [HttpGet("/stylists/{stylistId}/edit")]
       public ActionResult Edit(int stylistId)
       {
           Dictionary<string, object> model = new Dictionary<string, object>();
           Stylist stylist = Stylist.Find(stylistId);
           model.Add("stylist", stylist);
           return View(model);
       }

       [HttpPost("/stylists/{stylistId}")]
        public ActionResult Update(int stylistId, string newName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = selectedStylist.GetClient();
            List<Specialty> specialtyStylists = selectedStylist.GetSpecialty();
            List<Specialty> allSpecialties = Specialty.GetAll();
            model.Add("specialtyStylists", specialtyStylists);
            model.Add("stylist", selectedStylist);
            model.Add("client", stylistClients);
            model.Add("allSpecialties", allSpecialties);
            selectedStylist.Edit(newName);
            return View("Show", model);
        }
      [HttpPost("/stylists/{stylistId}/specialty/edit")]
      public ActionResult Update(int specialtyId, int stylistId)
      {
        Specialty specialty = Specialty.Find(specialtyId);
        Stylist stylist = Stylist.Find(stylistId);
        specialty.AddStylist(stylist);
        return RedirectToAction("Show", new {id = stylistId});
      }



  }
}
