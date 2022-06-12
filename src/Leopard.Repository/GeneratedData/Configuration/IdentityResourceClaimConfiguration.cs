// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // IdentityResourceClaims
    public partial class IdentityResourceClaimConfiguration : IEntityTypeConfiguration<IdentityResourceClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            builder.ToTable("IdentityResourceClaims", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_IdentityResourceClaims").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IdentityResourceId).HasColumnName(@"IdentityResourceId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);

            // Foreign keys
            builder.HasOne(a => a.IdentityResource).WithMany(b => b.IdentityResourceClaims).HasForeignKey(c => c.IdentityResourceId).HasConstraintName("FK_IdentityResourceClaims_IdentityResources_IdentityResourceId");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<IdentityResourceClaim> builder);
    }

}
// </auto-generated>
