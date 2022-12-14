// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // Shift_AgentReport
    public partial class ShiftAgentReportConfiguration : IEntityTypeConfiguration<ShiftAgentReport>
    {
        public void Configure(EntityTypeBuilder<ShiftAgentReport> builder)
        {
            builder.ToTable("Shift_AgentReport", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_AgentReport").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.FromDate).HasColumnName(@"FromDate").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.ToDate).HasColumnName(@"ToDate").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.AttendedTotalShifts).HasColumnName(@"AttendedTotalShifts").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.AttendedRequiredShifts).HasColumnName(@"AttendedRequiredShifts").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.AttendedUnRequiredShifts).HasColumnName(@"AttendedUnRequiredShifts").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.TotalReward).HasColumnName(@"TotalReward").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TotalFine).HasColumnName(@"TotalFine").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TotalShiftCount).HasColumnName(@"TotalShiftCount").HasColumnType("int").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftAgentReport> builder);
    }

}
// </auto-generated>
