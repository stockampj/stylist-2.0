using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index(string message)
        {
            ViewBag.ClientDependency = "";
            if (message == "client dependency")
            {
                ViewBag.ClientDependency = "You must reassign some clients before deleting this stylist";
            }
            List<Client> clientlist = _db.Clients.Include(client => client.Stylist).ToList();
            return View(clientlist);
        }

        public ActionResult Create()
        {
            ViewBag.NoStylistErrorMessage = "";
            if (_db.Stylists.ToList().Count == 0)
            {
                ViewBag.NoStylistErrorMessage = "Please add a stylist first!";
            }
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}