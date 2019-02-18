using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public class AdvertisingDetails
    {


        public String AdevertizementID { get; set; }
        public String UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int VegitableID { get; set; }
        public DateTime PostDate { get; set; }
        public Boolean Status { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

    }
}