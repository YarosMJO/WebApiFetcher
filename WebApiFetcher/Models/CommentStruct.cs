using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFetcher.Models
{
    public class CommentStruct
    {
        public Comment longestComment { get; set; }
        public Comment mostLikedComment { get; set; }
        public int? commentsCount { get; set; }
    }
}
