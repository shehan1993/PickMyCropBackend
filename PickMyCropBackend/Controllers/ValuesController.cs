using PickMyCropBackend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickMyCropBackend.Controllers
{
    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        String CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        // GET api/values
        public ArrayList Get()
        {
            ArrayList al = new ArrayList();
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("checkPro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parm = new SqlParameter("@img", SqlDbType.VarChar,500);
                    parm.Direction = ParameterDirection.Output; // This is important!
                    cmd.Parameters.Add(parm);

                    parm  = new SqlParameter("@price", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    parm = new SqlParameter("@Amount_Kg", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    parm = new SqlParameter("@FirstName", SqlDbType.VarChar,50);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    parm = new SqlParameter("@Vegitable_Name", SqlDbType.VarChar,50);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    parm = new SqlParameter("@farmerRating", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                    

                    con.Open();
                    int k = cmd.ExecuteNonQuery();
                    //SqlDataReader reader = cmd.ExecuteReader();

                    //con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DashboardAdvertise DashbordObjects = new DashboardAdvertise();
                        DashbordObjects.img = reader.GetString(reader.GetOrdinal("img"));
                        DashbordObjects.price = reader.GetInt32(reader.GetOrdinal("price"));
                        DashbordObjects.amount = reader.GetInt32(reader.GetOrdinal("amount"));
                        DashbordObjects.farmer = reader.GetString(reader.GetOrdinal("farmer"));
                        DashbordObjects.veg = reader.GetString(reader.GetOrdinal("veg"));
                        DashbordObjects.farmerRating = reader.GetInt32(reader.GetOrdinal("farmerRating"));
                        //DashbordObjects.img = cmd.Parameters["@img"].ToString();
                        //DashbordObjects.price = Convert.ToInt32( cmd.Parameters["@price"].Value.ToString());
                        //DashbordObjects.amount = Convert.ToInt32(cmd.Parameters["@Amount_Kg"].Value.ToString());
                        //DashbordObjects.farmer = cmd.Parameters["@FirstName"].ToString();
                        //DashbordObjects.veg = cmd.Parameters["@Vegitable_Name"].ToString();
                        //DashbordObjects.farmerRating = Convert.ToInt32(cmd.Parameters["@farmerRating"].Value.ToString());
                        al.Add(DashbordObjects);
                    }
                    
                }
                con.Close();
            }
            
            return al; ;
        }

      



// GET api/values/5
public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
