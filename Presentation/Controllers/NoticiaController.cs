using Applications.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    public class NoticiaController : NewsControllerBase
    {
        private readonly INoticiaService _service;

        public NoticiaController(INoticiaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un listado de todas las noticias.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<NoticiaDtoOut>))]
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
        /// Obtiene una noticia por id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(NoticiaDtoOut))]
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
        /// Agregar una noticia.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(NoticiaDtoAdd noticia)
        {
            try
            {
                _service.Add(noticia);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Editar una noticia.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Edit(NoticiaDtoEdit noticia)
        {
            try
            {
                _service.Edit(noticia);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Eliminar una noticia.
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