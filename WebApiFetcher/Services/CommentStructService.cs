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
            var comments = posts.Find(x => x?.id == postId)?.Comments;

            var longestComment = comments?.Find(x => x?.body?.Length == comments?.Max(y => y?.body?.Length));
            var mostLikedComment = comments?.Find(x => x?.likes == comments?.Max(y => y?.likes));
            var commentsCount = comments?.Where(x => x?.likes == 0 || x?.body?.Length < 80)?.ToList()?.Count;

            return new CommentStruct
            {
                longestComment = longestComment,
                mostLikedComment = mostLikedComment,
                commentsCount = commentsCount
            };
        }
    }
}
