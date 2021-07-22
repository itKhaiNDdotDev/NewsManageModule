using Microsoft.EntityFrameworkCore;
using NewsManageModule.Data.Configurations;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.EF
{
    public class NMMDbContext : DbContext
    {
        public NMMDbContext(/*[NotNullAttribute]*/ DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new TopicConfig());
            modelBuilder.ApplyConfiguration(new PostInTopicConfig);
            modelBuilder.ApplyConfiguration(new HistoryConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post>  Posts { get; set; }
        public DbSet<PostInTopic> PostsInTopics { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
