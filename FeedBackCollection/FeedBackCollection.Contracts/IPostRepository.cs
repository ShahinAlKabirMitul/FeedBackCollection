using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Contracts
{
   public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts(string key,int pageNo,int pageSize, bool trackChanges);
        Post GetPost(Guid postId, bool trackChanges);
        void CreatePost(Post post);
       
        void DeletePost(Guid postIdt);

        

    }
}
