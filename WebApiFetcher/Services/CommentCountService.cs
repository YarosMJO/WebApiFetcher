using System.Collections.Generic;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class CommentCountService: HelperService
    {
        public List<Post> GetCommentsCount(int? id)
        {
            return UsersList?.Find(y => y.Id.Equals(id))?.Posts; ;
        }
    }
}
