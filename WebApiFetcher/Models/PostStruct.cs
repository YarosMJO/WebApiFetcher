namespace WebApiFetcher.Models
{
    public class PostStruct
    {
        public Post LatestPost { get; set; }
        public int? PostsCount { get; set; }
        public int? UnTodo { get; set; }
        public Post BestCommented { get; set; }
        public Post BestLiked { get; set; }
    }
}
