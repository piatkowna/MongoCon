using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoCon.Properties;
using MongoCon.Models;
using MongoCon.App_Start;

namespace MongoCon.Controllers
{
    public class HomeController : Controller
    {
        public DbContext Context { get; set; }

        public HomeController() : this(new DbContext())
        {}

        public HomeController(DbContext context)
        {
            Context = context;
        }

        public ActionResult Index()
        {
            var people = Context.People.Find(_ => true).ToList();
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(PostPerson postPerson)
        {
            var person = new Person(postPerson);
            Context.People.InsertOne(person);
            return RedirectToAction("Index");
        }

        public ActionResult AddPerson()
        {
            var person = new Person();
            person.Name = "Janek";
            person.Age = 85;
            Context.People.InsertOne(person);
            return RedirectToAction("Index");
        }
    }
}
