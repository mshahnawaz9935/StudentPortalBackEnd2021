using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using StudentPortalAPI.Models;
using StudentPortalBackEnd2021.Data;

namespace StudentPortalBackEnd2021.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EducationsAPIController : ApiController
    {
        private StudentPortalBackEnd2021Context db = new StudentPortalBackEnd2021Context();

        // GET: api/EducationsAPI
        public IQueryable<Education> GetEducations()
        {
            return db.Educations;
        }

        // GET: api/EducationsAPI/5
        [ResponseType(typeof(Education))]
        public IHttpActionResult GetEducation(Guid id)
        {
            IList<Education> educations = db.Educations.Where(p=> p.studentid == id).ToList();
            if (educations == null)
            {
                return NotFound();
            }

            return Ok(educations);
        }

        // PUT: api/EducationsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEducation(Guid id, Education education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != education.id)
            {
                return BadRequest();
            }

            db.Entry(education).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/EducationsAPI
        [ResponseType(typeof(Education))]
        public IHttpActionResult PostEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Educations.Add(education);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EducationExists(education.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = education.id }, education);
        }

        // DELETE: api/EducationsAPI/5
        [ResponseType(typeof(Education))]
        public IHttpActionResult DeleteEducation(Guid id)
        {
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return NotFound();
            }

            db.Educations.Remove(education);
            db.SaveChanges();

            return Ok(education);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationExists(Guid id)
        {
            return db.Educations.Count(e => e.id == id) > 0;
        }
    }
}