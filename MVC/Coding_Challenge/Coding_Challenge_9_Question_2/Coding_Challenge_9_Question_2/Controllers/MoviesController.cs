using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding_Challenge_9_Question_2.Models;
using Coding_Challenge_9_Question_2.Repository;

namespace Coding_Challenge_9_Question_2.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesRepository<Movies> _Moviesrepo = null;

        public MoviesController()
        {
            _Moviesrepo = new MoviesRepository<Movies>();
        }

        // 1. GET: Contact
        public ActionResult Index()
        {
            var Movie = _Moviesrepo.GetAll();
            return View(Movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies m)
        {
            if (ModelState.IsValid)
            {
                _Moviesrepo.Insert(m);
                _Moviesrepo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            var movie = _Moviesrepo.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies m)
        {
            if (ModelState.IsValid)
            {
                _Moviesrepo.Update(m);
                _Moviesrepo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Details(int id)
        {
            var movie = _Moviesrepo.GetByID(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _Moviesrepo.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _Moviesrepo.Delete(id);
            _Moviesrepo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int? year)
        {
            if (year == null)
            {
                return View();
            }
            var movies = _Moviesrepo.GetAll()
                                    .Where(m => m.DateofRelease.Year == year)
                                    .ToList();
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            if (string.IsNullOrEmpty(directorName))
            {
                return View();
            }

            var movies = _Moviesrepo.GetAll()
                                    .Where(m => m.DirectorName.Equals(directorName, StringComparison.OrdinalIgnoreCase))
                                    .ToList();

            return View(movies);
        }

    }
}