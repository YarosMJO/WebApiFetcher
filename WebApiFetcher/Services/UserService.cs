using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher;
using WebApiFetcher.Models;

namespace Services
{
    public class UserService: HelperService
    {
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await RunAsync();
            users = users.OrderBy(x => x.name).ToList();
            users?.ForEach(x => x.Todos.Sort(new Comparer()));
            return users;
        }

        private class Comparer : IComparer<Todo>
        {
            public int Compare(Todo x, Todo y)
            {
                if (x.name.Length < y.name.Length)
                    return 1;
                else if (x.name.Length > y.name.Length)
                    return -1;
                else return 0;
            }
        }
    }
}
