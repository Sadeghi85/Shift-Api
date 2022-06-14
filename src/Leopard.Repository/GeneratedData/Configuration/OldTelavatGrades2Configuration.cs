// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // OLD_TelavatGrades2
    public partial class OldTelavatGrades2Configuration : IEntityTypeConfiguration<OldTelavatGrades2>
    {
        public void Configure(EntityTypeBuilder<OldTelavatGrades2> builder)
        {
            builder.ToTable("OLD_TelavatGrades2", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatGrades").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.OldTelavatGrades2).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatGrades_Portals");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<OldTelavatGrades2> builder);
    }

}
// </auto-generated>