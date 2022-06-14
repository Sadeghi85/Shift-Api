// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // TelavatBuilderReviewsItems
    public partial class TelavatBuilderReviewsItemConfiguration : IEntityTypeConfiguration<TelavatBuilderReviewsItem>
    {
        public void Configure(EntityTypeBuilder<TelavatBuilderReviewsItem> builder)
        {
            builder.ToTable("TelavatBuilderReviewsItems", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatBuilderReviewsPlaybacks").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.BuilderReviewId).HasColumnName(@"BuilderReviewID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired();
            builder.Property(x => x.Item).HasColumnName(@"Item").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);

            // Foreign keys
            builder.HasOne(a => a.SamtBuilderReview).WithMany(b => b.TelavatBuilderReviewsItems).HasForeignKey(c => c.BuilderReviewId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatBuilderReviewsItems_TelavatBuilderReviews");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TelavatBuilderReviewsItem> builder);
    }

}
// </auto-generated>