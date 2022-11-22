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

        public Queries(NewsContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}
