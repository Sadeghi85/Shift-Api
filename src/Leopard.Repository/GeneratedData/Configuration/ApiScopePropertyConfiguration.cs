// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ApiScopeProperties
    public partial class ApiScopePropertyConfiguration : IEntityTypeConfiguration<ApiScopeProperty>
    {
        public void Configure(EntityTypeBuilder<ApiScopeProperty> builder)
        {
            builder.ToTable("ApiScopeProperties", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ApiScopeProperties").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ScopeId).HasColumnName(@"ScopeId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Key).HasColumnName(@"Key").HasColumnType("nvarchar(250)").IsRequired().HasMaxLength(250);
            builder.Property(x => x.Value).HasColumnName(@"Value").HasColumnType("nvarchar(2000)").IsRequired().HasMaxLength(2000);

            // Foreign keys
            builder.HasOne(a => a.ApiScope).WithMany(b => b.ApiScopeProperties).HasForeignKey(c => c.ScopeId).HasConstraintName("FK_ApiScopeProperties_ApiScopes_ScopeId");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ApiScopeProperty> builder);
    }

}
// </auto-generated>
