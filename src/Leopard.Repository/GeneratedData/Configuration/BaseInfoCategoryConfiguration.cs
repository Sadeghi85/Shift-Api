// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // BaseInfoCategories
    public partial class BaseInfoCategoryConfiguration : IEntityTypeConfiguration<BaseInfoCategory>
    {
        public void Configure(EntityTypeBuilder<BaseInfoCategory> builder)
        {
            builder.ToTable("BaseInfoCategories", "dbo");
            builder.HasKey(x => x.BaseCategoryId).HasName("PK_BaseInfoCategories").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.BaseCategoryId).HasColumnName(@"BaseCategoryID").HasColumnType("int").IsRequired().ValueGeneratedNever();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<BaseInfoCategory> builder);
    }

}
// </auto-generated>
