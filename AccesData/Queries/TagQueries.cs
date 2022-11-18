using Domain.Entities;

namespace AccesData.Queries
{
    #region Interface ITagQueries
    public interface ITagQueries
    {
        public List<Tag> GetAll();
        public Tag? GetById(int Id);

    }
    #endregion
    public class TagQueries : ITagQueries
    {
        private readonly NewsContext _context;

        public TagQueries(NewsContext context)
        {
            _context = context;
        }
        public List<Tag> GetAll()
        {
            return _context.Tag.ToList();
        }

        public Tag? GetById(int Id)
        {
            return _context.Tag.Find(Id);
        }
    }
}
