using Applications.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    public class UserController : NewsControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un listado de todas los usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UserDtoOut>))]
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
        /// Obtiene un usuario por id.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDtoOut))]
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
        /// Agregar un usuario.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(UserDtoAdd user)
        {
            try
            {
                _service.Add(user);
                return StatusCode(200);
            }
            catch (NullReferenceException) { return StatusCode(400, "Los datos recibidos no pueden ser null"); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }

        /// <summary>
        /// Editar un usuario.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Edit(UserDtoEdit user)
        {
            try
            {
                _service.Edit(user);
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
        /// Eliminar un usuario.
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

        /// <summary>
        /// Eliminar un usuario.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/Login")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Login(UserLogin user)
        {
            try
            {
                var token = _service.Login(user);
                return StatusCode(200,token);
            }
            catch (NotExistException ex) { return StatusCode(404, ex.Message); }
            catch (UserException ex) { return StatusCode(401, ex.Message); }
            catch (Exception ex) { return StatusCode(500, "internal Server Error: " + ex.Message); }
        }
    }
}