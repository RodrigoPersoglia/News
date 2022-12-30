using Applications.Services;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    public class TagController : NewsControllerBase
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un listado de todas los tags.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TagDtoOut>))]
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
        /// Obtiene un tag por id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TagDtoOut))]
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
        /// Agregar un tag.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(TagDtoAdd tag)
        {
            try
            {
                _service.Add(tag);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Editar un tag.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Edit(TagDtoEdit tag)
        {
            try
            {
                _service.Edit(tag);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Eliminar un tag.
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