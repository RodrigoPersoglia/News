using AccesData.Commands;
using AccesData.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Applications.Services
{
    public interface IUserService
    {
        public void Add(UserDtoAdd tag);
        public void Edit(UserDtoEdit tag);
        public void Delete(int id);
        public List<UserDtoOut> GetAll();
        public UserDtoOut GetById(int id);

        public string Login(UserLogin user);
    }
    public class UserService : IUserService
    {
        #region Fields
        private readonly IQueries<User> _query;
        private readonly ICommands<User> _command;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuracion;
        #endregion

        #region Constructor
        public UserService(IMapper mapper, IQueries<User> query, ICommands<User> command, IConfiguration configuracion)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
            _configuracion= configuracion ?? throw new ArgumentNullException(nameof(configuracion));
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


        private string CrearToken(User usuario)
        {
            // Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["JwtIssuerOptions:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("idUsuario", usuario.Id.ToString())
            };


            var expiration = DateTime.UtcNow.AddDays(3);

            //Payload
            var payload = new JwtPayload(
                _configuracion["JwtIssuerOptions:Issuer"],
                _configuracion["JwtIssuerOptions:Audience"],
                claims,
                DateTime.Now,
                expiration
                );

            var jwtSecurity = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurity);
        }

        public string Login(UserLogin user)
        {
            var userEntity = _query.GetAll().Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (userEntity == null) { throw new UserException(); }
            if(userEntity.Password != user.Password) { throw new UserException(); }
            var token = CrearToken(userEntity);
            return token;
        }
    }
}
