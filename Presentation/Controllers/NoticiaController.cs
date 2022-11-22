using Applications.Services;
using Domain.Dtos.Input;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    [Route("Noticias")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _service;

        public NoticiaController(INoticiaService service)
        {
            _service = service;
        }

        [HttpGet(Name = "Noticias/GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _service.GetAll());
            }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(200, _service.GetById(id));
            }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        [HttpPost("Add")]
        public IActionResult Add(NoticiaDtoAdd noticia)
        {
            //    try
            //    {
            _service.Add(noticia);
            return StatusCode(200);
            //    }
            //    catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            //    catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        [HttpPut("Edit")]
        public IActionResult Edit(NoticiaDtoEdit noticia)
        {
            try
            {
                _service.Edit(noticia);
                return StatusCode(200);
            }
            catch (NullReferenceException)
            {
                return StatusCode(400, "Los datos recibidos no pueden ser null");
            }
            catch (NotExistException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return StatusCode(200);
            }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }
    }
}