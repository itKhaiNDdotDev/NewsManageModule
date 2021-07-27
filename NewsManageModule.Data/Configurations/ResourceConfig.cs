using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Resources");
            builder.HasKey(i => i.RID);
            builder.Property(i => i.RID).UseSqlServerIdentityColumn();
            builder.Property(p => p.URL).IsRequired().HasMaxLength(200).IsUnicode(false);
            builder.Property(c => c.Caption).IsRequired().HasMaxLength(300).IsUnicode(true);
            builder.HasOne(p => p.Post).WithMany(r => r.Resources).HasForeignKey(fk => fk.ID);
        }
    }
}
