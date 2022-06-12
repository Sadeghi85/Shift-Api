// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ApiResources
    public partial class ApiResourceConfiguration : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable("ApiResources", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ApiResources").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("nvarchar(200)").IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.AllowedAccessTokenSigningAlgorithms).HasColumnName(@"AllowedAccessTokenSigningAlgorithms").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.ShowInDiscoveryDocument).HasColumnName(@"ShowInDiscoveryDocument").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Created).HasColumnName(@"Created").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.Updated).HasColumnName(@"Updated").HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.LastAccessed).HasColumnName(@"LastAccessed").HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.NonEditable).HasColumnName(@"NonEditable").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ApiResource> builder);
    }

}
// </auto-generated>
