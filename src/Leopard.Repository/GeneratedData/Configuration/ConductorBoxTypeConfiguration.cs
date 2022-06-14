// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorBoxTypes
    public partial class ConductorBoxTypeConfiguration : IEntityTypeConfiguration<ConductorBoxType>
    {
        public void Configure(EntityTypeBuilder<ConductorBoxType> builder)
        {
            builder.ToTable("ConductorBoxTypes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorBoxItemTypes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Code).HasColumnName(@"Code").HasColumnType("char(2)").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(2);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            builder.HasIndex(x => x.Code).HasDatabaseName("IX_ConductorBoxTypes").IsUnique();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorBoxType> builder);
    }

}
// </auto-generated>