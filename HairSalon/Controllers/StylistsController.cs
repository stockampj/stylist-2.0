using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;

        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();        
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            if (stylist.Name != null)
            {
                _db.Stylists.Add(stylist);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Show(int id)
        {
            Stylist thisStylist = _db.Stylists.Include(stylist => stylist.Clients).FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);        
        }

        public ActionResult Edit(int id)
        {
            var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }
        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisStylist = _db.Stylists.Include(stylist => stylist.Clients).FirstOrDefault(stylist => stylist.StylistId == id);
            List<Client> clientsWhoNeedUpdates = new List<Client> { };
            foreach(Client client in thisStylist.Clients)
            {
                clientsWhoNeedUpdates.Add(client);
            }
            if (clientsWhoNeedUpdates.Count != 0)
            {
                return RedirectToAction("Index", "Clients", new {message = "client dependency"});
            }
            else
            {
                _db.Stylists.Remove(thisStylist);
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}