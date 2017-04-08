using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly EfBookRepository _repository;
        public int PageSize = 4;

        public BooksController(EfBookRepository repo)
        {
            _repository = repo;
        }


        public ViewResult List(string genre, int page = 1)
        {
            var model = new BooksListViewModel
            {
                Books = _repository.EntitiesList()
                .Where(b => genre == null || b.Genre == genre)
                .OrderBy(book => book.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                        _repository.Сontext.Entities.Count() :
                        _repository.Сontext.Entities.Count(book => book.Genre == genre)
                },
                CurrentGenre = genre
            };

            return View(model);
        }
    }
}