// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ImageViewer
    public partial class ImageViewerConfiguration : IEntityTypeConfiguration<ImageViewer>
    {
        public void Configure(EntityTypeBuilder<ImageViewer> builder)
        {
            builder.ToTable("ImageViewer", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ImageViewer").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Imagefile).HasColumnName(@"Imagefile").HasColumnType("nvarchar(2000)").IsRequired(false).HasMaxLength(2000);
            builder.Property(x => x.LinkUrl).HasColumnName(@"LinkURL").HasColumnType("nvarchar(2000)").IsRequired(false).HasMaxLength(2000);
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ToolTip).HasColumnName(@"ToolTip").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ImageViewer> builder);
    }

}
// </auto-generated>
