using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public int ContactNumber { get; set; }
        public string AddressLine_1 { get; set; }
        public String AddressLine_2 { get; set; }
        public String City { get; set; }
        public String Details { get; set; }
        public String Image { get; set; }
        public String LoggedOn { get; set; }

    }
}