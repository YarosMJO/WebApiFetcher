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
            users = users.OrderBy(x => x.Name).ToList();
            users?.ForEach(x => x.Todos.Sort(new Comparer()));
            return users;
        }

        private class Comparer : IComparer<Todo>
        {
            public int Compare(Todo x, Todo y)
            {
                if (x.Name.Length < y.Name.Length)
                    return 1;
                else if (x.Name.Length > y.Name.Length)
                    return -1;
                else return 0;
            }
        }
    }
}
