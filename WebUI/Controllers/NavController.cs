using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Concrete;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly EfBookRepository _repository;

        public NavController(EfBookRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGenre = genre;

            IEnumerable<string> genres = _repository.Сontext.Entities
                .Select(book => book.Genre)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("FlexMenu", genres);
        }
    }
}