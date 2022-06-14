// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // UserProfiles
    public partial class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_UserProfile").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.UserTypeId).HasColumnName(@"UserTypeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EnKey).HasColumnName(@"EnKey").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsRequire).HasColumnName(@"IsRequire").HasColumnType("bit").IsRequired();
            builder.Property(x => x.DataType).HasColumnName(@"DataType").HasColumnType("int").IsRequired();
            builder.Property(x => x.MinLength).HasColumnName(@"MinLength").HasColumnType("int").IsRequired();
            builder.Property(x => x.MaxLength).HasColumnName(@"MaxLength").HasColumnType("int").IsRequired();
            builder.Property(x => x.Regex).HasColumnName(@"Regex").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.ProfileControlId).HasColumnName(@"ProfileControlID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseInfoCategoryId).HasColumnName(@"BaseInfoCategoryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.BaseInfoCategory).WithMany(b => b.UserProfiles).HasForeignKey(c => c.BaseInfoCategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserProfiles_BaseInfoCategories");
            builder.HasOne(a => a.UserProfileControl).WithMany(b => b.UserProfiles).HasForeignKey(c => c.ProfileControlId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserProfiles_UserProfileControls");
            builder.HasOne(a => a.UserType).WithMany(b => b.UserProfiles).HasForeignKey(c => c.UserTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserProfiles_UserTypes");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<UserProfile> builder);
    }

}
// </auto-generated>