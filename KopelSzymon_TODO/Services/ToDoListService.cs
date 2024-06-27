using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem { Description = "Pranie" },
            new ToDoItem { Description = "Nauka" },
            new ToDoItem { Description = "Obiad" },
            new ToDoItem { Description = "Sprzątanie" },
            new ToDoItem { Description = "Zakupy" },
        };
    }
}
