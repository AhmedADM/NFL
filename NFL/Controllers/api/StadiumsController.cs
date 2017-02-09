//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using NFL.Models.Player;
//using NFL.Models;

//namespace NFL.Controllers.api
//{
//    public class StadiumsController : ApiController
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();






//        // GET: api/Stadiums
//        public IQueryable<Stadium> GetStadium()
//        {
//            return db.Stadium;
//        }

//        // GET: api/Stadiums/5
//        [HttpGet]
//        public async Task<IHttpActionResult> GetStadium(int id)
//        {
//            var stadium = db.Stadium.Include(p => p.Address).SingleOrDefault(p => p.Id == id);
//            if (stadium == null && id == 0)
//            {
//                return NotFound();
//            }

//            return Ok(stadium);

//        }

//        // PUT: api/Stadiums/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutStadium(int id, Stadium stadium)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != stadium.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(stadium).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StadiumExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Stadiums
//        [ResponseType(typeof(Stadium))]
//        public async Task<IHttpActionResult> PostStadium(Stadium stadium)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Stadium.Add(stadium);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = stadium.Id }, stadium);
//        }

//        // DELETE: api/Stadiums/5
//        [ResponseType(typeof(Stadium))]
//        public async Task<IHttpActionResult> DeleteStadium(int id)
//        {
//            Stadium stadium = await db.Stadium.FindAsync(id);
//            if (stadium == null)
//            {
//                return NotFound();
//            }

//            db.Stadium.Remove(stadium);
//            await db.SaveChangesAsync();

//            return Ok(stadium);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool StadiumExists(int id)
//        {
//            return db.Stadium.Count(e => e.Id == id) > 0;
//        }
//    }
//}