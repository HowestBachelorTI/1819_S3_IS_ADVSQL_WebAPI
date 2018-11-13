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
        CursusData _cursusData;
        public CursusController()
        {
            _cursusData = new CursusData(
                                new SqlHelper(
                                    new SqlConnection(@"Data Source=.\sqlexpress;
                                            Database=School;
                                            Integrated security=true;"
                                                       )));
        }

        public IActionResult Get()
        {
            List<Cursus> Cursussen = new List<Cursus>();
            try
            {
                Cursussen = _cursusData.ConvertToList("Select * from cursussen");
            }
            catch { return BadRequest(); }
            return Ok(Cursussen);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cursus cursus = null;
            try
            {
                SqlParameter param = new SqlParameter("@cursusnr", id);
                cursus = _cursusData.ConvertToEntity("Select * from cursussen where cursusnr = @cursusnr", param);
            }
            catch { return BadRequest(); }

            if (cursus != null)
                return Ok(cursus);
            else return NotFound();
        }

        [HttpGet("{naamBevat}/{maxInschrijvingsgeld}")]
        public IActionResult GetByNaamEnInschrijvingsgeld(string naamBevat, int maxInschrijvingsgeld)
        {
            List<Cursus> cursus = null;
            try
            {             
                SqlParameter pNaam = new SqlParameter("@naambevat", naamBevat);
                SqlParameter pInschrijving = new SqlParameter("@maxInschrijvingsgeld", maxInschrijvingsgeld);
                cursus = _cursusData.ConvertToList("getCursussen", CommandType.StoredProcedure, pNaam, pInschrijving);
            }
            catch { return BadRequest(); }

            if (cursus != null)
                return Ok(cursus);
            else return NotFound();
        }

    }
}