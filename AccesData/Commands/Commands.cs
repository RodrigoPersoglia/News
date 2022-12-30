using Microsoft.EntityFrameworkCore;

namespace AccesData.Commands
{
    #region interface IRepository
    public interface ICommands<T> where T : class
    {
        public void Add(T entity);
        public void Edit(T entity);
        public void Delete(T entity);
    }
    #endregion
    public class Commands<T> : ICommands<T> where T : class
    {
        private readonly NewsContext _context;
        protected readonly DbSet<T> _entities;

        public Commands(NewsContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
