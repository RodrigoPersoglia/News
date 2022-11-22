using Microsoft.EntityFrameworkCore;

namespace AccesData.Commands
{
    #region interface ITagRepository
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

        public Commands(NewsContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
