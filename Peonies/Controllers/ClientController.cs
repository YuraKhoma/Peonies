﻿
using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;
using System.Net;

namespace Peonies.Controllers
{
    public class ClientController : Controller
    {

        private MyDbContext dbContext = new MyDbContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            return View(dbContext.Clients.ToList());
        }


        public ActionResult Detail(int id)
        {
            var data = dbContext.Clients.Where(x => x.ClientId == id).FirstOrDefault();
            return View(data);
        }
    }
}
