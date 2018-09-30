using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickMyCropBackend.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace PickMyCropBackend.Controllers
{
    [AllowAnonymous]
    public class DashboardAdvertiseController : ApiController
    {
        String CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DashboardAdvertise DashbordObjects;

        // GET api/DashboardAdvertise
        public ArrayList Get()
        {
            ArrayList al = new ArrayList();
            
            

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 10 a.Photo_URL AS img, a.Price_PKG AS price, a.Amount_Kg AS amount, t.FirstName AS farmer, v.Vegitable_Name AS veg, r.Mark / r.Count AS farmerRating from[dbo].[Advertisement_List] a JOIN[dbo].[Table] t ON a.Owner_Id = t.Id JOIN[dbo].[Vegitable_List] v ON a.Vegitable_Id = v.Vegitable_Id JOIN[dbo].[Rating] r ON a.Owner_Id = r.Id ORDER BY  a.Post_Date DESC; ", con);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DashbordObjects = new DashboardAdvertise();
                    DashbordObjects.img = reader.GetString(reader.GetOrdinal("img"));
                    DashbordObjects.price = reader.GetInt32(reader.GetOrdinal("price"));
                    DashbordObjects.amount = reader.GetInt32(reader.GetOrdinal("amount"));
                    DashbordObjects.farmer = reader.GetString(reader.GetOrdinal("farmer"));
                    DashbordObjects.veg = reader.GetString(reader.GetOrdinal("veg"));
                    DashbordObjects.farmerRating = reader.GetInt32(reader.GetOrdinal("farmerRating"));
                    al.Add(DashbordObjects);
                }
                con.Close();
            }

            return al;
        }


    }
}
