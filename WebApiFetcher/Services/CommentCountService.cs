using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class CommentCountService: HelperService
    {
        public async Task<List<Post>> GetCommentsCountAsync(int? id)
        {
            List<User> users = await RunAsync();
            List<Post> posts = users.Find(y => y.id.Equals(id))?.Posts;
            return posts;
        }
    }
}
