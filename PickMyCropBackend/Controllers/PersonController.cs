using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickMyCropBackend.Models;
using MySql.Data.MySqlClient;
using System.Security.Claims;
using System.Collections;

namespace PickMyCropBackend.Controllers
{
 [AllowAnonymous]   
    public class PersonController : ApiController
    {
        String CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string connString = "SERVER=www.xtreamehost.com;PORT=3306;DATABASE=;UID=;PASSWORD=;";
        Person person;

        // GET api/Person
        public Person Get(int id)
        {
           person = new Person();
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable < Claim > claims= identityClaims.Claims;
            var username=identityClaims.FindFirst("UserName").Value;
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


        public String Get()
        {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT `RollIdTable`.`Id`, `RollIdTable`.`RollName` FROM `kamalanath_farmers`.`RollIdTable`; ", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    return reader.GetString(reader.GetOrdinal("Id"));
                }

            }
            return "okay";
        }

        public void Post([FromBody]Person person)
        {
            int maxId = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select MAX(id) from [dbo].[Table] ", con);

                try {
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        maxId = reader.GetInt32(0);
                    }

                    maxId = maxId + 1;
                    con.Close();

                    cmd = new SqlCommand("Insert_Person", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", maxId);
                    cmd.Parameters.AddWithValue("FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("LastName", person.LastName);
                    cmd.Parameters.AddWithValue("Email", person.Email);
                    cmd.Parameters.AddWithValue("ContactNumber", person.ContactNumber);
                    cmd.Parameters.AddWithValue("AddressLine_1", person.AddressLine_1);
                    cmd.Parameters.AddWithValue("AddressLine_2", person.AddressLine_2);
                    cmd.Parameters.AddWithValue("City", person.City);
                    cmd.Parameters.AddWithValue("Details", person.Details);
                    cmd.Parameters.AddWithValue("Image", person.Image);
                    
                    con.Open();
                    int k = cmd.ExecuteNonQuery();


                } catch(Exception ex){

                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    con.Close();
                }

            }



        }

    }



}
