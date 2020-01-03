using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using bookstore.Models.Repo;
using bookstore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo<Book> bookrepositry;
        private readonly IBookRepo<Author> authorRepository;

        // GET: Book
        public BookController(IBookRepo<Book> bookrepositry , IBookRepo<Author> authorRepository)
        {
            this.bookrepositry = bookrepositry;
            this.authorRepository = authorRepository;
        }
        public ActionResult Index()
        {
            var books = bookrepositry.List();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookrepositry.Find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var book = new BookAuthorViewModel
            {
                Authors = authorRepository.List().ToList()
            };
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            try
            {
                Book book = new Book
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Author= authorRepository.Find(model.AuthorId)
        
                
                };
                bookrepositry.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookrepositry.Find(id);
            var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;

            var viewModel = new BookAuthorViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = authorId,
                Authors = authorRepository.List().ToList()  

            
            };
            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BookAuthorViewModel viewModel)
        {
            try
            {

                Book book = new Book
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Author = authorRepository.Find(viewModel.AuthorId)


                };
                bookrepositry.Update(viewModel.Id , book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}