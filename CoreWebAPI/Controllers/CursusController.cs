using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoreWebAPI.Data;
using CoreWebAPI.Helpers;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {


        SqlConnection conn = new SqlConnection(
@"Data Source=.\sqlexpress;
                      Database=School;
                      Integrated security=true;"
);

        public IActionResult Get()
        {
            List<Cursus> Cursussen = new List<Cursus>();
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                string sql = "Select * from cursussen";
                SqlCommand cmd = new SqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cursus cursus = new Cursus
                    {
                        Id = rdr.GetInt32(0),
                        Cursusnaam = rdr.GetString(1),
                        Inschrijvingsgeld = rdr.GetInt32(2)
                    };
                    Cursussen.Add(cursus);
                }
            }
            catch
            {
                return BadRequest();
            }
            finally
            {
                //geef resources vrij
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
            return Ok(Cursussen);
        }


        

    }
}