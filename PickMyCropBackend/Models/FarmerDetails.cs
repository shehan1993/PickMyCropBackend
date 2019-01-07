using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public class FarmerDetails
    {
        public int FarmerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string pathValue { get; set; }
     
        public string Email { get; set; }
        //public int RollId { get; set; }
        public string ContactNumber { get; set; }
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        public string City { get; set; }
        public string AboutMe { get; set; }
    }
}