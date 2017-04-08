using Repositories.Abstract;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly EfBookRepository _repository;
        private readonly IOrderProcessor _orderProcessor;

        public CartController(EfBookRepository repo, IOrderProcessor processor)
        {
            _repository = repo;
            _orderProcessor = processor;
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = cart,
                    ReturnUrl = returnUrl
                });
        }

        public RedirectToRouteResult AddToCart(Cart cart,int bookId, string returnUrl)
        {
            Book book = _repository.Сontext.Entities
                .FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                cart.AddItem(book, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = _repository.Сontext.Entities
                .FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                cart.RemoveLine(book);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Извините, корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                _orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            return View(new ShippingDetails());
        }

    }
}