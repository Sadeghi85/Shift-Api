// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // BaseInfos
    public partial class BaseInfoConfiguration : IEntityTypeConfiguration<BaseInfo>
    {
        public void Configure(EntityTypeBuilder<BaseInfo> builder)
        {
            builder.ToTable("BaseInfos", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_BaseInfos").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.BaseInfoCategoryId).HasColumnName(@"BaseInfoCategoryID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Value).HasColumnName(@"Value").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.BaseInfoCategory).WithMany(b => b.BaseInfoes).HasForeignKey(c => c.BaseInfoCategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BaseInfos_BaseInfoCategories");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<BaseInfo> builder);
    }

}
// </auto-generated>
