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
        public PostStruct GetPostStructure(int? id)
        {
            var user = UsersList.FirstOrDefault(y => y.Id == id);

            var latestPost = user?.Posts?.FirstOrDefault(x => x?.CreatedAt == user?.Posts?.Max(y => y?.CreatedAt));
            var postsCount = latestPost?.Comments?.Count();
            var unTodo = user?.Todos?.Where(x => x?.IsComplete != true)?.Count();
            var bestCommented = user?.Posts?.FirstOrDefault(x => x?.Comments?.Count > 80);
            var bestLiked = user?.Posts?.Where(x => x?.Likes == user?.Posts.Max(y => y?.Likes))?.First();

            return new PostStruct()
            {
                LatestPost = latestPost ?? null,
                PostsCount = postsCount ?? 0,
                UnTodo = unTodo ?? 0,
                BestCommented = bestCommented ?? null,
                BestLiked = bestLiked ?? null
            };
        }
    }
}
