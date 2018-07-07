using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFetcher;
using WebApiFetcher.Models;

namespace WebCoreApi.Services
{
    public class PostService: HelperService
    {
        public async Task<PostStruct> GetPostStructureAsync(int? id)
        {
            List<User> users = await RunAsync();
            var user = users.FirstOrDefault(y => y.id == id);

            var latestPost = user?.Posts?.FirstOrDefault(x => x?.createdAt == user?.Posts?.Max(y => y?.createdAt));
            var postsCount = latestPost?.Comments?.Count();
            var unTodo = user?.Todos?.Where(x => x?.isComplete != true)?.Count();
            var bestCommented = user?.Posts?.FirstOrDefault(x => x?.Comments?.Count > 80);
            var bestLiked = user?.Posts?.Where(x => x?.likes == user?.Posts.Max(y => y?.likes))?.First();

            return new PostStruct()
            {
                latestPost = latestPost ?? null,
                postsCount = postsCount ?? 0,
                unTodo = unTodo ?? 0,
                bestCommented = bestCommented ?? null,
                bestLiked = bestLiked ?? null
            };
        }
    }
}
