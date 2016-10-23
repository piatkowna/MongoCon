using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MongoCon.Models;
using MongoDB.Driver;
using MongoCon.DAL;

namespace MongoCon.Controllers
{
    public class PeopleController : Controller
    {
        public DbContext Context { get; set; }

        public PeopleController() : this(new DbContext())
        { }

        public PeopleController(DbContext context)
        {
            Context = context;
        }


        // GET: People
        public  ActionResult Index()
        {
            return View( Context.People.Find(_ => true).ToList());
        }



        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                Context.People.InsertOne(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Person person = await db.People.FindAsync(id);
        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age")] Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(person).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(person);
        //}

        //// GET: People/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Person person = await db.People.FindAsync(id);
        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        //// POST: People/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Person person = await db.People.FindAsync(id);
        //    db.People.Remove(person);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
