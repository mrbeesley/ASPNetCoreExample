using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Models
{
    public interface IContext
    {
        void SaveChanges();

        TodoContextEnumerable<TodoItem> TodoItems { get; }
    }
}
