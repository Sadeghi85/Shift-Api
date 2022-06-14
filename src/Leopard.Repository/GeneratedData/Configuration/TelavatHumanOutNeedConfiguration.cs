// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // TelavatHumanOutNeeds
    public partial class TelavatHumanOutNeedConfiguration : IEntityTypeConfiguration<TelavatHumanOutNeed>
    {
        public void Configure(EntityTypeBuilder<TelavatHumanOutNeed> builder)
        {
            builder.ToTable("TelavatHumanOutNeeds", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatHumanOutNeeds").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.UnitId).HasColumnName(@"UnitID").HasColumnType("int").IsRequired();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Count).HasColumnName(@"Count").HasColumnType("int").IsRequired();
            builder.Property(x => x.SubCount).HasColumnName(@"SubCount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.FeeType).HasColumnName(@"FeeType").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EstimatedFee).HasColumnName(@"EstimatedFee").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.EvaluatedFee).HasColumnName(@"EvaluatedFee").HasColumnType("float").HasPrecision(53).IsRequired(false);
            builder.Property(x => x.JobTitle).HasColumnName(@"JobTitle").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Remarks).HasColumnName(@"Remarks").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Fee).HasColumnName(@"Fee").HasColumnType("float").HasPrecision(53).IsRequired();

            // Foreign keys
            builder.HasOne(a => a.TelavatUnit).WithMany(b => b.TelavatHumanOutNeeds).HasForeignKey(c => c.UnitId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatHumanOutNeeds_TelavatUnits");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TelavatHumanOutNeed> builder);
    }

}
// </auto-generated>