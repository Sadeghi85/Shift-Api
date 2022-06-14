// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Shift_ProductionNeededResource
    public partial class ShiftProductionNeededResourceConfiguration : IEntityTypeConfiguration<ShiftProductionNeededResource>
    {
        public void Configure(EntityTypeBuilder<ShiftProductionNeededResource> builder)
        {
            builder.ToTable("Shift_ProductionNeededResource", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_ProductionNeededResource").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ShifProductionTypeId).HasColumnName(@"ShifProductionTypeId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ResourceId).HasColumnName(@"ResourceId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.SamtResourceType).WithMany(b => b.ShiftProductionNeededResources).HasForeignKey(c => c.ResourceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ProductionNeededResource_SAMT_ResourceTypes");
            builder.HasOne(a => a.ShiftProductionType).WithMany(b => b.ShiftProductionNeededResources).HasForeignKey(c => c.ShifProductionTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_ProductionNeededResource_Shift_ProductionType");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftProductionNeededResource> builder);
    }

}
// </auto-generated>