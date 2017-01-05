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
using NFL.Models.Player;
using NFL.Models;
using NFL.Models.Players_Information;
using System.Data.Entity.Migrations;

namespace NFL.Controllers.Api
{

    public class PlayersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public List<Player> GetAllPlayers()
        {
            var players = db.Player
                       .Include(p => p.personalInformation)
                       .Include(p => p.OtherInformation.Measurments)
                       .OrderBy(p => p.playerId).ToList();



            //Include Main Positions of Measurments

            var length = players.Count;
            for (int index = 0; index < length; index++)
            {
                var player = players.ElementAt(index);
                List<Measurments> measurments = db.Measurments
                                            .Include(p => p.mainPosition)
                                            .Where(m => m.informationId == player.playerId).ToList();
                player.OtherInformation.Measurments = measurments;

                players.RemoveAt(index);
                players.Insert(index, player);

            }

            return players;
        }


        public Player GetSinglePlayer(int id)
        {

            var player = db.Player
                              //Include Personal Information + Contact Information
                              .Include(p => p.personalInformation)

                              .Include(c => c.contactInformation)
                              .Include(e => e.contactInformation.Emails)
                              .Include(f => f.contactInformation.Faxes)
                              .Include(p => p.contactInformation.PhoneNumbers)


                              //Include Addresses
                              .Include(a => a.Addresses)


                              //Include Player Information
                              .Include(i => i.OtherInformation)


                              //Include both Education and Measurments
                              .Include(e => e.OtherInformation.Educations)
                              .Include(m => m.OtherInformation.Measurments)

                              .SingleOrDefault(p => p.playerId == id);


            //clear Null contact information

            //playerDetails.contactInformation.Emails.RemoveAll(em => em.email == null);
            //playerDetails.contactInformation.Faxes.RemoveAll(fx => fx.Number == null);
            //playerDetails.contactInformation.PhoneNumbers.RemoveAll(ph => ph.Number == null);

            //Include Emails
            //List<Email> emails = db.Email.Where(e => e.contactInformationId == player.playerId).ToList();
            ////Include Faxes
            //List<Fax> faxes = db.Fax.Where(fx => fx.contactInformationId == player.playerId).ToList();
            ////Include Emails
            //List<Phone> phones = db.Phone.Where(ph => ph.contactInformationId == player.playerId).ToList();

            //player.contactInformation = new ContactInformation
            //{
            //    Emails = new List<Email>(emails),
            //    Faxes = new List<Fax>(faxes),
            //    PhoneNumbers = new List<Phone>(phones),
            //};


            //Include Locations of Addresses
            List<Address> addresses = db.Addresses.Include(c => c.Location)
                                      .Where(a => a.playerId == player.playerId).ToList();
            player.Addresses = addresses;


            //Include Main Positions of Measurments
            List<Measurments> measurments = db.Measurments
                                            .Include(p => p.mainPosition)
                                            .Where(m => m.informationId == player.playerId).ToList();
            player.OtherInformation.Measurments = measurments;

            return player;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            return Ok(GetAllPlayers());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            var player = GetSinglePlayer(id);
            if (player == null || id == 0)
                return NotFound();
            return Ok(player);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, Player player)
        {
            var playerFromDB = GetSinglePlayer(id);
            if (player != null || id != 0)
            {
                if (ModelState.IsValid)
                {
                    if (player.personalInformation != null)
                    {
                        db.Set<PersonalInformation>().AddOrUpdate(player.personalInformation);
                        db.SaveChanges();

                        return Ok(player.personalInformation);
                    }
                    else if (player.Addresses != null)
                    {
                        player.Addresses.ForEach(a => db.Set<Address>().AddOrUpdate(a));
                        db.SaveChanges();
                        return Ok(player.Addresses);
                    }
                    else if (player.OtherInformation != null)
                    {
                        var Info = player.OtherInformation;
                        //db.Information.Attach(Info);
                        if (!String.IsNullOrEmpty(Info.Bio))
                            db.Information.AddOrUpdate(Info);
                        //db.Entry(Info).Property(I => I.Bio).IsModified = true;
                        else if (Info.Educations != null)
                        {
                            Info.Educations.ForEach(EDU => db.Education.AddOrUpdate(EDU));
                        }
                        else if (Info.Measurments != null)
                        {
                            Info.Measurments.ForEach(MGR => db.Measurments.AddOrUpdate(MGR));
                        }

                        db.SaveChanges();
                        return Ok(player.OtherInformation);
                    }
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.playerId)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Player.Add(player);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = player.playerId }, player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> DeletePlayer(int id)
        {
            Player player = await db.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Player.Remove(player);
            await db.SaveChangesAsync();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Player.Count(e => e.playerId == id) > 0;
        }
    }
}