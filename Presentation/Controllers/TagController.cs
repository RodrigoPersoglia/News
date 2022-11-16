using AccesData.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly TagQueries _query = new TagQueries();

        public TagController()
        {
        }

        [HttpGet(Name = "GetAll")]
        public List<Tag> GetAll()
        {
            return _query.GetAll();
        }
    }
}