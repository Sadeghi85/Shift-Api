// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // Shift_ShiftTabletCrew
    public partial class ShiftShiftTabletCrewConfiguration : IEntityTypeConfiguration<ShiftShiftTabletCrew>
    {
        public void Configure(EntityTypeBuilder<ShiftShiftTabletCrew> builder)
        {
            builder.ToTable("Shift_ShiftTabletCrew", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_ShiftTableCrew").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.JobId).HasColumnName(@"JobID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ShiftTabletId).HasColumnName(@"ShiftTabletID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsReplaced).HasColumnName(@"IsReplaced").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.SamtAgent).WithMany(b => b.ShiftShiftTabletCrews).HasForeignKey(c => c.AgentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletCrew_SAMT_Agents");
            builder.HasOne(a => a.SamtResourceType).WithMany(b => b.ShiftShiftTabletCrews).HasForeignKey(c => c.JobId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTableCrew_SAMT_ResourceTypes");
            builder.HasOne(a => a.ShiftShiftTablet).WithMany(b => b.ShiftShiftTabletCrews).HasForeignKey(c => c.ShiftTabletId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTableCrew_Shift_ShiftTablet");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftShiftTabletCrew> builder);
    }

}
// </auto-generated>
