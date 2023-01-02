using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System.Linq;

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
        private readonly INoticiaQuery _query;
        private readonly IQueries<Categoria> _queryCategoria;
        private readonly IQueries<Tag> _queryTag;
        private readonly IQueries<NoticiaTag> _queryNoticiaTag;
        private readonly ICommands<Noticia> _command;
        private readonly ICommandsNoticiaTag _commandNoticiaTag;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public NoticiaService(
            IMapper mapper,
            INoticiaQuery query,
            ICommands<Noticia> command,
            IQueries<Categoria> queryCategoria,
            IQueries<Tag> queryTag,
            ICommandsNoticiaTag commandNoticiaTag,
            IQueries<NoticiaTag> queryNoticiaTag )
        {
            _mapper = mapper;
            _query = query;
            _queryCategoria = queryCategoria;
            _command = command;
            _queryTag = queryTag;
            _commandNoticiaTag = commandNoticiaTag;
            _queryNoticiaTag = queryNoticiaTag;
        }
        #endregion

        #region Queries
        public List<NoticiaDtoOut> GetAll()
        {
            var list = _query.GetAll();
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
            var entity = _mapper.Map<Noticia>(noticia);
            var tags = new List<NoticiaTag>();
            foreach (var item in noticia.TagsId)
            {
                var tag = _queryTag.GetById(item);
                if (tag == null) { throw new NotExistException(); }
                tags.Add(new NoticiaTag() { TagId = item, NoticiaId = entity.Id });

            }
            entity.NoticiasTags = tags;
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
            var noticiaOld = _query.GetById(noticia.Id);
            if (noticiaOld == null) { throw new NotExistException(); }
            var entity = _mapper.Map<Noticia>(noticia);

            _commandNoticiaTag.DeleteByNoticiaId(noticia.Id);
            var list = new List<NoticiaTag>();
            foreach (var item in noticia.TagsId)
            {
                var tag = _queryTag.GetById(item);
                if (tag == null) { throw new NotExistException(); }
                list.Add(new NoticiaTag() { NoticiaId = noticia.Id, TagId = item});
            }
            _commandNoticiaTag.AddRange(list);

            _command.Edit(entity);
        }
        #endregion
    }
}
