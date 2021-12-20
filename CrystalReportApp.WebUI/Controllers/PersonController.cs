using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalReportApp.Core.Entities;
using CrystalReportApp.Core.Interfaces;
using CrystalReportApp.Infrastructure.Gateway;

namespace CrystalReportApp.WebUI.Controllers
{
    public class PersonController : Controller
    {
        
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }



        // GET: Person
        public ActionResult Index()
        {
            return View(_person.GetPersonList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = _person.GetPersonById(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,Phone,Email,BirthDate,Address")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                _person.Insert(personModel);
                _person.Commit();
                return RedirectToAction("Index");
            }

            return View(personModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = _person.GetPersonById(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,Phone,Email,BirthDate,Address")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                _person.Update(personModel);
                _person.Commit();
                return RedirectToAction("Index");
            }
            return View(personModel);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = _person.GetPersonById(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonModel personModel = _person.GetPersonById(id);
            _person.Delete(personModel);
            _person.Commit();
            return RedirectToAction("Index");
        }

    }
}
