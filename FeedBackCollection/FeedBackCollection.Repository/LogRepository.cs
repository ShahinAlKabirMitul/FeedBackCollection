using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Repository
{
   public class LogRepository : RepositoryBase<LogInfo>, ILogRepository
    {
        public LogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void LogInfo(LogInfo logInfo)
        {
            Create(logInfo);
        }
    }
}
