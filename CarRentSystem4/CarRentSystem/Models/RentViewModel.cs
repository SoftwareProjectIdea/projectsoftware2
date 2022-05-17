using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_System.Models
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public int CustomerId { get; set; }
        public int Fee { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Available { get; set; }
    }
}