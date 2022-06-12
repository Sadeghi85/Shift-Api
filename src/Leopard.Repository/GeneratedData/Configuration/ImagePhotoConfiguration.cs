// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ImagePhotos
    public partial class ImagePhotoConfiguration : IEntityTypeConfiguration<ImagePhoto>
    {
        public void Configure(EntityTypeBuilder<ImagePhoto> builder)
        {
            builder.ToTable("ImagePhotos", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ImagePhoto").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AlbumId).HasColumnName(@"AlbumID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.PhotoByte).HasColumnName(@"PhotoByte").HasColumnType("varbinary(max)").IsRequired(false);
            builder.Property(x => x.PhotoType).HasColumnName(@"PhotoType").HasColumnType("nvarchar(5)").IsRequired().HasMaxLength(5);
            builder.Property(x => x.Selected).HasColumnName(@"Selected").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SelectedGallery).HasColumnName(@"SelectedGallery").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SaveInDb).HasColumnName(@"SaveInDB").HasColumnType("bit").IsRequired();
            builder.Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Thumbnail).HasColumnName(@"Thumbnail").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Thumbnail2).HasColumnName(@"Thumbnail2").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ImageAlbum).WithMany(b => b.ImagePhotoes).HasForeignKey(c => c.AlbumId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ImagePhotos_ImageAlbums");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ImagePhoto> builder);
    }

}
// </auto-generated>
