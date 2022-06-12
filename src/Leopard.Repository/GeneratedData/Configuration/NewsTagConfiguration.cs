// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // NewsTags
    public partial class NewsTagConfiguration : IEntityTypeConfiguration<NewsTag>
    {
        public void Configure(EntityTypeBuilder<NewsTag> builder)
        {
            builder.ToTable("NewsTags", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_NewsTags_1").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.NewsId).HasColumnName(@"NewsID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(max)").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.News).WithMany(b => b.NewsTags).HasForeignKey(c => c.NewsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_NewsTags_News");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<NewsTag> builder);
    }

}
// </auto-generated>
