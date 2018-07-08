using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class AllCommentsService:HelperService
    {
        public List<Comment> GetComments()
        {
            List<Post> posts = UsersList?.SelectMany(x => x.Posts).ToList();
            List<Comment> comments = posts.SelectMany(x => x.Comments).ToList();
            return comments;
        }
    }
}
