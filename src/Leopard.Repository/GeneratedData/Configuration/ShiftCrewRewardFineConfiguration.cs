// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Shift_CrewRewardFine
    public partial class ShiftCrewRewardFineConfiguration : IEntityTypeConfiguration<ShiftCrewRewardFine>
    {
        public void Configure(EntityTypeBuilder<ShiftCrewRewardFine> builder)
        {
            builder.ToTable("Shift_CrewRewardFine", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_CrewRewardFine").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ShiftTabletCrewId).HasColumnName(@"ShiftTabletCrewId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsReward).HasColumnName(@"IsReward").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.Shiftpercentage).HasColumnName(@"Shiftpercentage").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Ammount).HasColumnName(@"Ammount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"description").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ShiftShiftTabletCrew).WithMany(b => b.ShiftCrewRewardFines).HasForeignKey(c => c.ShiftTabletCrewId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_CrewRewardFine_Shift_ShiftTabletCrew");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftCrewRewardFine> builder);
    }

}
// </auto-generated>
