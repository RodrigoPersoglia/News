using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesData.Queries
{
    public interface ITagQueries
    {
        public List<Tag> GetAll();
        public Tag GetById(int Id);

    }
    public class TagQueries : ITagQueries
    {
        private readonly NewsContext _context = new NewsContext();
        public List<Tag> GetAll()
        {
            return _context.Tag.ToList();
        }

        public Tag GetById(int Id)
        {
            return _context.Tag.Find(Id);
        }
    }
}
