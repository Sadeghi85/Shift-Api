// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Links
    public partial class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Links", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Link").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CategoryId).HasColumnName(@"CategoryID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.Uri).HasColumnName(@"URI").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageShowType).HasColumnName(@"ImageShowType").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.Class).HasColumnName(@"Class").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsSelected).HasColumnName(@"IsSelected").HasColumnType("bit").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.LinkCategory).WithMany(b => b.Links).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Link_LinkCategory");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Link> builder);
    }

}
// </auto-generated>
