using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickMyCropBackend.Models;

namespace PickMyCropBackend.Controllers
{
    
    public class PersonController : ApiController
    {
        String CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        Person person;

        // GET api/Person
        public Person Get(int id)
        {
           person = new Person();
            

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Table] where id="+id +"" , con);
               
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    person.ID = reader.GetInt32(reader.GetOrdinal("id"));
                    person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    person.Email = reader.GetString(reader.GetOrdinal("Email"));
                    person.ContactNumber = reader.GetInt32(reader.GetOrdinal("ContactNumber"));
                    person.AddressLine_1 = reader.GetString(reader.GetOrdinal("AddressLine_1"));
                    person.AddressLine_2 = reader.GetString(reader.GetOrdinal("AddressLine_2"));
                    person.City = reader.GetString(reader.GetOrdinal("City"));              
                    person.Details = reader.GetString(reader.GetOrdinal("Details"));
                    person.Image = reader.GetString(reader.GetOrdinal("Image"));                  
                }
                con.Close();
            } 
            return person;
        }

        public void Post([FromBody]Person person)
        {
            int maxId = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select MAX(id) from [dbo].[Table] ", con);

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    maxId = reader.GetInt32(0);
                }
               

                maxId = maxId + 1;


            }



        }

    }



}
