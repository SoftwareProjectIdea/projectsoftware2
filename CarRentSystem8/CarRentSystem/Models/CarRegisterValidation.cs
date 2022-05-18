using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rent_System.Models
{
    [MetadataType(typeof(CarRegisterMetaData))]
    public partial class CarRegister
    {
        public class CarRegisterMetaData
        {
            [DisplayName("Car Number")]
            public string CarNumber { get; set; }
            [DisplayName("Brand")]
            public string CarBrand { get; set; }
            [DisplayName("Model")]
            public string CarModel { get; set; }
            [DisplayName("Available")]
            public string Available { get; set; }
        }

    }
}