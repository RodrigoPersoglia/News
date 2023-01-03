using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;
using Domain.Exceptions;

namespace Applications.Services
{
    #region Interface ITagService
    public interface ITagService
    {
        public void Add(TagDtoAdd tag);
        public void Edit(TagDtoEdit tag);
        public void Delete(int id);
        public List<TagDtoOut> GetAll();
        public TagDtoOut GetById(int id);

    }
    #endregion
    public class TagService : ITagService
    {
        #region Fields
        private readonly IQueries<Tag> _query;
        private readonly ICommands<Tag> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public TagService(IMapper mapper, IQueries<Tag> query, ICommands<Tag> command)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
        }
        #endregion

        #region Queries
        public List<TagDtoOut> GetAll()
        {
            return _mapper.Map<List<TagDtoOut>>(_query.GetAll());
        }

        public TagDtoOut GetById(int id)
        {
            var entity = _mapper.Map<TagDtoOut>(_query.GetById(id));
            if (entity == null) { throw new NotExistException(); }
            return entity;
        }
        #endregion

        #region Commands
        public void Add(TagDtoAdd tag)
        {
            if (tag == null) { throw new NullReferenceException(); }
            _command.Add(_mapper.Map<Tag>(tag));
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { throw new NotExistException(); }
            _command.Delete(_mapper.Map<Tag>(entity));
        }

        public void Edit(TagDtoEdit tag)
        {
            if (tag == null) { throw new NullReferenceException(); }
            var entity = GetById(tag.Id);
            if (entity == null) { throw new NotExistException(); }
            _command.Edit(_mapper.Map<Tag>(tag));
        }
        #endregion
    }
}
