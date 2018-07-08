using System.Collections.Generic;
using System.Linq;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class CommentService: HelperService
    {
        public List<Comment> GetComments(int? id)
        {
            List<Post> posts = UsersList.Find(y => y?.Id == id)?.Posts;
            List<Comment> Сomments = new List<Comment>();
            posts?.ForEach(x => x?.Comments?.ForEach(y => Сomments?.Add(y)));
            Сomments = (from com in Сomments where com.Body.Length < 50 select com).ToList();
            return Сomments;
        }

    }
}
