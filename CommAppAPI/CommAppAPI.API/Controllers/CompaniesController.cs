using CommAppAPI.Application.DTOs.Company;
using CommAppAPI.Application.Interfaces;
using CommAppAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommAppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] CompanyCreateDto dto)
        {
            var result = _service.Add(dto);
            return Ok(result);
        }

        // GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("with-persons/{id}")]
        public IActionResult GetDetail(int id)
        {
            var result = _service.GetDetail(id);
            return Ok(result);
        }


        // GET BY ID
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
        public IActionResult Update(int id, [FromBody] CompanyUpdateDto dto)
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
            return Ok("Şirket başarıyla silindi.");
        }
    }
}
