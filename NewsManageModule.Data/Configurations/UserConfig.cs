using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Users");
            builder.HasKey(i => i.UID);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(30).IsUnicode(false);
            builder.Property(n => n.Fullname).IsRequired().HasMaxLength(60);
            builder.Property(k => k.Password).IsRequired().IsUnicode(false);
            builder.Property(d => d.RegistDate).IsRequired();
        }
    }
}
