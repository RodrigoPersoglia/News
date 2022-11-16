using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesData.Commands
{

    public interface ITagRepository
    {
        public void Add(Tag tag);
        public void Edit(Tag tag);
        public void Delete(Tag tag);
    }

    public class TagRepository : ITagRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public void Add(Tag tag)
        {
            _context.Tag.Add(tag);
        }

        public void Delete(Tag tag)
        {
            _context.Tag.Remove(tag);
        }

        public void Edit(Tag tag)
        {
            _context.Tag.Update(tag);
        }
    }
}
