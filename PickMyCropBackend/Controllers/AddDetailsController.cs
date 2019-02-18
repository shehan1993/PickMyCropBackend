using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickMyCropBackend.Models;
using System.Security.Claims;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections;

namespace PickMyCropBackend.Controllers
{
    public class AddDetailsController : ApiController
    {
        string connString = "SERVER=gator3272.hostgator.com;PORT=3306;DATABASE=kamalana_farmers;UID=kamalana_farmers;PASSWORD=farmers;";
        AdvertisingDetails Advertisement;

        [AllowAnonymous]
        // GET api/Advertising/{id}/{buyerId}
        [Route("api/AddDetails/{vegId}/{buyerID}/{amountOfKg}")]
        public ArrayList Get(int vegId, String buyerID, Double amountOfKg)
        {
            Dictionary<String, AdvertisingDetails> farmersAdvDetailsDic = new Dictionary<String, AdvertisingDetails>();
            //var identityClaims = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identityClaims.Claims;
            //var username = identityClaims.FindFirst("UserName").Value;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kamalana_farmers.FarmersAdvertisingTable WHERE VegitableID = " + vegId + "", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Advertisement = new AdvertisingDetails();
                    Advertisement.AdevertizementID = reader.GetString(reader.GetOrdinal("AdevertizementID"));
                    Advertisement.UserId = reader.GetString(reader.GetOrdinal("UserId"));
                    String Location = reader.GetString(reader.GetOrdinal("Location"));
                    String[] x = Location.Split(',');
                    Advertisement.Latitude = Convert.ToDouble(x[0]);
                    Advertisement.Longitude = Convert.ToDouble(x[1]);
                    Advertisement.VegitableID = reader.GetInt32(reader.GetOrdinal("VegitableID"));
                    Advertisement.PostDate = reader.GetDateTime(reader.GetOrdinal("PostDate"));
                    //Advertisement.Status = reader.GetBoolean(reader.GetOrdinal("Status"));
                    Advertisement.Weight = reader.GetDouble(reader.GetOrdinal("Weight"));
                    Advertisement.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    farmersAdvDetailsDic.Add(Advertisement.AdevertizementID, Advertisement);
                }
                con.Close();
            }

            Position buyerPosition = new Position();

            using (MySqlConnection con = new MySqlConnection(connString))
            {

                buyerPosition.id = buyerID;
                MySqlCommand cmd = new MySqlCommand("SELECT Location FROM kamalana_farmers.UserDetailsTable WHERE UserID = " + buyerID + " AND RollID = 2", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String Location = reader.GetString(reader.GetOrdinal("Location"));
                    String[] x = Location.Split(',');
                    buyerPosition.Latitude = Convert.ToDouble(x[0]);
                    buyerPosition.Longitude = Convert.ToDouble(x[1]);
                }
                con.Close();
            }

            FindFarmers ff = new FindFarmers(farmersAdvDetailsDic, buyerPosition);

            ArrayList DataArrayOfFarmers = new ArrayList();
            DataArrayOfFarmers = ff.getFarmersGroup(amountOfKg);

            return DataArrayOfFarmers;
        }
    }
}
