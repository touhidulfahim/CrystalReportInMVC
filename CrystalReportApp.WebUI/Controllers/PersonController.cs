using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReportApp.Core.Entities;
using CrystalReportApp.Core.Interfaces;
using CrystalReportApp.Infrastructure.Gateway;
using CrystalReportApp.WebUI.Models;

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







        public ActionResult ShowCustomerList()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "rptPersonData.rpt"));
            rd.SetDataSource(_person.GetPersonList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //stream.Flush();
            //stream.Close();
            //stream.Dispose();

            stream.Seek(0, SeekOrigin.Begin);


            string DirectoryPath = Request.PhysicalApplicationPath + "/OpenPDF/";
            string fileName = "/OpenPDF/" + "_PersonData.pdf";
            if (!System.IO.Directory.Exists(DirectoryPath))
            {
                System.IO.Directory.CreateDirectory(DirectoryPath);
            }


            //Preview
            return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
            
        }






        public void LoadReportData()
        {
            ReportParams<PersonModel> reportParams=new ReportParams<PersonModel>();
            reportParams.DataSource=_person.GetPersonList();
            reportParams.ReportFileName = "rptPersonData.rpt";
            this.HttpContext.Session["ReportType"] = "PersonData";
            this.HttpContext.Session["ReportParam"] = reportParams;

        }















    }
}
