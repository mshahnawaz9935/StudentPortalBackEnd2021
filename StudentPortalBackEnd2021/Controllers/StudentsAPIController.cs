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
using StudentPortaAPI.Models;
using StudentPortalBackEnd2021.Data;

namespace StudentPortalBackEnd2021.Controllers
{
    public class StudentsAPIController : ApiController
    {
        private StudentPortalBackEnd2021Context db = new StudentPortalBackEnd2021Context();

        // GET: api/StudentsAPI
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        // GET: api/StudentsAPI/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(Guid id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/StudentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(Guid id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/StudentsAPI
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.id }, student);
        }

        // DELETE: api/StudentsAPI/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(Guid id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(Guid id)
        {
            return db.Students.Count(e => e.id == id) > 0;
        }
    }
}