using System.Collections.Generic;
using System.Linq;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class AllPostsService:HelperService
    {
        public List<Post> GetPosts()
        {
            List<Post> posts = UsersList?.SelectMany(x=>x.Posts).ToList();
            return posts;
        }
    }
}
