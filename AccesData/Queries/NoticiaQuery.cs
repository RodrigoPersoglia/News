using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccesData.Queries
{
    #region Interface IQueriesNoticiaQuery
    public interface INoticiaQuery
    {
        public List<Noticia> GetAll();
        public Noticia? GetById(int Id);

    }
    #endregion
    public class NoticiaQuery : INoticiaQuery
    {
        private readonly NewsContext _context;

        public NoticiaQuery(NewsContext context)
        {
            _context = context;
        }
        public List<Noticia> GetAll()
        {
            return _context.Noticia
                .Include(ca => ca.Categoria)
                .Include(co => co.Comentarios).ThenInclude(u => u.User)
                .Include(nt => nt.NoticiasTags).ThenInclude(ta => ta.Tag)
                .ToList();
        }

        public Noticia? GetById(int Id)
        {
            return _context.Noticia
                .Include(ca => ca.Categoria)
                .Include(co => co.Comentarios).ThenInclude(u => u.User)
                .Include(nt => nt.NoticiasTags).ThenInclude(ta => ta.Tag)
                .Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}
