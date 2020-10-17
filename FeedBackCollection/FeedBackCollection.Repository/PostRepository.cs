using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;
using FeedBackCollection.Entities.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FeedBackCollection.Repository
{
   public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Post> GetAllPosts(string key,int pageNo,int pageSize, bool trackChanges)
        {
            return FindAllByCondition(s => s.Name.Contains(key),pageNo,pageSize,
                s=>s.Include(x=>x.Comments),trackChanges);
        }

        public Post GetPost(Guid postId, bool trackChanges)=>
            FindByCondition(c => c.Id.Equals(postId), trackChanges).SingleOrDefault();


        public void CreatePost(Post post)
        {
            post.CreatedDate=DateTime.Now;
            Create(post);
        }

        public void DeletePost(Guid id)
        {
            var isfound = FindByCondition(c => c.Id.Equals(id), false).SingleOrDefault();
            if (isfound!=null)
            {
                Delete(isfound);
            }
            
        }
    }
}
