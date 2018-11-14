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
using WebAddressBook.Models;

namespace WebAddressBook.Controllers
{
    public class Employee1Controller : ApiController
    {
        private DBModel1 db = new DBModel1();

        // GET: api/Employee1
        public IQueryable<Employee1> GetEmployee1()
        {
            return db.Employee1;
        }

      

        // PUT: api/Employee1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee1(int id, Employee1 employee1)
        {
           
            if (id != employee1.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employee1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee1Exists(id))
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

        // POST: api/Employee1
        [ResponseType(typeof(Employee1))]
        public IHttpActionResult PostEmployee1(Employee1 employee1)
        {
           
            db.Employee1.Add(employee1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee1.EmployeeID }, employee1);
        }

        // DELETE: api/Employee1/5
        [ResponseType(typeof(Employee1))]
        public IHttpActionResult DeleteEmployee1(int id)
        {
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return NotFound();
            }

            db.Employee1.Remove(employee1);
            db.SaveChanges();

            return Ok(employee1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee1Exists(int id)
        {
            return db.Employee1.Count(e => e.EmployeeID == id) > 0;
        }
    }
}