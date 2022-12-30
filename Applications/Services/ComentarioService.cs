using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Applications.Services
{
    public interface IComentarioService
    {
        public void Add(ComentarioDtoAdd tag);
        public void Edit(ComentarioDtoEdit tag);
        public void Delete(int id);
        public List<ComentarioDtoOut> GetAll();
        public ComentarioDtoOut GetById(int id);

    }
    public class ComentarioService : IComentarioService
    {
        #region Fields
        private readonly IComentarioQuery _query;
        private readonly INoticiaQuery _queryNoticia;
        private readonly ICommands<Comentario> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ComentarioService(IMapper mapper, IComentarioQuery query, ICommands<Comentario> command, INoticiaQuery queryNoticia)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
            _queryNoticia = queryNoticia;
        }
        #endregion

        #region Queries
        public List<ComentarioDtoOut> GetAll()
        {
            return _mapper.Map<List<ComentarioDtoOut>>(_query.GetAll());
        }

        public ComentarioDtoOut GetById(int id)
        {
            var entity = _mapper.Map<ComentarioDtoOut>(_query.GetById(id));
            if (entity == null) { throw new NotExistException(); }
            return entity;
        }
        #endregion

        #region Commands
        public void Add(ComentarioDtoAdd comentario)
        {
            if (_queryNoticia.GetById(comentario.NoticiaId) == null) { throw new NotExistException(); }
            if (comentario == null) { throw new NullReferenceException(); }
            _command.Add(_mapper.Map<Comentario>(comentario));
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { throw new NotExistException(); }
            _command.Delete(_mapper.Map<Comentario>(entity));
        }

        public void Edit(ComentarioDtoEdit comentario)
        {
            if (comentario == null) { throw new NullReferenceException(); }
            if (_queryNoticia.GetById(comentario.NoticiaId) == null) { throw new NotExistException(); }
            var entity = GetById(comentario.Id);
            if (entity == null) { throw new NotExistException(); }
            _command.Edit(_mapper.Map<Comentario>(comentario));
        }
        #endregion
    }
}
