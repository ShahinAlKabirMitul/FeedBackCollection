using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Contracts;

namespace Contracts
{
   public interface IRepositoryManager
    {
        IPostRepository Post { get;}
        ILogRepository Log { get; }
        ICommentRepository Comment { get; }
        IVoteRepository Vote { get; }

        bool Save();
    }
}
