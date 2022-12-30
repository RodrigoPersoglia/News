using Microsoft.EntityFrameworkCore;

namespace AccesData.Queries
{
    #region Interface IQueries
    public interface IQueries<T> where T : class
    {
        public List<T> GetAll();
        public T? GetById(int Id);

    }
    #endregion
    public class Queries<T> : IQueries<T> where T : class
    {
        private readonly NewsContext _context;
        private readonly DbSet<T> _entities;

        public Queries(NewsContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int Id)
        {
            return _entities.Find(Id);
        }

    }
}
