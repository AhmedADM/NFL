using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NFL;
using NFL.Models.Staff;
using NFL.Models.Employees;
using NFL.Models.Profile;
using System.Data.Entity.Migrations;
using NFL.Models.Experiences;
using NFL.Models;

namespace NFL.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public Employee getSaff(int Id)
        {
            var staff = _context.Employee
                .Include(emp => emp.personalInformation)
                .Include(emp => emp.contactInformation)
                .Include(emp => emp.WorkExperience)
                .SingleOrDefault(emp => emp.Id == Id);

            return staff;
        }

        // GET: Staffs
        public async Task<ActionResult> Index()
        {
            var staffs = new List<Staff>();

            staffs = _context.Staff

                    //Including Front Office Personal Information
                    .Include(S => S.frontOffice.CEO.personalInformation)
                    .Include(S => S.frontOffice.OwnerCEO.personalInformation)
                    .Include(S => S.frontOffice.Precident.personalInformation)
                    .Include(S => S.frontOffice.SpecialAssistence.personalInformation)


                    //Including Offensive Coached Personal Information

                    .Include(S => S.offensiveCoaches.OffensiveCoordinator.personalInformation)
                    .Include(S => S.offensiveCoaches.QuarterbackCoach.personalInformation)

                    .ToList();
            return View(staffs);
        }

        // GET: Staffs/Details/5
        public async Task<ActionResult> Details(int id)
        {

            var staff = getSaff(id);

            if(staff == null || id == 0)
            {
                return HttpNotFound();
            }

            return View("Details/Details", staff);
        }

        // GET: Staffs/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Include = "Id")] Staff staff)
        {
 

            return View();
        }

        // GET: Staffs/Edit/5
        public async Task<ActionResult> Update(Employee employee)
        {
            if (employee.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    if(employee.personalInformation != null)
                    {
                        _context.Set<PersonalInformation>().AddOrUpdate(employee.personalInformation);
                        _context.SaveChanges();
                        return View("Details/Profile/PersonalInformation", employee.personalInformation);
                    }

                    else if(employee.contactInformation != null)
                    {

                        _context.Set<ContactInformation>().AddOrUpdate(employee.contactInformation);
                        employee.contactInformation.Emails = employee.contactInformation.Emails ?? new List<Email>();
                        employee.contactInformation.PhoneNumbers = employee.contactInformation.PhoneNumbers ?? new List<Phone>();
                        employee.contactInformation.Faxes = employee.contactInformation.Faxes ?? new List<Fax>();

                        _context.SaveChanges();
                        return PartialView("Details/Profile/ContactInformation", employee.contactInformation);
                    }

                    else if(employee.WorkExperience != null)
                    {
                        var experience = employee.WorkExperience.Where(exp => exp != null).ToList();

                        experience.ForEach(exp =>
                            _context.Set<Experience>().AddOrUpdate(exp)
                            );
                        //_context.Set<Experience>().AddOrUpdate(experience);
                        //employee.WorkExperience.ForEach(xp =>
                        // _context.Set<Experience>().AddOrUpdate(xp));
                        _context.SaveChanges();
                        //return View("Details/Experience/Experience", employee.contactInformation);
                        return PartialView("Details/Experience/Experience", experience);
                    }
                }
                return new HttpStatusCodeResult(400, "Invalid data");
            }
            return HttpNotFound();
        }

      
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(staff).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
           
            return View();
        }



    }
}
