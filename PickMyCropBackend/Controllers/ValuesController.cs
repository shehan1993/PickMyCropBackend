using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickMyCropBackend.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        String CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        // GET api/values
        public String Get()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from employees", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    return reader.GetString(reader.GetOrdinal("Name"));
                }

            }
            return "okay";
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
