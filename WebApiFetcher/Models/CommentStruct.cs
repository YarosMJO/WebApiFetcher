namespace WebApiFetcher.Models
{
    public class CommentStruct
    {
        public Comment LongestComment { get; set; }
        public Comment MostLikedComment { get; set; }
        public int? CommentsCount { get; set; }
    }
}
