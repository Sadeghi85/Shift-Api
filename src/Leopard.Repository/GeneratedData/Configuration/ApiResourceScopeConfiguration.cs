// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ApiResourceScopes
    public partial class ApiResourceScopeConfiguration : IEntityTypeConfiguration<ApiResourceScope>
    {
        public void Configure(EntityTypeBuilder<ApiResourceScope> builder)
        {
            builder.ToTable("ApiResourceScopes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ApiResourceScopes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Scope).HasColumnName(@"Scope").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.ApiResourceId).HasColumnName(@"ApiResourceId").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.ApiResource).WithMany(b => b.ApiResourceScopes).HasForeignKey(c => c.ApiResourceId).HasConstraintName("FK_ApiResourceScopes_ApiResources_ApiResourceId");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ApiResourceScope> builder);
    }

}
// </auto-generated>
