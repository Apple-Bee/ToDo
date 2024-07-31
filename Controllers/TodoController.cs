using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            var todos = _todoService.GetAll();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoModel todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Edit(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(TodoModel todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Update(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo != null)
            {
                _todoService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
