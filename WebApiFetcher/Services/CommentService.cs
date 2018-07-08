using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class CommentService: HelperService
    {
        public async Task<List<Comment>> GetCommentsAsync(int? id)
        {
            List<User> users = await RunAsync();
            List<Post> posts = users.Find(y => y?.Id == id)?.Posts;
            List<Comment> Сomments = new List<Comment>();
            posts?.ForEach(x => x?.Comments?.ForEach(y => Сomments?.Add(y)));
            Сomments = (from com in Сomments where com.Body.Length < 50 select com).ToList();
            return Сomments;
        }

    }
}
