using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccesData.Queries
{
    #region Interface IComentarioQuery
    public interface IComentarioQuery
    {
        public List<Comentario> GetAll();
        public Comentario? GetById(int Id);

    }
    #endregion
    public class ComentarioQuery : IComentarioQuery
    {
        private readonly NewsContext _context;

        public ComentarioQuery(NewsContext context)
        {
            _context = context;
        }
        public List<Comentario> GetAll()
        {
            return _context.Comentario
                .Include(u => u.User)
                .Include(r => r.Reacciones)
                .ToList();
        }

        public Comentario? GetById(int Id)
        {
            return _context.Comentario
                .Include(u => u.User)
                .Include(r => r.Reacciones)
                .Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}
