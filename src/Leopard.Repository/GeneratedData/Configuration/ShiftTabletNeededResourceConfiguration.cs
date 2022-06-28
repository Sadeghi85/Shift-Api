// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // shiftTabletNeededResource
    public partial class ShiftTabletNeededResourceConfiguration : IEntityTypeConfiguration<ShiftTabletNeededResource>
    {
        public void Configure(EntityTypeBuilder<ShiftTabletNeededResource> builder)
        {
            builder.ToTable("shiftTabletNeededResource", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_shiftTabletNeededResource").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ResourceTypeId).HasColumnName(@"ResourceTypeId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ShiftId).HasColumnName(@"ShiftId").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.SamtResourceType).WithMany(b => b.ShiftTabletNeededResources).HasForeignKey(c => c.ResourceTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_shiftTabletNeededResource_SAMT_ResourceTypes");
            builder.HasOne(a => a.ShiftShift).WithMany(b => b.ShiftTabletNeededResources).HasForeignKey(c => c.ShiftId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_shiftTabletNeededResource_Shift_Shift");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftTabletNeededResource> builder);
    }

}
// </auto-generated>