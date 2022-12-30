using Applications.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    public class ComentarioController : NewsControllerBase
    {
        private readonly IComentarioService _service;

        public ComentarioController(IComentarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un listado de todos los comentarios.
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
        /// Obtiene un comentario por id.
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
        /// Agregar un comentario.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(ComentarioDtoAdd comentario)
        {
            try
            {
                _service.Add(comentario);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Editar un comentario.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Edit(ComentarioDtoEdit comentario)
        {
            try
            {
                _service.Edit(comentario);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Eliminar un comentario
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