using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repo
{
    public class BookRepo : IBookRepo<Book>
    {
        List<Book> books;
        public BookRepo()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,Title="C sharp",Description="No desc", Author = new Author()
                },
                 new Book
                {
                    Id=2,Title="Java",Description="No desc" ,  Author = new Author()
                },
                  new Book
                {
                    Id=3,Title="Python",Description="No desc",  Author = new Author()
                }
            };
        }
        void IBookRepo<Book>.Add(Book entity)
        {
            books.Add(entity);
        }

        void IBookRepo<Book>.Delete(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            books.Remove(book);
        }

        Book IBookRepo<Book>.Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        List<Book> IBookRepo<Book>.List()
        {
            return books;
        }

        void IBookRepo<Book>.Update(int id,Book newBook)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
        }
    }
}
