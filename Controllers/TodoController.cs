using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nareshtodo.Models;

namespace nareshtodo.Controllers
{
    public class TodoController : Controller
    {
        private static System.Collections.Generic.List<TodoModel> todos = new();
        public IActionResult Index()
        {
            return View(todos);
        }
        public IActionResult CreateTodo(TodoModel item)
        {
            DateTime dt = new DateTime(0001, 1, 01);
            item.complete = dt;
            todos.Add(item);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Complete(int id)
        {
            todos = todos.Where(item => item.Id == id).Select(item => { item.complete = DateTime.Now; return item; }).ToList();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            var todo = new TodoModel();
            return View(todo);
        }

    }
}