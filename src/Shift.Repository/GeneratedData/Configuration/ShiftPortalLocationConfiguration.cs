// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // Shift_PortalLocations
    public partial class ShiftPortalLocationConfiguration : IEntityTypeConfiguration<ShiftPortalLocation>
    {
        public void Configure(EntityTypeBuilder<ShiftPortalLocation> builder)
        {
            builder.ToTable("Shift_PortalLocations", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ShiftExecutionLocation").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.LocationId).HasColumnName(@"LocationID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.ShiftPortalLocations).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ShiftTabletLocation_Portals");
            builder.HasOne(a => a.ShiftLocation).WithMany(b => b.ShiftPortalLocations).HasForeignKey(c => c.LocationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ShiftExecutionLocation_Location");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftPortalLocation> builder);
    }

}
// </auto-generated>
