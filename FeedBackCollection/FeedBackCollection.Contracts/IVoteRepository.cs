using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Contracts
{
   public interface IVoteRepository
    {
        void CreateVote(Vote vote);
        void UpdateVote(Vote vote);
        Vote FindVote(Guid commentID, string userName);
    }
}
