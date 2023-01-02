using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccesData.Commands
{
    #region interface IRepository
    public interface ICommandsNoticiaTag
    {
        public void DeleteByNoticiaId(int id);
        public void AddRange(List<NoticiaTag> entity);
    }
    #endregion
    public class CommandsNoticiaTag : ICommandsNoticiaTag
    {
        private readonly NewsContext _context;

        public CommandsNoticiaTag(NewsContext context)
        {
            _context = context;
        }

        public void AddRange(List<NoticiaTag> entity)
        {
            _context.NoticiaTag.AddRange(entity);
            _context.SaveChanges();
        }

        public void DeleteByNoticiaId(int id)
        {
            var tags = _context.NoticiaTag.Where(x => x.NoticiaId== id).ToList();
            _context.NoticiaTag.RemoveRange(tags);
            _context.SaveChanges();
        }

    }
}
