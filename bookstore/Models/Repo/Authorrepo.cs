using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repo
{
    public class Authorrepo : IBookRepo<Author>
    {
        IList<Author> authors;
        public Authorrepo()
        {
            authors = new List<Author>()
            {
                new Author{Id=1,FullName="ismail"},
                 new Author{Id=1,FullName="ismail"},
                  new Author{Id=1,FullName="ismail"}
            };
        }
        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);

            return author;
        }

        public List<Author> List()
        {
            return authors.ToList();
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
            author.FullName = entity.FullName;
        }
    }
}
