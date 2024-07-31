using System.Collections.Generic;
using System.Linq;
using ToDo.Models;

namespace ToDo.Services
{
    public class TodoService
    {
        private readonly List<TodoModel> _todos = new List<TodoModel>();
        private int _nextId = 1;

        public List<TodoModel> GetAll()
        {
            return _todos;
        }

        public TodoModel? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TodoModel todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
        }

        public void Update(TodoModel todo)
        {
            var existingTodo = GetById(todo.Id);
            if (existingTodo != null)
            {
                existingTodo.Description = todo.Description;
                existingTodo.IsDone = todo.IsDone;
            }
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
