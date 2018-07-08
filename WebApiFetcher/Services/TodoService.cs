using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class TodoService: HelperService
    {
        public async Task<List<Todo>> GetTodosAsync(int? id)
        {
            List<User> users = await RunAsync();
            List<Todo> Todos = users?.Find(y => y?.Id == id)?.Todos?.Where(x => x?.IsComplete == true)?.ToList();
            return Todos;
        }
    }
}
