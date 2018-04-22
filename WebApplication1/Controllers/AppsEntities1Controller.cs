using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class AppsEntities1Controller : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/AppsEntities1
        public IQueryable<AppsEntity> GetAppsEntities()
        {
            return db.AppsEntities;
        }

        // GET: api/AppsEntities1/5
        [ResponseType(typeof(AppsEntity))]
        public IHttpActionResult GetAppsEntity(int id)
        {
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            if (appsEntity == null)
            {
                return NotFound();
            }

            return Ok(appsEntity);
        }

        // PUT: api/AppsEntities1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppsEntity(int id, AppsEntity appsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appsEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(appsEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppsEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppsEntities1
        [ResponseType(typeof(AppsEntity))]
        public IHttpActionResult PostAppsEntity(AppsEntity appsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppsEntities.Add(appsEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appsEntity.Id }, appsEntity);
        }

        // DELETE: api/AppsEntities1/5
        [ResponseType(typeof(AppsEntity))]
        public IHttpActionResult DeleteAppsEntity(int id)
        {
            AppsEntity appsEntity = db.AppsEntities.Find(id);
            if (appsEntity == null)
            {
                return NotFound();
            }

            db.AppsEntities.Remove(appsEntity);
            db.SaveChanges();

            return Ok(appsEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppsEntityExists(int id)
        {
            return db.AppsEntities.Count(e => e.Id == id) > 0;
        }
    }
}