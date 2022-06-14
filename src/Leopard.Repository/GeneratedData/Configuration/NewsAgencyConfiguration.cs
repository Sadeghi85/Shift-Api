// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // NewsAgencies
    public partial class NewsAgencyConfiguration : IEntityTypeConfiguration<NewsAgency>
    {
        public void Configure(EntityTypeBuilder<NewsAgency> builder)
        {
            builder.ToTable("NewsAgencies", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_NewsAgencies").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(400)").IsRequired().HasMaxLength(400);
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IconUri).HasColumnName(@"IconURI").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.PictureUri).HasColumnName(@"PictureURI").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Parent).WithMany(b => b.NewsAgencies).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_NewsAgencies_NewsAgencies");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<NewsAgency> builder);
    }

}
// </auto-generated>