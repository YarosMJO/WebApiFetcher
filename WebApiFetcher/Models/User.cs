using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFetcher.Models
{
    public class User
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string email { get; set; }
        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
