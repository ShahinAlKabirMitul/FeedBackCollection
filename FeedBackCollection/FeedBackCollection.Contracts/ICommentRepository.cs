using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Contracts
{
   public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments(Guid postId, bool trackChanges);
        Comment GetComment(Guid postId, Guid id, bool trackChanges);
        void CreateCommentForPost( Comment comment);
        void UpdateRating(Guid commentId, bool isLike,bool toggle=false);
        void DeleteComment(Guid id);
    }
}
