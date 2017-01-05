﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NFL.Models.Player;
using NFL.Models.Players_Information;
using NFL.Models;
using System.Threading.Tasks;
using NFL.Models.Player.Profile;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Data.Entity.Migrations;
using WebGrease.Css.Extensions;

namespace NFL.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // private NFLDbContext _context = new NFLDbContext();

        //    // GET: Players
        //    public ActionResult Index()
        //    {
        //        var player = db.Player.Include(p => p.contactInformation).Include(p => p.OtherInformation).Include(p => p.personalInformation);
        //        return View(player.ToList());
        //    }

        //    // GET: Players/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Player player = db.Player.Find(id);
        //        if (player == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(player);
        //    }

        //    // GET: Players/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.playerId = new SelectList(db.ContactInformation, "playerId", "playerId");
        //        ViewBag.playerId = new SelectList(db.Information, "informationId", "Bio");
        //        ViewBag.playerId = new SelectList(db.PersonalInformation, "playerId", "FirstName");
        //        return View();
        //    }

        //    // POST: Players/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "playerId")] Player player)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Player.Add(player);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.playerId = new SelectList(db.ContactInformation, "playerId", "playerId", player.playerId);
        //        ViewBag.playerId = new SelectList(db.Information, "informationId", "Bio", player.playerId);
        //        ViewBag.playerId = new SelectList(db.PersonalInformation, "playerId", "FirstName", player.playerId);
        //        return View(player);
        //    }

        //    // GET: Players/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Player player = db.Player.Find(id);
        //        if (player == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.playerId = new SelectList(db.ContactInformation, "playerId", "playerId", player.playerId);
        //        ViewBag.playerId = new SelectList(db.Information, "informationId", "Bio", player.playerId);
        //        ViewBag.playerId = new SelectList(db.PersonalInformation, "playerId", "FirstName", player.playerId);
        //        return View(player);
        //    }

        //    // POST: Players/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "playerId")] Player player)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(player).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.playerId = new SelectList(db.ContactInformation, "playerId", "playerId", player.playerId);
        //        ViewBag.playerId = new SelectList(db.Information, "informationId", "Bio", player.playerId);
        //        ViewBag.playerId = new SelectList(db.PersonalInformation, "playerId", "FirstName", player.playerId);
        //        return View(player);
        //    }

        //    // GET: Players/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Player player = db.Player.Find(id);
        //        if (player == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(player);
        //    }

        //    // POST: Players/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Player player = db.Player.Find(id);
        //        db.Player.Remove(player);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}


        //Get All Players
        public List<Player> GetAllPlayers()
        {
            var players = _context.Player
                          .Include(p => p.personalInformation)
                          .Include(p => p.OtherInformation.Measurments)
                          .OrderBy(p => p.playerId).ToList();



            //Include Main Positions of Measurments

            var length = players.Count;
            for (int index = 0; index < length; index++)
            {
                var player = players.ElementAt(index);
                List<Measurments> measurments = _context.Measurments
                                            .Include(p => p.mainPosition)
                                            .Where(m => m.informationId == player.playerId).ToList();
                player.OtherInformation.Measurments = measurments;

                players.RemoveAt(index);
                players.Insert(index, player);

            }

            return players;
        }

        //Get Single Player
        [HttpGet]
        public Player GetSinglePlayer(int playerId)
        {
            var SinglePlayer = _context.Player
                               //Include Personal Information + Contact Information
                               .Include(p => p.personalInformation)

                               .Include(c => c.contactInformation)



                               //Include Addresses

                               .Include(a => a.Addresses)

                               //Include Player Information
                               .Include(i => i.OtherInformation)


                               //Include both Education and Measurments
                               .Include(e => e.OtherInformation.Educations)
                               .Include(m => m.OtherInformation.Measurments)

                               .SingleOrDefault(p => p.playerId == playerId);


            //clear Null contact information

            //playerDetails.contactInformation.Emails.RemoveAll(em => em.email == null);
            //playerDetails.contactInformation.Faxes.RemoveAll(fx => fx.Number == null);
            //playerDetails.contactInformation.PhoneNumbers.RemoveAll(ph => ph.Number == null);

            ////Include Emails
            //List<Email> emails = _context.Email.Where(e => e.contactInformation.playerId == SinglePlayer.playerId).ToList();
            ////Include Faxes
            //List<Fax> faxes = _context.Fax.Where(fx => fx.contactInformation.playerId == SinglePlayer.playerId).ToList();
            ////Include Emails
            //List<Phone> phones = _context.Phone.Where(ph => ph.contactInformation.playerId == SinglePlayer.playerId).ToList();

            //SinglePlayer.contactInformation = new ContactInformation
            //{
            //    Emails = new List<Email>(emails),
            //    Faxes = new List<Fax>(faxes),
            //    PhoneNumbers = new List<Phone>(phones),
            //};


            //Include Locations of Addresses
            List<Address> addresses = _context.Addresses.Include(c => c.Location)
                                      .Where(a => a.playerId == SinglePlayer.playerId).ToList();
            SinglePlayer.Addresses = addresses;


            //Include Main Positions of Measurments
            List<Measurments> measurments = _context.Measurments
                                            .Include(p => p.mainPosition)
                                            .Where(m => m.informationId == SinglePlayer.playerId).ToList();
            SinglePlayer.OtherInformation.Measurments = measurments;


            return SinglePlayer;
        }

        public ActionResult Index()
        {

            return View(GetAllPlayers());
        }


        public async Task<ActionResult> New()
        {
            var viewModel = new ViewModelProfile()
            {
                //Initialize Fields for Personal Information
                personalInformation = new PersonalInformation()
                {
                    BirthDate = DateTime.Now,
                },

                Address1 = new Address()
                {
                    Location = new Location()
                },
                States = _context.Cities.Select(c => c.State).Distinct().OrderBy(c => c).ToList(),


                //Initialize Fields for Contact Information
                Emails = new Email[2],
                Faxes = new Fax[2],
                Phones = new Phone[3],

            };
            ViewData["Title"] = "New";
            return View("Create/Profile", viewModel);
        }

        public async Task<ActionResult> Next(ViewModelProfile Profile)
        {
            //Validate City, State, and Zip code
            var InputCity = Profile.Address1.Location;

            //var cityInDB = _context.Cities.SingleOrDefault(c => c.ZipCode == InputCity.ZipCode
            //                                      && c.City.Equals(InputCity.City)
            //                                      && c.State.Equals(InputCity.State));

            if (!ModelState.IsValid)
            {
                //Profile.States = _context.Cities.Select(c => c.State).Distinct().OrderBy(c => c).ToList();
                return View("Create/Profile", Profile);
            }

            //Add city id from DB to Profile
            // Profile.Address1.locationId = cityInDB.Id;

            //Remove Old city object from Profile 
            //Profile.Address1.Location = null;

            //Adjust first and last name to be capitalised

            string givenString = Profile.personalInformation.FirstName;
            Profile.personalInformation.FirstName = char.ToUpper(givenString.First()) + givenString.Substring(1).ToLower();

            givenString = Profile.personalInformation.LastName;
            Profile.personalInformation.LastName = char.ToUpper(givenString.First()) + givenString.Substring(1).ToLower();


            //Adjust Address to be capitalised

            givenString = Profile.Address1.Street;
            Profile.Address1.Street = givenString.ToUpper();

            givenString = Profile.Address1.Location.City;
            Profile.Address1.Location.City = char.ToUpper(givenString.First()) + givenString.Substring(1).ToLower();


            Profile.Emails = Profile.Emails.Where(e => e.email != null && e.Type != null).ToArray();
            Profile.Faxes = Profile.Faxes.Where(f => f.Number != null && f.Type != null).ToArray();
            Profile.Phones = Profile.Phones.Where(p => p.Number != null && p.Type != null).ToArray();
            //Serialize the new profile
            var xmlserializer = new XmlSerializer(typeof(ViewModelProfile));
            var stringWriter = new StringWriter();
            xmlserializer.Serialize(stringWriter, Profile);
            TempData["Profile"] = stringWriter.ToString();





            var PlayerInfo = new ViewModelPlayerInfo()
            {

                //Initialize Fields for Player Information
                Education = new Education_History()
                {
                    Date = DateTime.Now
                },
                Measurment = new Measurments(),
                MainPositions = _context.MainPosition
                .OrderBy(p => p.Abbriviation)
                .ToList()

            };



            return View("Create/PlayerInformation", PlayerInfo);
        }

        //[HttpPost]
        public async Task<ActionResult> Add(ViewModelPlayerInfo PlayerInfo)
        {
            var xmlserializer = new XmlSerializer(typeof(ViewModelProfile));
            var stringReader = new StringReader(TempData["Profile"].ToString());
            var Profile = (ViewModelProfile)xmlserializer.Deserialize(stringReader);





            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModelPlayerInfo()
                {
                    Education = PlayerInfo.Education,
                    Measurment = PlayerInfo.Measurment,
                    MainPositions = _context.MainPosition
                   .OrderBy(p => p.Abbriviation).ToList()
                };


                TempData.Keep("Profile");
                ViewData["Title"] = "New";

                return View("Create/PlayerInformation", viewModel);
            }

            TempData.Remove("Profile");

            //Instanciate a new player then insert it to the database
            var newPlayer = new Player()
            {
                personalInformation = Profile.personalInformation,
                Addresses = new List<Address>(),


                OtherInformation = new Information()
                {
                    Bio = PlayerInfo.Bio,
                    Educations = new List<Education_History>(),
                    Measurments = new List<Measurments>()
                }
            };
            newPlayer.Addresses.Add(Profile.Address1);


            //Add Contact Information

            var contact = new ContactInformation()
            {
                Emails = Profile.Emails.ToList(),
                Faxes = Profile.Faxes.ToList(),
                PhoneNumbers = Profile.Phones.ToList()
            };
            newPlayer.contactInformation = contact;

            //Add Education and Measurments
            newPlayer.OtherInformation.Educations.Add(PlayerInfo.Education);
            newPlayer.OtherInformation.Measurments.Add(PlayerInfo.Measurment);

            if (newPlayer.playerId == 0)
            {
                _context.Entry(newPlayer).State = EntityState.Added;
                _context.SaveChanges();
            }



            return RedirectToAction("Index", "Players");
        }



        public async Task<ActionResult> Details(int Id)
        {
            var playerDetails = GetSinglePlayer(Id);
            // var positions = new List<Positions>() {
            //    Id = _context.MainPosition.Select(p => p.Id),
            //    positions = _context.MainPosition.Select(p => p.po)
            //};

            //positions.
            TempData["Positions"] = _context.MainPosition.OrderBy(m => m.Position).ToArray();
            if (playerDetails == null || Id == 0)
            {
                return HttpNotFound();
            }

            return View("Details/Details", playerDetails);
        }

        public async Task<ActionResult> Update(int id, Player player)
        {
            TempData.Keep("Positions");
            var playerFromDB = GetSinglePlayer(id);
            if (player != null && id != 0)
            {
                if (ModelState.IsValid)
                {
                    if (player.personalInformation != null)
                    {
                        //_context.Set<PersonalInformation>().AddOrUpdate(player.personalInformation);
                        _context.Set<PersonalInformation>().AddOrUpdate(player.personalInformation);
                        _context.SaveChanges();
                        return PartialView("Details/Profile/PersonalInformation", player.personalInformation);
                        // return Ok(player.personalInformation);
                    }
                    else if (player.Addresses != null)
                    {

                        player.Addresses.ForEach(a =>
                        {
                            _context.Set<Address>().AddOrUpdate(a);
                            _context.Set<Location>().AddOrUpdate(a.Location);
                        });
                        // player.Addresses.ForEach(a => _context.Entry(a).State = EntityState.Modified);
                        _context.SaveChanges();
                        return PartialView("Details/Profile/Address", player.Addresses);
                    }
                    else if(player.contactInformation != null)
                    {
                        var emails = player.contactInformation.Emails ?? new List<Email>();
                        var phones = player.contactInformation.PhoneNumbers ?? new List<Phone>();
                        var faxes = player.contactInformation.Faxes ?? new List<Fax>();


                        if (emails.Any())
                            emails.ForEach(em => _context.Set<Email>().AddOrUpdate(em));
                        if (phones.Any())
                            phones.ForEach(ph => _context.Set<Phone>().AddOrUpdate(ph));
                        if (faxes.Any())
                            faxes.ForEach(fx => _context.Set<Fax>().AddOrUpdate(fx));

                        player.contactInformation = new ContactInformation
                        {
                            Emails = emails,
                            PhoneNumbers = phones,
                            Faxes = faxes
                        };

                        _context.SaveChanges();
                        player.contactInformation.playerId = id;
                        return PartialView("Details/Profile/ContactInformation", player.contactInformation);
                    }
                    else if(player.OtherInformation != null)
                    {
                        var Info = player.OtherInformation;
                        //_context.Information.Attach(Info);
                        if (!String.IsNullOrEmpty(Info.Bio))
                        {
                            _context.Information.AddOrUpdate(Info);
                            _context.SaveChanges();
                            return PartialView("Details/Player_Information/Bio", player.OtherInformation);
                        }
                        else if (Info.Educations != null)
                        {
                            Info.Educations.ForEach(EDU => _context.Education.AddOrUpdate(EDU));
                            _context.SaveChanges();
                            return PartialView("Details/Player_Information/Education", player.OtherInformation);
                        }
                        else if (Info.Measurments != null)
                        {
                            
                            Info.Measurments.ForEach(MGR => _context.Measurments.AddOrUpdate(MGR));

                            _context.SaveChanges();
                            player.OtherInformation.Measurments = _context.Measurments
                                            .Include(p => p.mainPosition)
                                            .Where(m => m.informationId == id).ToList();
                            return PartialView("Details/Player_Information/Measurments", player.OtherInformation);
                        }
                        //Info.Educations = Info.Educations ?? new List<Education_History>();
                        //Info.Measurments = Info.Measurments ?? new List<Measurments>();
                        //player.OtherInformation = Info;
                       
                        
                    }
                }

                return new HttpStatusCodeResult(400, ModelState.ToString());

            }
            return HttpNotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var player = GetSinglePlayer(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return View(GetAllPlayers());
          
        }

    }

    public class Positions
    {
        public int Id { get; }
        public string Title { get;}
    }
}