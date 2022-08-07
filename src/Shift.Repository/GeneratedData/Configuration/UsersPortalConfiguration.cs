// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // UsersPortals
    public partial class UsersPortalConfiguration : IEntityTypeConfiguration<UsersPortal>
    {
        public void Configure(EntityTypeBuilder<UsersPortal> builder)
        {
            builder.ToTable("UsersPortals", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_UsersPortals").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalId").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.UsersPortals).HasForeignKey(c => c.PortalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersPortals_Portals");
            builder.HasOne(a => a.User).WithMany(b => b.UsersPortals).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersPortals_Users");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<UsersPortal> builder);
    }

}
// </auto-generated>
