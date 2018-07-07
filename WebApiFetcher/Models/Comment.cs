using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFetcher.Models
{
    public class Comment
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
        public int likes { get; set; }
    }
}