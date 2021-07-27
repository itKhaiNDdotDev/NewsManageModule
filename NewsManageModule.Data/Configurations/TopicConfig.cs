using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Topics");
            builder.HasKey(i => i.TID);
            builder.Property(i => i.TID).UseSqlServerIdentityColumn();
            builder.Property(n => n.TName).IsRequired().HasMaxLength(100).IsUnicode(true);
        }
    }
}
