using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;
using FeedBackCollection.Entities.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedBackCollection.Repository
{
    class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Comment> GetComments(Guid postId, bool trackChanges) =>
            FindByCondition(x => x.Post.Equals(postId), trackChanges).OrderByDescending(s => s.CreatedDate);


        public Comment GetComment(Guid postId, Guid id, bool trackChanges)=>
            FindByCondition(x => x.Post.Equals(postId) && x.Id == id, trackChanges).SingleOrDefault();

        public void CreateCommentForPost( Comment comment)
        {
            comment.NoOfDislike = 0;
            comment.NoOfLike = 0;
            comment.CreatedDate=DateTime.Now;
            Create(comment);
        }

        public void UpdateRating(Guid commentId, bool isLike,bool toggle=false)
        {
           var isfound= FindByCondition(s => s.Id.Equals(commentId),false).FirstOrDefault();
           if (isfound!=null)
           {
               if (!toggle)
               {
                   if (isLike)
                   {
                       isfound.NoOfLike += 1;
                   }
                   else
                   {
                       isfound.NoOfDislike += 1;
                   }
                   Update(isfound);
                }
               else
               {

                   if (isLike)
                   {
                       isfound.NoOfLike += 1;
                       isfound.NoOfDislike -= 1;
                   }
                   else
                   {
                       isfound.NoOfLike -= 1;
                       isfound.NoOfDislike += 1;
                   }
                   Update(isfound);
                }
               
              
           }
        }

        public void DeleteComment(Guid id)
        {
            var isfound = FindByCondition(c => c.Id.Equals(id), false).SingleOrDefault();
            if (isfound != null)
            {
                Delete(isfound);
            }
        }
    }
}
