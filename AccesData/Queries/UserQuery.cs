using Domain.Entities;

namespace AccesData.Queries
{
    #region Interface IQueries
    public interface IUserQuery
    {
        public List<User> GetAll();
        public User? GetById(int Id);
        public User? GetByUserName(string userName);
        public User? GetByEmail(string email);

    }
    #endregion
    public class UserQuery : IUserQuery
    {
        private readonly NewsContext _context;

        public UserQuery(NewsContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User? GetById(int Id)
        {
            return _context.User.Find(Id);
        }

        public User? GetByUserName(string userName)
        {
            return _context.User.Where(u => u.UserName == userName).FirstOrDefault();
        }

        public User? GetByEmail(string email)
        {
            return _context.User.Where(u => u.Email == email).FirstOrDefault();
        }

    }
}
