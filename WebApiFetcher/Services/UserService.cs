using System.Collections.Generic;
using System.Linq;
using WebApiFetcher;
using WebApiFetcher.Models;

namespace Services
{
    public class UserService: HelperService
    {
        public List<User> GetUsers()
        {
            List<User> users = UsersList?.OrderBy(x => x?.Name)?.ToList();
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
