// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // UserTypeGroupRoleModules
    public partial class UserTypeGroupRoleModuleConfiguration : IEntityTypeConfiguration<UserTypeGroupRoleModule>
    {
        public void Configure(EntityTypeBuilder<UserTypeGroupRoleModule> builder)
        {
            builder.ToTable("UserTypeGroupRoleModules", "dbo");
            builder.HasKey(x => new { x.RayanModuleId, x.UserTypeGroupId, x.PermissionType }).HasName("PK_UserTypeGroupRoleModules").IsClustered();

            builder.Property(x => x.RayanModuleId).HasColumnName(@"RayanModuleID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.UserTypeGroupId).HasColumnName(@"UserTypeGroupID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.PermissionType).HasColumnName(@"PermissionType").HasColumnType("int").IsRequired().ValueGeneratedNever();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<UserTypeGroupRoleModule> builder);
    }

}
// </auto-generated>
