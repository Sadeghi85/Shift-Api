// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // TelavatProgramOccasions
    public partial class TelavatProgramOccasionConfiguration : IEntityTypeConfiguration<TelavatProgramOccasion>
    {
        public void Configure(EntityTypeBuilder<TelavatProgramOccasion> builder)
        {
            builder.ToTable("TelavatProgramOccasions", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatProgramOccasions").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.TelavatProgramOccasions).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatProgramOccasions_Portals");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TelavatProgramOccasion> builder);
    }

}
// </auto-generated>