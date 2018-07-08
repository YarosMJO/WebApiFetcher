using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace WebApiFetcher.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("likes")]
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
