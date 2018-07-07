using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFetcher.Models
{
    public class PostStruct
    {
        public Post latestPost { get; set; }
        public int? postsCount { get; set; }
        public int? unTodo { get; set; }
        public Post bestCommented { get; set; }
        public Post bestLiked { get; set; }
    }
}
