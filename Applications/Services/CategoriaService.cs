using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;
using Domain.Exceptions;

namespace Applications.Services
{
    public interface ICategoriaService
    {
        public void Add(CategoriaDtoAdd tag);
        public void Edit(CategoriaDtoEdit tag);
        public void Delete(int id);
        public List<CategoriaDtoOut> GetAll();
        public CategoriaDtoOut GetById(int id);

    }
    public class CategoriaService : ICategoriaService
    {
        #region Fields
        private readonly IQueries<Categoria> _query;
        private readonly ICommands<Categoria> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CategoriaService(IMapper mapper, IQueries<Categoria> query, ICommands<Categoria> command)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
        }
        #endregion

        #region Queries
        public List<CategoriaDtoOut> GetAll()
        {
            return _mapper.Map<List<CategoriaDtoOut>>(_query.GetAll());
        }

        public CategoriaDtoOut GetById(int id)
        {
            var entity = _mapper.Map<CategoriaDtoOut>(_query.GetById(id));
            if (entity == null) { throw new NotExistException(); }
            return entity;
        }
        #endregion

        #region Commands
        public void Add(CategoriaDtoAdd categoria)
        {
            if (categoria == null) { throw new NullReferenceException(); }
            _command.Add(_mapper.Map<Categoria>(categoria));
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { throw new NotExistException(); }
            _command.Delete(_mapper.Map<Categoria>(entity));
        }

        public void Edit(CategoriaDtoEdit categoria)
        {
            if (categoria == null) { throw new NullReferenceException(); }
            var entity = GetById(categoria.Id);
            if (entity == null) { throw new NotExistException(); }
            _command.Edit(_mapper.Map<Categoria>(categoria));
        }
        #endregion
    }
}
