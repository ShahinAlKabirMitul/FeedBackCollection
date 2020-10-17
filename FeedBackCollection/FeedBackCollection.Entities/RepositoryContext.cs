using System;
using System.Collections.Generic;
using System.Text;
using FeedBackCollection.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace FeedBackCollection.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<Post> Posts { get; set; }
        public DbSet<LogInfo> LogInfos { get; set; }
      
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

    }

}
