using System.Collections.Generic;
using System.Linq;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class TodoService: HelperService
    {
        public List<Todo> GetTodos(int? id)
        {
            List<Todo> Todos = UsersList?.Find(y => y?.Id == id)?.Todos?.Where(x => x?.IsComplete == true)?.ToList();
            return Todos;
        }
    }
}
