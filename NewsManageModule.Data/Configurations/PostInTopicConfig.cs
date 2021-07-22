using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class PostInTopicConfig : IEntityTypeConfiguration<PostInTopic>
    {
        public void Configure(EntityTypeBuilder<PostInTopic> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("PostsInTopics");
            builder.HasKey(i => new { i.ID, i.TID } );
            builder.HasOne(p => p.Post).WithMany(pt => pt.PostInTopics).HasForeignKey(fk => fk.ID);
            builder.HasOne(t => t.Topic).WithMany(pt => pt.PostsInTopic).HasForeignKey(fk => fk.TID);
        }
    }
}
