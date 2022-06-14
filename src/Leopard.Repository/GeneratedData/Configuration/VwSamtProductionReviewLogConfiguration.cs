// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // VW_SAMT_ProductionReviewLog
    public partial class VwSamtProductionReviewLogConfiguration : IEntityTypeConfiguration<VwSamtProductionReviewLog>
    {
        public void Configure(EntityTypeBuilder<VwSamtProductionReviewLog> builder)
        {
            builder.ToView("VW_SAMT_ProductionReviewLog", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.BaseYear).HasColumnName(@"BaseYear").HasColumnType("int").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProductionTime).HasColumnName(@"ProductionTime").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.Flags).HasColumnName(@"Flags").HasColumnType("char(3)").IsRequired(false).IsFixedLength().IsUnicode(false).HasMaxLength(3);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<VwSamtProductionReviewLog> builder);
    }

}
// </auto-generated>