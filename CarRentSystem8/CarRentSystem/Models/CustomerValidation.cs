using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rent_System.Models
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
        public class CustomerMetaData
        {
            [DisplayName("Customer Name")]
            public string CustomerName { get; set; }
            [DisplayName("Address")]
            public string CustomerAddress { get; set; }
            [DisplayName("Mobile Number")]
            public Nullable<int> CustomerMobile { get; set; }
        }
    }
}