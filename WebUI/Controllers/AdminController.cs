using System.Linq;
using Repositories.Abstract;
using Repositories.Concrete;
using System.Web.Mvc;
using Domain;
using Repositories.Entities;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly EfBookRepository _repository;

        public AdminController(EfBookRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            return View(_repository.Сontext);
        }

        public ViewResult Edit(int bookId)
        {
            var book = _repository.Сontext.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }

        public ViewResult Create()
        {
            //EfBookRepository efBookRepository =

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid) return View(book);
            _repository.SaveBook(book);
            TempData["message"] = $"Изменение информации о книге \"{book.Name}\" сохранены";
            return RedirectToAction("Index");
        }

    }
}