using System.Data.SqlClient;
using CoreWebAPI.Data;
using CoreWebAPI.Models;
using DataHelpers.Lib;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentRepository _studentRepository;
        public StudentController()
        {
            _studentRepository = new StudentRepository(
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
                return Ok(_studentRepository.Get());
            }
            catch { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Student student = _studentRepository.GetById(id);
                if (student != null)
                    return Ok(student);
                else return NotFound();
            }
            catch { return BadRequest(); }
        }
    }
}