// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Pakhsh_ChannelSettings
    public partial class PakhshChannelSettingConfiguration : IEntityTypeConfiguration<PakhshChannelSetting>
    {
        public void Configure(EntityTypeBuilder<PakhshChannelSetting> builder)
        {
            builder.ToTable("Pakhsh_ChannelSettings", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Pakhsh_PrtalSettings").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ChannelId).HasColumnName(@"ChannelID").HasColumnType("int").IsRequired();
            builder.Property(x => x.LimitedMovement).HasColumnName(@"LimitedMovement").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Instraction).HasColumnName(@"Instraction").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ShiftCount).HasColumnName(@"ShiftCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Portal).WithMany(b => b.PakhshChannelSettings).HasForeignKey(c => c.ChannelId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Pakhsh_ChanelSettings_Portals");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<PakhshChannelSetting> builder);
    }

}
// </auto-generated>