using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;
using Domain.Exceptions;

namespace Applications.Services
{
    public interface INoticiaService
    {
        public void Add(NoticiaDtoAdd tag);
        public void Edit(NoticiaDtoEdit tag);
        public void Delete(int id);
        public List<NoticiaDtoOut> GetAll();
        public NoticiaDtoOut GetById(int id);

    }
    public class NoticiaService : INoticiaService
    {
        #region Fields
        private readonly IQueries<Noticia> _query;
        private readonly IQueries<Categoria> _queryCategoria;
        private readonly IQueries<Tag> _queryTag;
        private readonly ICommands<Noticia> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public NoticiaService(IMapper mapper, IQueries<Noticia> query, ICommands<Noticia> command, IQueries<Categoria> queryCategoria, IQueries<Tag> queryTag)
        {
            _mapper = mapper;
            _query = query;
            _queryCategoria = queryCategoria;
            _command = command;
            _queryTag = queryTag;
        }
        #endregion

        #region Queries
        public List<NoticiaDtoOut> GetAll()
        {
            return _mapper.Map<List<NoticiaDtoOut>>(_query.GetAll());
        }

        public NoticiaDtoOut GetById(int id)
        {
            var entity = _mapper.Map<NoticiaDtoOut>(_query.GetById(id));
            if (entity == null) { throw new NotExistException(); }
            return entity;
        }
        #endregion

        #region Commands
        public void Add(NoticiaDtoAdd noticia)
        {
            if (noticia == null) { throw new NullReferenceException(); }
            var categoria = _queryCategoria.GetById(noticia.CategoriaId);
            if (categoria == null) { throw new NotExistException(); }
            List<Tag> tags = new List<Tag>();
            foreach(var item in noticia.TagsId)
            {
                var tag = _queryTag.GetById(item);
                if (tag != null) { tags.Add(tag); }
                else { throw new NotExistException();}
            }
            var entity = _mapper.Map<Noticia>(noticia);
            entity.Tags = tags;
            _command.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { throw new NotExistException(); }
            _command.Delete(_mapper.Map<Noticia>(entity));
        }

        public void Edit(NoticiaDtoEdit noticia)
        {
            if (noticia == null) { throw new NullReferenceException(); }
            var entity = GetById(noticia.Id);
            if (entity == null) { throw new NotExistException(); }
            _command.Edit(_mapper.Map<Noticia>(noticia));
        }
        #endregion
    }
}
