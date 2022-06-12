// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorAutoFileNumber
    public partial class ConductorAutoFileNumberConfiguration : IEntityTypeConfiguration<ConductorAutoFileNumber>
    {
        public void Configure(EntityTypeBuilder<ConductorAutoFileNumber> builder)
        {
            builder.ToTable("ConductorAutoFileNumber", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorAutoFileNumber").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.UidLevel).HasColumnName(@"UIDLevel").HasColumnType("nchar(2)").IsRequired(false).IsFixedLength().HasMaxLength(2);
            builder.Property(x => x.EstimateGid).HasColumnName(@"EstimateGID").HasColumnType("nchar(3)").IsRequired(false).IsFixedLength().HasMaxLength(3);
            builder.Property(x => x.Year).HasColumnName(@"year").HasColumnType("nchar(2)").IsRequired(false).IsFixedLength().HasMaxLength(2);
            builder.Property(x => x.Month).HasColumnName(@"month").HasColumnType("nchar(2)").IsRequired(false).IsFixedLength().HasMaxLength(2);
            builder.Property(x => x.Day).HasColumnName(@"day").HasColumnType("nchar(2)").IsRequired(false).IsFixedLength().HasMaxLength(2);
            builder.Property(x => x.DaylyCount).HasColumnName(@"DaylyCount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Result).HasColumnName(@"Result").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorAutoFileNumber> builder);
    }

}
// </auto-generated>
