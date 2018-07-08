using System.Collections.Generic;
using System.Linq;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class AllTodosService:HelperService
    {
        public List<Todo> GetTodos()
        {
            List<Todo> todos = UsersList?.SelectMany(x => x.Todos).ToList();
            return todos;
        }
    }
}
