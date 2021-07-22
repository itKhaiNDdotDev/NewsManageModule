using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Configurations
{
    public class HistoryConfig : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Histories");
            builder.HasKey(i => i.HID);
            builder.Property(t => t.EditTime).IsRequired();
            builder.Property(h => h.OldHeader).IsRequired().HasMaxLength(300).IsUnicode(true);
            builder.Property(h => h.NewHeader).IsRequired().HasMaxLength(300).IsUnicode(true);
            builder.Property(c => c.OldContent).IsRequired().IsUnicode(true);
            builder.Property(c => c.OldContent).IsRequired().IsUnicode(true);
            builder.HasOne(p => p.Post).WithMany(e => e.Histories).HasForeignKey(fk => fk.ID);  //1 Post - can have - many Histories (Edits)
            builder.HasOne(u => u.Editor).WithMany(e => e.Edits).HasForeignKey(fk => fk.UID);   //1 Editor (User) - can do - many Edits (Histories)
        }
    }
}
