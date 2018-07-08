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
        public List<User> UsersList { get; private set; }
        HttpClient client;
        public HelperService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            UsersList = RunAsync().Result;
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

                var WithComments = Posts.GroupJoin(Comments,post => post.Id, comment => comment.PostId,(post, commentList) =>
                new Post()
                {
                    Id = post.Id,
                    CreatedAt = post.CreatedAt,
                    Title = post.Title,
                    Body = post.Body,
                    UserId = post.UserId,
                    Likes = post.Likes,
                    Comments = commentList.Where(comment => comment.PostId == post.Id).ToList()
                });

                var WithPosts = Users.GroupJoin(WithComments, user => user.Id, post => post.UserId,(user, postList) =>
                new User{
                        Id = user.Id,
                        CreatedAt = user.CreatedAt,
                        Name = user.Name,
                        Avatar = user.Avatar,
                        Email = user.Email,
                        Posts = postList.Where(post => post.UserId == user.Id).ToList()
                    });

                var Joined = WithPosts.GroupJoin(Todos,user => user.Id, todo => todo.UserId,(user, todoList) =>
                new User {
                      Id = user.Id,
                      CreatedAt = user.CreatedAt,
                      Name = user.Name,
                      Avatar = user.Avatar,
                      Email = user.Email,
                      Posts = user.Posts,
                      Todos = todoList.Where(todo => todo.UserId == user.Id).ToList()
                  }).ToList();
                return Joined;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }

        }
    }
}