// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shift.Repository
{
    // RayanSettings
    public partial class RayanSettingConfiguration : IEntityTypeConfiguration<RayanSetting>
    {
        public void Configure(EntityTypeBuilder<RayanSetting> builder)
        {
            builder.ToTable("RayanSettings", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_dbo.RayanSettings").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SettingName).HasColumnName(@"SettingName").HasColumnType("nvarchar(400)").IsRequired(false).HasMaxLength(400);
            builder.Property(x => x.SettingValue).HasColumnName(@"SettingValue").HasColumnType("nvarchar(400)").IsRequired(false).HasMaxLength(400);
            builder.Property(x => x.SettingLabel).HasColumnName(@"SettingLabel").HasColumnType("nvarchar(90)").IsRequired(false).HasMaxLength(90);
            builder.Property(x => x.MinAllowed).HasColumnName(@"MinAllowed").HasColumnType("int").IsRequired();
            builder.Property(x => x.MaxAllowed).HasColumnName(@"MaxAllowed").HasColumnType("int").IsRequired();
            builder.Property(x => x.FieldType).HasColumnName(@"FieldType").HasColumnType("int").IsRequired();
            builder.Property(x => x.UseEditor).HasColumnName(@"UseEditor").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SettingModule).HasColumnName(@"SettingModule").HasColumnType("int").IsRequired();
            builder.Property(x => x.ShowEditorInEdit).HasColumnName(@"ShowEditorInEdit").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<RayanSetting> builder);
    }

}
// </auto-generated>
