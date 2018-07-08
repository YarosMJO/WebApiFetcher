using Newtonsoft.Json;
using System;
namespace WebApiFetcher.Models
{
    public class Todo : IComparable
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("isComplete")]
        public bool IsComplete { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }

        public int CompareTo(object obj)
        {
            return Name.Length.CompareTo(obj.ToString().Length);
        }
    }
}
