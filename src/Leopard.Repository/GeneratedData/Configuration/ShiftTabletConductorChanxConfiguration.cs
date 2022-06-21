// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Shift_TabletConductorChanges
    public partial class ShiftTabletConductorChanxConfiguration : IEntityTypeConfiguration<ShiftTabletConductorChanx>
    {
        public void Configure(EntityTypeBuilder<ShiftTabletConductorChanx> builder)
        {
            builder.ToTable("Shift_TabletConductorChanges", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_TabletConductorChanges").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ProgramTitle).HasColumnName(@"ProgramTitle").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.ReplacedProgramTitle).HasColumnName(@"ReplacedProgramTitle").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.ShiftTabletId).HasColumnName(@"ShiftTabletId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ShiftShiftTablet).WithMany(b => b.ShiftTabletConductorChanges).HasForeignKey(c => c.ShiftTabletId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_TabletConductorChanges_Shift_ShiftTablet");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftTabletConductorChanx> builder);
    }

}
// </auto-generated>
