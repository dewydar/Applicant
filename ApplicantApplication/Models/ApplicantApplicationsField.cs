//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicantApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicantApplicationsField
    {
        public int ID { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> ApplicationsFieldId { get; set; }
    
        public virtual Applicant Applicant { get; set; }
        public virtual ApplicationsField ApplicationsField { get; set; }
    }
}
