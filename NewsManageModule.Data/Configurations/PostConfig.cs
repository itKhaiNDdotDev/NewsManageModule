using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Posts");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).UseSqlServerIdentityColumn();
            builder.Property(h => h.Head).IsRequired().HasMaxLength(300).IsUnicode(true);
            builder.Property(c => c.Content).IsRequired().IsUnicode(true);
            builder.Property(t => t.Time).IsRequired();
            builder.Property(v => v.ViewCount).IsRequired().HasDefaultValue(0);
            builder.HasOne(u => u.Creator).WithMany(p => p.Posts).HasForeignKey(fk => fk.UserId);
        }
    }
}
