using CommAppAPI.Application.DTOs.Contact;
using CommAppAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] ContactCreateDto dto)
        {
            var result = _service.Add(dto);
            return Ok(result);
        }

        // READ ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound("Kayıt bulunamadı.");

            return Ok(result);
        }

        // UPDATE
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ContactUpdateDto dto)
        {
            var result = _service.Update(id, dto);

            if (result == null)
                return NotFound("Güncellenecek kayıt bulunamadı.");

            return Ok(result);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("İletişim bilgisi silindi.");
        }
    }
}
