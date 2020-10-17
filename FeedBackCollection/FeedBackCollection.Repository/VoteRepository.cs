using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Repository
{
   public class VoteRepository : RepositoryBase<Vote>, IVoteRepository
    {
        public VoteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateVote(Vote vote)
        {
            Create(vote);
        }

        public void UpdateVote(Vote vote)
        {
            Update(vote);
        }

        public Vote FindVote(Guid commentID, string userName)
        {
          return  FindByCondition(s => s.CommentId == commentID && s.CreatedBy == userName,false).FirstOrDefault();
        }
    }
}
