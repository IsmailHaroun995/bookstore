using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using bookstore.Models.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    public class AutorController : Controller
    {
        private readonly IBookRepo<Author> authorRepos;

        // GET: Autor

        public AutorController(IBookRepo<Author> authorRepos)
        {
            this.authorRepos = authorRepos;
        }
        public ActionResult Index()
        {
            var authors = authorRepos.List();
            return View(authors);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            var authors = authorRepos.Find(id);
            return View(authors);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                authorRepos.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            var authors = authorRepos.Find(id);
            return View(authors);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                
                authorRepos.Update(id, author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            var authors = authorRepos.Find(id);
          
            return View(authors);
        }

        // POST: Autor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                authorRepos.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}