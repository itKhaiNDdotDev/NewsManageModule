using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsManageModule.Data.Configurations;
using NewsManageModule.Data.Entities;
using NewsManageModule.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.EF
{
    public class NMMDbContext : /*DbContext*/ IdentityDbContext<User, Role, Guid>
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
            modelBuilder.ApplyConfiguration(new PostInTopicConfig());
            modelBuilder.ApplyConfiguration(new HistoryConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post>  Posts { get; set; }
        public DbSet<PostInTopic> PostsInTopics { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
