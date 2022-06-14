// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorDispatchDetails
    public partial class ConductorDispatchDetailConfiguration : IEntityTypeConfiguration<ConductorDispatchDetail>
    {
        public void Configure(EntityTypeBuilder<ConductorDispatchDetail> builder)
        {
            builder.ToTable("ConductorDispatchDetails", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorDispatchTimes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.StartTime).HasColumnName(@"StartTime").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.EndTime).HasColumnName(@"EndTime").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.ConductorDispatchId).HasColumnName(@"ConductorDispatchID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ConductorId).HasColumnName(@"ConductorId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProblemId).HasColumnName(@"ProblemID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TadvinDispatchId).HasColumnName(@"TadvinDispatchID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TadvinAnswer).HasColumnName(@"TadvinAnswer").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.TadvinAnswerDate).HasColumnName(@"TadvinAnswerDate").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ConductorItemDispatch).WithMany(b => b.ConductorDispatchDetails).HasForeignKey(c => c.TadvinDispatchId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorDispatchDetails_ConductorItemDispatch1");
            builder.HasOne(a => a.InsideBaseInfo).WithMany(b => b.ConductorDispatchDetails).HasForeignKey(c => c.ProblemId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorDispatchDetails_InsideBaseInfo");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorDispatchDetail> builder);
    }

}
// </auto-generated>