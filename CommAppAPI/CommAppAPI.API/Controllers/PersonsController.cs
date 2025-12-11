using CommAppAPI.Application.DTOs.Person;
using CommAppAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddPerson(PersonCreateDto dto)
        {
            var result = _personService.Add(dto);
            return Ok(result);
        }

        // GET ALL (Sade)
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();
            return Ok(result);
        }

        // GET ALL with relations
        [HttpGet("with-relations")]
        public IActionResult GetAllWithRelations()
        {
            var result = _personService.GetAllWithRelations();
            return Ok(result);
        }
        [HttpGet("with-relations/{id}")]
        public IActionResult GetByIdWithRelations(int id)
        {
            var result=_personService.GetByIdWithRelations(id);
            return Ok(result);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _personService.GetById(id);

            if (result == null)
                return NotFound("Person bulunamadı.");

            return Ok(result);
        }

        // UPDATE
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonUpdateDto dto)
        {
            var result = _personService.Update(id, dto);
            return Ok(result);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok("Person başarıyla silindi.");
        }
    }
}
