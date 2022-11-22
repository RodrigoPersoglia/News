using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;
using Domain.Exceptions;

namespace Applications.Services
{
    public interface IUserService
    {
        public void Add(UserDtoAdd tag);
        public void Edit(UserDtoEdit tag);
        public void Delete(int id);
        public List<UserDtoOut> GetAll();
        public UserDtoOut GetById(int id);

    }
    public class UserService : IUserService
    {
        #region Fields
        private readonly IQueries<User> _query;
        private readonly ICommands<User> _command;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UserService(IMapper mapper, IQueries<User> query, ICommands<User> command)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
        }
        #endregion

        #region Queries
        public List<UserDtoOut> GetAll()
        {
            return _mapper.Map<List<UserDtoOut>>(_query.GetAll());
        }

        public UserDtoOut GetById(int id)
        {
            var entity = _mapper.Map<UserDtoOut>(_query.GetById(id));
            if (entity == null) { throw new NotExistException(); }
            return entity;
        }
        #endregion

        #region Commands
        public void Add(UserDtoAdd user)
        {
            if (user == null) { throw new NullReferenceException(); }
            _command.Add(_mapper.Map<User>(user));
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { throw new NotExistException(); }
            _command.Delete(_mapper.Map<User>(entity));
        }

        public void Edit(UserDtoEdit user)
        {
            if (user == null) { throw new NullReferenceException(); }
            var entity = GetById(user.Id);
            if (entity == null) { throw new NotExistException(); }
            _command.Edit(_mapper.Map<User>(user));
        }
        #endregion
    }
}
