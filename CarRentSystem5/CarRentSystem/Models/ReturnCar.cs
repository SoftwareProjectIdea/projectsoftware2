//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_Rent_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReturnCar
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Date { get; set; }
        public int DelayTime { get; set; }
        public int Fine { get; set; }
    }
}
