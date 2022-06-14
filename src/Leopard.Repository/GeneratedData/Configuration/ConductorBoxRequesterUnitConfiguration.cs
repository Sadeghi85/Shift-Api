// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorBoxRequesterUnit
    public partial class ConductorBoxRequesterUnitConfiguration : IEntityTypeConfiguration<ConductorBoxRequesterUnit>
    {
        public void Configure(EntityTypeBuilder<ConductorBoxRequesterUnit> builder)
        {
            builder.ToTable("ConductorBoxRequesterUnit", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorBoxRequesterUnit").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorBoxRequesterUnit> builder);
    }

}
// </auto-generated>