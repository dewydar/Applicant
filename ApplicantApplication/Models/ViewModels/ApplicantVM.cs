using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantApplication.Models.ViewModels
{
    public class ApplicantVM
    {
        public List<Applicant> Applicants { get; set; }
        public List<ApplicationsField> ApplicationsFields { get; set; }
        public List<ApplicantQualification> ApplicantQualifications { get; set; }
        public Applicant NewApplicant { get; set; }
        public ApplicantApplicationsField ApplicantApplicationsField { get; set; }
        public ApplicantQualification ApplicantQualification { get; set; }
        public List<int> AreChecked { get; set; }
    }
}