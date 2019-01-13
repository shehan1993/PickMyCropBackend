using MySql.Data.MySqlClient;
using PickMyCropBackend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PickMyCropBackend.Controllers
{
    [AllowAnonymous]
    public class FarmerDetailController : ApiController
    {
        //string connString = "SERVER=www.xtreamehost.com;PORT=3306;DATABASE=kamalanath_farmers;UID=farmerproject;PASSWORD=farmer@2018;";
        string connString = "SERVER=gator3272.hostgator.com;PORT=3306;DATABASE=kamalana_farmers;UID=kamalana_farmers;PASSWORD=farmers;";


        [Route("GetUser")]
        public FarmerDetails GetUser()
        {
            string userId = ((System.Security.Claims.ClaimsIdentity)User.Identity).
                                FindFirst("UserId").Value;
            FarmerDetails person = new FarmerDetails();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM kamalanath_farmers.FarmerDetails WHERE farmerId=1; ", con);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kamalana_farmers.FarmerDetails WHERE UserId='" + userId + "'; ", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    person.FarmerId = reader.GetInt32(reader.GetOrdinal("FarmerId"));
                    person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    person.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    person.Email = reader.GetString(reader.GetOrdinal("Email"));
                    person.ContactNumber = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo"));
                    person.AddressLine_1 = reader.IsDBNull(reader.GetOrdinal("AddressLine1")) ? null : reader.GetString(reader.GetOrdinal("AddressLine1"));
                    person.AddressLine_2 = reader.IsDBNull(reader.GetOrdinal("AddressLine2")) ? null : reader.GetString(reader.GetOrdinal("AddressLine2"));
                    person.City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City"));
                    person.AboutMe = reader.IsDBNull(reader.GetOrdinal("AboutMe")) ? null : reader.GetString(reader.GetOrdinal("AboutMe"));
                    person.roleType= reader.IsDBNull(reader.GetOrdinal("RoleType")) ? 9 : reader.GetInt32(reader.GetOrdinal("RoleType"));
                    
                    return person;
                }

            }

            return person;

        }

        [HttpPost]
        [Route("UpdateUser")]
        public bool UpdateUser(FarmerDetails person)
        {
          
            string userId = ((System.Security.Claims.ClaimsIdentity)User.Identity).
                                FindFirst("UserId").Value;
            //FarmerDetails person = new FarmerDetails();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                //string temp = UPDATE `kamalanath_farmers`.`UserDetailsTable` SET `FirstName` = 'Tharindu', `LastName` = 'Dananjaya', `AddressLine_1` = 'Temp', `AddressLine_2` = 'Temp2', `City` = 'Matara', `RollId` = '1', `Phone` = '74747744', `Description` = 'I\'m WEll ' WHERE;
                string temp = "UPDATE `kamalana_farmers`.`FarmerDetails` SET `FirstName` = '" + person.FirstName +
                    "',`LastName` = '" + person.LastName +
                    "',`UserName` = '" + person.UserName +
                    "',`Email` = '" + person.Email +
                    "',`ContactNo` = '" + person.ContactNumber +
                    "',`AddressLine1` = '" + person.AddressLine_1 +
                    "',`AddressLine2` = '" + person.AddressLine_2 +
                    "',`City` = '" + person.City +
                    "',`AboutMe` = '" + person.AboutMe +
                    "',`RoleType` = '" + person.roleType +
                    "' WHERE (`UserId` = '" + userId + "');";
                
                MySqlCommand cmd = new MySqlCommand(temp, con);
               
                con.Open();
                cmd.ExecuteNonQuery();
         

            }

            return true;

        }

        [HttpPost]
        [Route("UpdateUserPhoto")]
        public bool UpdateUserPhoto(string path)
        {
            string val=ImageToBase64(path);
            //FarmerDetails person = new FarmerDetails();
            //using (MySqlConnection con = new MySqlConnection(connString))
            //{
            //    //string temp = UPDATE `kamalanath_farmers`.`UserDetailsTable` SET `FirstName` = 'Tharindu', `LastName` = 'Dananjaya', `AddressLine_1` = 'Temp', `AddressLine_2` = 'Temp2', `City` = 'Matara', `RollId` = '1', `Phone` = '74747744', `Description` = 'I\'m WEll ' WHERE;
            //    string temp = "UPDATE `kamalana_farmers`.`FarmerDetails` SET `FirstName` = '" + person.FirstName +
            //        "',`LastName` = '" + person.LastName +
            //        "',`UserName` = '" + person.UserName +
            //        "',`First` = '" + person.Email +
            //        "',`ContactNo` = '" + person.ContactNumber +
            //        "',`AddressLine1` = '" + person.AddressLine_1 +
            //        "',`AddressLine2` = '" + person.AddressLine_2 +
            //        "',`City` = '" + person.City +
            //        "',`AboutMe` = '" + person.AboutMe +
            //        "',`FilePath` = '" + val +
            //        "' WHERE (`farmerId` = '" + person.FarmerId + "');";

            //    MySqlCommand cmd = new MySqlCommand(temp, con);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
                

            //}

            return true;

        }
        public static string ImageToBase64(string path)
        {
            //string path = "D:/photo/a.jpg";
           // var newstr = path.Replace(@"\\", @"/");
            string[] a = path.Split(new[] { '\\', '\\' });
            string temp=null;
            for (var i = 0; i < a.Length; i++) {
                if (i == 0)
                {
                    temp = a[i];
                }
                else
                {
                    temp = temp + "/" + a[i];
                }
            }

            byte[] imageByteData = System.IO.File.ReadAllBytes(temp);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            return "data:image/jpg;base64," + imageBase64Data;
        }

    }
}