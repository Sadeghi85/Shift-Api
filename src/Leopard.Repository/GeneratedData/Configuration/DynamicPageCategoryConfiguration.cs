// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // DynamicPageCategories
    public partial class DynamicPageCategoryConfiguration : IEntityTypeConfiguration<DynamicPageCategory>
    {
        public void Configure(EntityTypeBuilder<DynamicPageCategory> builder)
        {
            builder.ToTable("DynamicPageCategories", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_DynamicPageCategory").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CategoryAlias).HasColumnName(@"CategoryAlias").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<DynamicPageCategory> builder);
    }

}
// </auto-generated>
