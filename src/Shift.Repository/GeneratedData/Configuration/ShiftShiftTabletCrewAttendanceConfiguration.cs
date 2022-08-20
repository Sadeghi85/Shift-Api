// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // Shift_ShiftTabletCrewAttendance
    public partial class ShiftShiftTabletCrewAttendanceConfiguration : IEntityTypeConfiguration<ShiftShiftTabletCrewAttendance>
    {
        public void Configure(EntityTypeBuilder<ShiftShiftTabletCrewAttendance> builder)
        {
            builder.ToTable("Shift_ShiftTabletCrewAttendance", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_ShiftTabletCrewAttendance").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ShiftTabletCrewId).HasColumnName(@"ShiftTabletCrewID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.RoleTypeId).HasColumnName(@"RoleTypeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.EntranceTime).HasColumnName(@"EntranceTime").HasColumnType("time").IsRequired();
            builder.Property(x => x.ExitTime).HasColumnName(@"ExitTime").HasColumnType("time").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.ShiftShiftTabletCrew).WithMany(b => b.ShiftShiftTabletCrewAttendances).HasForeignKey(c => c.ShiftTabletCrewId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletCrewAttendance_Shift_ShiftTabletCrew");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftShiftTabletCrewAttendance> builder);
    }

}
// </auto-generated>