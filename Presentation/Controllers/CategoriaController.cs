using Applications.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }


        /// <summary>
        /// Obtiene un listado de todas las categorías
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<CategoriaDtoOut>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _service.GetAll());
            }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }

        }


        /// <summary>
        /// Obtiene una categoria por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaDtoOut))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(200, _service.GetById(id));
            }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }


        /// <summary>
        /// Agregar una categoría
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(CategoriaDtoAdd categoria)
        {
            try
            {
                _service.Add(categoria);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }


        /// <summary>
        /// Editar una categoría
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Edit(CategoriaDtoEdit categoria)
        {
            try
            {
                _service.Edit(categoria);
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


        /// <summary>
        /// Eliminar una categoría
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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