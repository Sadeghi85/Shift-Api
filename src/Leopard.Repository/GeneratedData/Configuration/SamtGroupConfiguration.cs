// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_Groups
    public partial class SamtGroupConfiguration : IEntityTypeConfiguration<SamtGroup>
    {
        public void Configure(EntityTypeBuilder<SamtGroup> builder)
        {
            builder.ToTable("SAMT_Groups", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatGroups").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.NoDashboard).HasColumnName(@"NoDashboard").HasColumnType("bit").IsRequired();
            builder.Property(x => x.NumberColor).HasColumnName(@"NumberColor").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.EstimateGid).HasColumnName(@"EstimateGID").HasColumnType("nchar(3)").IsRequired(false).IsFixedLength().HasMaxLength(3);

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.SamtGroups).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatGroups_Portals");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtGroup> builder);
    }

}
// </auto-generated>
