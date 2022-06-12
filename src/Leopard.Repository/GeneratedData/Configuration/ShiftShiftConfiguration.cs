// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Shift_Shift
    public partial class ShiftShiftConfiguration : IEntityTypeConfiguration<ShiftShift>
    {
        public void Configure(EntityTypeBuilder<ShiftShift> builder)
        {
            builder.ToTable("Shift_Shift", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_PortalShift").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.StartTime).HasColumnName(@"StartTime").HasColumnType("time").IsRequired(false);
            builder.Property(x => x.EndTime).HasColumnName(@"EndTime").HasColumnType("time").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ShiftType).HasColumnName(@"ShiftType").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.HasRewardFine).HasColumnName(@"HasRewardFine").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.RewarFineAmount).HasColumnName(@"RewarFineAmount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.ShiftShifts).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PortalShift_Portals");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftShift> builder);
    }

}
// </auto-generated>
