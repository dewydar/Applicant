using ApplicantApplication.Models;
using ApplicantApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicantApplication.Controllers
{
    public class ApplicantController : Controller
    {
        static ApplicantEntities db = new ApplicantEntities();
        static ApplicantVM vm = new ApplicantVM();
        // GET: Applicant
        public ActionResult AllApplicant()
        {
            vm.Applicants = db.Applicants.ToList();
            ViewBag.Gender = new SelectList(db.Genders.ToList(), "ID", "Name");
            ViewBag.CertificationTypes = new SelectList(db.CertificationTypes.ToList(), "ID", "Name");
            ViewBag.CertificationSpecifics = new SelectList(db.CertificationSpecifics.ToList(), "ID", "Name");
            vm.ApplicationsFields = db.ApplicationsFields.ToList();
            return View(vm);
        }
        [HttpPost]
        public ActionResult CreateApplicant(ApplicantVM applicant, DateTime BirthDate)
        {
            if (ModelState.IsValid)
            {
                applicant.NewApplicant.BirthDate = BirthDate;
                db.Applicants.Add(applicant.NewApplicant);
                db.SaveChanges();
                applicant.ApplicantQualification.ApplicantId = applicant.NewApplicant.ID;
                db.ApplicantQualifications.Add(applicant.ApplicantQualification);
                if (applicant.AreChecked.Count() > 0)
                {
                    for (int i = 0; i < applicant.AreChecked.Count(); i++)
                    {
                        ApplicantApplicationsField applicantField = new ApplicantApplicationsField();
                        applicantField.ApplicationsFieldId= applicant.AreChecked[i];
                        applicantField.ApplicantId = applicant.NewApplicant.ID;
                        db.ApplicantApplicationsFields.Add(applicantField);
                    }
                }
                db.SaveChanges();
                //return RedirectToAction(nameof(AllApplicant));
                //return PartialView("_PartialAddApplicant", applicant);
            }
            return RedirectToAction(nameof(AllApplicant));
        }
    }
}