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
        private readonly INoticiaQuery _query;
        private readonly IQueries<Categoria> _queryCategoria;
        private readonly IQueries<Tag> _queryTag;
        private readonly ICommands<Noticia> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public NoticiaService(IMapper mapper, INoticiaQuery query, ICommands<Noticia> command, IQueries<Categoria> queryCategoria, IQueries<Tag> queryTag)
        {
            _mapper = mapper;
            _query = query;
            _queryCategoria = queryCategoria;
            _command = command;
            _queryTag = queryTag;
        }
        #endregion

        #region Queries
        public  List<NoticiaDtoOut> GetAll()
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
            var tags = new List<Map_Noticia_Tag>();
            foreach (var item in noticia.TagsId)
            {
                var tag = _queryTag.GetById(item);
                if(tag == null) { throw new NotExistException(); }
                tags.Add(new Map_Noticia_Tag(){TagId = item, Noticia = entity }); 

            }
            entity.Map_Noticia_Tag = tags;
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
            if (GetById(noticia.Id) == null) { throw new NotExistException(); }
            var entity = _mapper.Map<Noticia>(noticia);

            var tags = new List<Map_Noticia_Tag>();
            foreach (var item in noticia.TagsId)
            {
                var tag = _queryTag.GetById(item);
                if (tag == null) { throw new NotExistException(); }
                tags.Add(new Map_Noticia_Tag() { TagId = item, Noticia = entity });

            }
            entity.Map_Noticia_Tag = tags;

            _command.Edit(entity);
        }
        #endregion
    }
}
