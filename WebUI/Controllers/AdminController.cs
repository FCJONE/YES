﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository repository;
        EFBookRepository EfBookRepository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

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
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
    }
}