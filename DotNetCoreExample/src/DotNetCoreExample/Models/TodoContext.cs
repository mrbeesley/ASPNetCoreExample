using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Models
{
    public class TodoContext : IContext
    {

        public TodoContext()
        {
            TodoItems = new TodoContextEnumerable<TodoItem>();
            savedTodoItems = new List<TodoItem>();
        }

        public TodoContextEnumerable<TodoItem> TodoItems { get; private set; }

        private List<TodoItem> savedTodoItems;

        public void SaveChanges()
        {
            savedTodoItems.AddRange(TodoItems.ToList());
        }

    }

    public class TodoContextEnumerable<t> : IEnumerable<t>
    {

        private List<t> data = new List<t>();

        public t this[int index]
        {
            get { return data[index]; }
            set { data.Insert(index, value); }
        }

        public IEnumerator<t> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(t item)
        {
            data.Add(item);
        }

        public void Remove(t item)
        {
            data.Remove(item);
        }

        public void Update(t item)
        {
            data.Remove(item);
            data.Add(item);
        }
    }
}
