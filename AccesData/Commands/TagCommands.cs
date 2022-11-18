using Domain.Entities;

namespace AccesData.Commands
{
    #region interface ITagRepository
    public interface ITagRepository
    {
        public void Add(Tag tag);
        public void Edit(Tag tag);
        public void Delete(Tag tag);
    }
    #endregion
    public class TagRepository : ITagRepository
    {
        private readonly NewsContext _context;

        public TagRepository(NewsContext context)
        {
            _context = context;
        }

        public void Add(Tag tag)
        {
            _context.Tag.Add(tag);
            _context.SaveChanges();
        }

        public void Delete(Tag tag)
        {
            _context.Tag.Remove(tag);
            _context.SaveChanges();
        }

        public void Edit(Tag tag)
        {
            var entity = _context.Tag.Find(tag.Id);
            if (entity != null)
            {
                entity.Description = tag.Description;
                _context.Tag.Update(entity);
                _context.SaveChanges();
            }

        }
    }
}
