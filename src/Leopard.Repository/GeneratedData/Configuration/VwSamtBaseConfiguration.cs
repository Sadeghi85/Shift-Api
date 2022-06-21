// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // VW_SAMT_Base
    public partial class VwSamtBaseConfiguration : IEntityTypeConfiguration<VwSamtBase>
    {
        public void Configure(EntityTypeBuilder<VwSamtBase> builder)
        {
            builder.ToView("VW_SAMT_Base", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Program).HasColumnName(@"Program").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.BaseYear).HasColumnName(@"BaseYear").HasColumnType("int").IsRequired();
            builder.Property(x => x.InitialBaseYear).HasColumnName(@"initialBaseYear").HasColumnType("int").IsRequired();
            builder.Property(x => x.InitialTime).HasColumnName(@"InitialTime").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LicenseProgramTime).HasColumnName(@"LicenseProgramTime").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LicenseProgramCount).HasColumnName(@"LicenseProgramCount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LpcMain).HasColumnName(@"lpcMain").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LptMain).HasColumnName(@"lptMain").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.InitialCount).HasColumnName(@"InitialCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.InitialPayment).HasColumnName(@"InitialPayment").HasColumnType("float").HasPrecision(53).IsRequired();
            builder.Property(x => x.BaseYearTime).HasColumnName(@"BaseYearTime").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseYearCount).HasColumnName(@"BaseYearCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseYearPayment).HasColumnName(@"BaseYearPayment").HasColumnType("float").HasPrecision(53).IsRequired();
            builder.Property(x => x.MinuteRate).HasColumnName(@"MinuteRate").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.EstimateDate).HasColumnName(@"EstimateDate").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.EstimateNumer).HasColumnName(@"EstimateNumer").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.LicenseNumber).HasColumnName(@"LicenseNumber").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.GroupId).HasColumnName(@"GroupID").HasColumnType("int").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.PartFrom).HasColumnName(@"PartFrom").HasColumnType("int").IsRequired();
            builder.Property(x => x.PartTo).HasColumnName(@"PartTo").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.StructureId).HasColumnName(@"StructureID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProgramGradeId).HasColumnName(@"ProgramGradeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.StructureTypeId).HasColumnName(@"StructureTypeID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.HasRevisoryEstimation).HasColumnName(@"HasRevisoryEstimation").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.EvaluateDate).HasColumnName(@"EvaluateDate").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.NumberParticipation).HasColumnName(@"NumberParticipation").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.TheParticipation).HasColumnName(@"TheParticipation").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.LastEstimateDate).HasColumnName(@"LastEstimateDate").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Flags).HasColumnName(@"Flags").HasColumnType("char(3)").IsRequired(false).IsFixedLength().IsUnicode(false).HasMaxLength(3);
            builder.Property(x => x.ProductionStartDate).HasColumnName(@"ProductionStartDate").HasColumnType("nchar(10)").IsRequired(false).IsFixedLength().HasMaxLength(10);
            builder.Property(x => x.ProductionEndtDate).HasColumnName(@"ProductionEndtDate").HasColumnType("nchar(10)").IsRequired(false).IsFixedLength().HasMaxLength(10);
            builder.Property(x => x.ProductionMode).HasColumnName(@"ProductionMode").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LivePercent).HasColumnName(@"LivePercent").HasColumnType("int").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<VwSamtBase> builder);
    }

}
// </auto-generated>
