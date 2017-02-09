using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NFL.Models.Player;
using NFL.Models;
using NFL.Models.Addresses;
using System.Data.Entity.Migrations;

namespace NFL.Models.Stadiums
{
    public class StadiumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stadiums
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var Addresses = db.PartyAddress.Where(addr => addr.party == "stadium")
                              .Join(db.Addresses, prt => prt.addressId, addr => addr.Id, (prt, addr) => new {  addr, prt });

            var stadiums = db.Stadium.ToList();



            stadiums.ForEach(std =>
            {
             
                var obj = Addresses.SingleOrDefault(prt => prt.prt.partyId == std.Id) ;
                std.Address = obj?.addr ?? new Address();
                //Addresses.Remove(obj);
            });


            return View(stadiums);
        }


        //GET: Stadiums/New
        [HttpGet]
        public async Task<ActionResult> New()
        {
            var stadium = new Stadium()
            {
                Address = new Address()
                {
                    Location = new Location()
                }
            };

             ViewData["Title"] = "New";
            return View("Create/New", stadium);
        }
        // GET: Stadiums/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stadium = getAStadium(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View("Details/Details",stadium);
        }

        // GET: Stadiums/Create
        [HttpPost]
        public async Task<ActionResult> Create(Stadium stadium)
        {
            if (ModelState.IsValid)
            {


                if (stadium.Address.Id == 0)
                    db.Entry(stadium.Address).State = EntityState.Added;

                if (stadium.Id == 0)
                    db.Entry(stadium).State = EntityState.Added;

                db.SaveChanges();
                var partyAddress = new partyAddress()
                {
                    partyId = stadium.Id,
                    addressId = stadium.Address.Id,
                    party = "stadium"
                };

                db.Entry(partyAddress).State = EntityState.Added;

                db.SaveChanges();

                return RedirectToAction("Index", "Stadiums");
            }
            return View("Create/New", stadium);
        }

        // PUT: Stadiums/Update/3
        [HttpPut]
        public async Task<ActionResult> Update(int Id, Stadium stadium)
        {
            var stadiumFromDB = getAStadium(Id);

            if (stadium != null && Id != 0)
            {
                if (ModelState.IsValid)
                {
                    db.Set<Stadium>().AddOrUpdate(stadium);


                    //Updating ONLY address
                    db.Set<Address>().AddOrUpdate(stadium.Address);

                    db.SaveChanges();

                    return PartialView("Details/Details", stadium);
                }

                return new HttpStatusCodeResult(400, "Invalid data");
            }

            return HttpNotFound();
        }
        // POST: Stadiums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,addressId,DateEstablished,Capacity")] Stadium stadium)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stadium.Add(stadium);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

            //    ViewBag.addressId = new SelectList(db.Addresses, "Id", "Street", stadium.addressId);
            //    return View(stadium);
            //}

            // GET: Stadiums/Edit/5
            //public async Task<ActionResult> Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    Stadium stadium = await db.Stadium.FindAsync(id);
            //    if (stadium == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    ViewBag.addressId = new SelectList(db.Addresses, "Id", "Street", stadium.addressId);
            //    return View(stadium);
            //}

            // POST: Stadiums/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<ActionResult> Edit([Bind(Include = "Id,addressId,DateEstablished,Capacity")] Stadium stadium)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Entry(stadium).State = EntityState.Modified;
            //        await db.SaveChangesAsync();
            //        return RedirectToAction("Index");
            //    }
            //    ViewBag.addressId = new SelectList(db.Addresses, "Id", "Street", stadium.addressId);
            //    return View(stadium);
            //}

            // GET: Stadiums/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var stadium = getAStadium(id);

            if (stadium == null)
            {
                return HttpNotFound();
            }



            var partyAddress = db.PartyAddress
                .SingleOrDefault(prt => prt.partyId == stadium.Id && prt.party == "stadium");
            
            db.Addresses.Remove(stadium.Address);
            db.PartyAddress.Remove(partyAddress);
            db.Stadium.Remove(stadium);
            db.SaveChanges();

            return RedirectToAction("Index", "Stadiums");
        }

        // POST: Stadiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var stadium = await db.Stadium.FindAsync(id);
            db.Stadium.Remove(stadium);
            await db.SaveChangesAsync();
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


        public Stadium getAStadium(int Id)
        {
            var stadium = db.Stadium.SingleOrDefault(std => std.Id == Id);

            stadium.Address = db.Addresses.Include(c => c.Location)
                           .Join(db.PartyAddress, add => add.Id, prt => prt.addressId, (add, prt) => new { add, prt })
                           .SingleOrDefault(p => p.prt.partyId == stadium.Id && p.prt.party == "stadium")?.add ?? new Address();


            return stadium;
        }
    }
}
