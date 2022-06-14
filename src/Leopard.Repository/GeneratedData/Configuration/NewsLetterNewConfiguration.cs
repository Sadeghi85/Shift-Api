// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // NewsLetterNews
    public partial class NewsLetterNewConfiguration : IEntityTypeConfiguration<NewsLetterNew>
    {
        public void Configure(EntityTypeBuilder<NewsLetterNew> builder)
        {
            builder.ToTable("NewsLetterNews", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_NewsLetterNews").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.NewsId).HasColumnName(@"NewsID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsSend).HasColumnName(@"IsSend").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.News).WithMany(b => b.NewsLetterNews).HasForeignKey(c => c.NewsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_NewsLetterNews_News");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<NewsLetterNew> builder);
    }

}
// </auto-generated>