// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // View_SendFile3
    public partial class ViewSendFile3Configuration : IEntityTypeConfiguration<ViewSendFile3>
    {
        public void Configure(EntityTypeBuilder<ViewSendFile3> builder)
        {
            builder.ToView("View_SendFile3", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CategoryId).HasColumnName(@"CategoryID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CategoryName).HasColumnName(@"CategoryName").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.PortalName).HasColumnName(@"PortalName").HasColumnType("nvarchar(401)").IsRequired().HasMaxLength(401);
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.DateFile).HasColumnName(@"DateFile").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.ReminderTimeId).HasColumnName(@"ReminderTimeID").HasColumnType("int").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ViewSendFile3> builder);
    }

}
// </auto-generated>
