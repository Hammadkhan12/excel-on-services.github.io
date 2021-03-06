//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Excel_On_Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ApplyOnline
    {
        [Required(ErrorMessage = "First Name must be filled")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Last Name must be filled")]
        public string Last_Name { get; set; }
        public string Father_Name { get; set; }
        [Required(ErrorMessage = "N-I-C must be filled")]
        public string N_I_C { get; set; }
        [Required(ErrorMessage = "Gender must be filled")]
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Result { get; set; }
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Contact No must be filled")]
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "CV must be filled")]
        public string CV { get; set; }
    }
}
