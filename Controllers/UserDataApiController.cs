using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TrueDynamicWeb.Models;

namespace TrueDynamicWeb.Controllers
{
    public class UserDataAPIController : ApiController
    {
        private TrueDynamicDBEntities db = new TrueDynamicDBEntities();

        // GET: api/UserDataAPI
        public IQueryable<User_Data> GetUser_Data()
        {
            return db.User_Data;
        }

        // GET: api/UserDataAPI/5
        [ResponseType(typeof(User_Data))]
        public async Task<IHttpActionResult> GetUser_Data(int id)
        {
            User_Data user_Data = await db.User_Data.FindAsync(id);
            if (user_Data == null)
            {
                return NotFound();
            }

            return Ok(user_Data);
        }

        // PUT: api/UserDataAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser_Data(int id, User_Data user_Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Data.UserDataId)
            {
                return BadRequest();
            }

            db.Entry(user_Data).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_DataExists(id))
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

        // POST: api/UserDataAPI
        [ResponseType(typeof(User_Data))]
        public async Task<IHttpActionResult> PostUser_Data(User_Data user_Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDetails = await db.User_Data.Where(x => x.UserEmail == user_Data.UserEmail && x.Password == user_Data.Password).FirstOrDefaultAsync();
            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        

        // DELETE: api/UserDataAPI/5
        [ResponseType(typeof(User_Data))]
        public async Task<IHttpActionResult> DeleteUser_Data(int id)
        {
            User_Data user_Data = await db.User_Data.FindAsync(id);
            if (user_Data == null)
            {
                return NotFound();
            }

            db.User_Data.Remove(user_Data);
            await db.SaveChangesAsync();

            return Ok(user_Data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_DataExists(int id)
        {
            return db.User_Data.Count(e => e.UserDataId == id) > 0;
        }
    }
}