using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class AppsEntitiesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: AppsEntities
        public ActionResult Index()
        {
            return View(db.AppsEntities.ToList());
        }

        // GET: AppsEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            if (appsEntity == null)
            {
                return HttpNotFound();
            }
            return View(appsEntity);
        }

        // GET: AppsEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppsEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status,IsActive,AddedDate,UdatedDate")] AppsEntity appsEntity)
        {
            if (ModelState.IsValid)
            {
                db.AppsEntities.Add(appsEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appsEntity);
        }

        // GET: AppsEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            if (appsEntity == null)
            {
                return HttpNotFound();
            }
            return View(appsEntity);
        }

        // POST: AppsEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status,IsActive,AddedDate,UdatedDate")] AppsEntity appsEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appsEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appsEntity);
        }

        // GET: AppsEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            if (appsEntity == null)
            {
                return HttpNotFound();
            }
            return View(appsEntity);
        }

        // POST: AppsEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            db.AppsEntities.Remove(appsEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
