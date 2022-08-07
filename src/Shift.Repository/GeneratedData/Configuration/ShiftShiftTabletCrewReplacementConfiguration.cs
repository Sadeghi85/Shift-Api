// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // Shift_ShiftTabletCrewReplacement
    public partial class ShiftShiftTabletCrewReplacementConfiguration : IEntityTypeConfiguration<ShiftShiftTabletCrewReplacement>
    {
        public void Configure(EntityTypeBuilder<ShiftShiftTabletCrewReplacement> builder)
        {
            builder.ToTable("Shift_ShiftTabletCrewReplacement", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_ShiftTabletCrewReplacement").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ShiftTabletCrewId).HasColumnName(@"ShiftTabletCrewID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.OldAgentId).HasColumnName(@"OldAgentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.NewAgentId).HasColumnName(@"NewAgentID").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.NewAgent).WithMany(b => b.ShiftShiftTabletCrewReplacements_NewAgentId).HasForeignKey(c => c.NewAgentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletCrewReplacement_SAMT_Agents1");
            builder.HasOne(a => a.OldAgent).WithMany(b => b.ShiftShiftTabletCrewReplacements_OldAgentId).HasForeignKey(c => c.OldAgentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletCrewReplacement_SAMT_Agents");
            builder.HasOne(a => a.ShiftShiftTabletCrew).WithMany(b => b.ShiftShiftTabletCrewReplacements).HasForeignKey(c => c.ShiftTabletCrewId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletCrewReplacement_Shift_ShiftTabletCrew");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftShiftTabletCrewReplacement> builder);
    }

}
// </auto-generated>
