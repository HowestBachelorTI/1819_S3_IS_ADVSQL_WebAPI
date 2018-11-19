using System.Collections.Generic;
using System.Data.SqlClient;
using CoreWebAPI.Data;
using CoreWebAPI.Models;
using DataHelpers.Lib;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {
        private CursusRepository _cursusRepository;
        public CursusController()
        {
            _cursusRepository = new CursusRepository(
                                    new SqlHelper(
                                        new SqlConnection(@"Data Source=.\sqlexpress;
                                            Database=School;
                                            Integrated security=true;"
                                                       )));
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(_cursusRepository.Get());
            }
            catch { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Cursus cursus = _cursusRepository.GetById(id);
                if (cursus != null)
                    return Ok(cursus);
                else return NotFound();
            }
            catch { return BadRequest(); }    
        }

        [HttpGet("{naamBevat}/{maxInschrijvingsgeld}")]
        public IActionResult GetByNaamEnInschrijvingsgeld(string naamBevat, int maxInschrijvingsgeld)
        {         
            try
            {
                List<Cursus> cursussen = _cursusRepository.GetByNaamEnInschrijvingsgeld(naamBevat, maxInschrijvingsgeld);
                if (cursussen.Count > 0)
                    return Ok(cursussen);
                else return NotFound();
            }
            catch { return BadRequest(); }

            
        }

    }
}