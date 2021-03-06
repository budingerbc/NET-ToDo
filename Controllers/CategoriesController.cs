﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
	public class CategoriesController : Controller
	{
		private ToDoListContext db = new ToDoListContext();

		public IActionResult Index()
		{
			return View(db.Categories.ToList());
		}

		public IActionResult Details(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(categorys => categorys.CategoryId == id);
			return View(thisCategory);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
            Console.WriteLine(id);
			var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
			return View(thisCategory);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			db.Entry(category).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(categorys => categorys.CategoryId == id);
			return View(thisCategory);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(categorys => categorys.CategoryId == id);
			db.Categories.Remove(thisCategory);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
