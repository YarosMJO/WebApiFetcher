using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiFetcher.Models;

namespace WebApiFetcher
{
    public class HelperService
    {
        HttpClient client;
        public HelperService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<T>> GetAsync<T>(string path)
        {
            List<T> data = null;
            String response = await client.GetStringAsync(path);
            data = JsonConvert.DeserializeObject<List<T>>(response);
            return data;
        }
        public async Task<List<User>> RunAsync()
        {

            try
            {

                List<User> Users = await GetAsync<User>("https://5b128555d50a5c0014ef1204.mockapi.io/users");
                List<Todo> Todos = await GetAsync<Todo>("https://5b128555d50a5c0014ef1204.mockapi.io/todos");
                List<Post> Posts = await GetAsync<Post>("https://5b128555d50a5c0014ef1204.mockapi.io/posts");
                List<Comment> Comments = await GetAsync<Comment>("https://5b128555d50a5c0014ef1204.mockapi.io/comments");

                var PostsWithComments = from p in Posts
                                        join c in Comments on p.Id equals c.PostId
                                        select (Posts: p.Id, p.CreatedAt, p.Title, p.Body, p.UserId, p.Likes, p.Comments = Comments);

                List<User> result = (from u in Users
                                     join p in PostsWithComments on u.Id equals p.UserId
                                     join t in Todos on u.Id equals t.UserId
                                     select new User
                                     {
                                         Id = u.Id,
                                         CreatedAt = u.CreatedAt,
                                         Name = u.Name,
                                         Avatar = u.Avatar,
                                         Email = u.Email,
                                         Posts = u.Posts = Posts,
                                         Todos = u.Todos = Todos
                                     }).ToList();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }

        }
    }
}