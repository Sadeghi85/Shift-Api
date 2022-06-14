// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ImageAlbums
    public partial class ImageAlbumConfiguration : IEntityTypeConfiguration<ImageAlbum>
    {
        public void Configure(EntityTypeBuilder<ImageAlbum> builder)
        {
            builder.ToTable("ImageAlbums", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ImageAlbum").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.GalleryId).HasColumnName(@"GalleryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.PhotographerName).HasColumnName(@"PhotographerName").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ImageGallery).WithMany(b => b.ImageAlbums).HasForeignKey(c => c.GalleryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ImageAlbums_ImageGalleries");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ImageAlbum> builder);
    }

}
// </auto-generated>