using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class CommentStructService: HelperService
    {
        public async Task<CommentStruct> GetCommentStructureAsync(int? postId)
        {
            List<User> users = await RunAsync();
            var posts = users.SelectMany(x => x?.Posts).ToList();
            var comments = posts.Find(x => x?.Id == postId)?.Comments;

            var longestComment = comments?.Find(x => x?.Body?.Length == comments?.Max(y => y?.Body?.Length));
            var mostLikedComment = comments?.Find(x => x?.Likes == comments?.Max(y => y?.Likes));
            var commentsCount = comments?.Where(x => x?.Likes == 0 || x?.Body?.Length < 80)?.ToList()?.Count;

            return new CommentStruct
            {
                LongestComment = longestComment,
                MostLikedComment = mostLikedComment,
                CommentsCount = commentsCount
            };
        }
    }
}
