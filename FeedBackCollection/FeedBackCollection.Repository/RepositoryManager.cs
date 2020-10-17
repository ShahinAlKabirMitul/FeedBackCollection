using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;

namespace FeedBackCollection.Repository
{
   public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IPostRepository _postRepository;
        private ILogRepository _LogRepository;
        private ICommentRepository _commentRepository;
        private IVoteRepository _voteRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

       
        public IPostRepository Post
        {
            get
            {
                if (_postRepository == null) _postRepository = new PostRepository(_repositoryContext);
                return _postRepository;
            }
            
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_commentRepository == null) _commentRepository = new CommentRepository(_repositoryContext);
                return _commentRepository;
            }

        }

        public ILogRepository Log
        {
            get
            {
                if (_LogRepository == null) _LogRepository = new LogRepository(_repositoryContext);
                return _LogRepository;
            }
        }

        public IVoteRepository Vote
        {
            get
            {
                if (_voteRepository == null) _voteRepository = new VoteRepository(_repositoryContext);
                return _voteRepository;
            }
        }

        public bool Save()
        {
           return _repositoryContext.SaveChanges()>0;
        }
    }
}
