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
    
    public partial class Client_Registration
    {
        public Client_Registration()
        {
            this.Client_Service = new HashSet<Client_Service>();
        }
    
        public int Client_Id { get; set; }
        public string Client_Name { get; set; }
        public Nullable<int> Client_Cintact { get; set; }
        public string Client_Address { get; set; }
        public string Client_Email { get; set; }
    
        public virtual ICollection<Client_Service> Client_Service { get; set; }
    }
}
