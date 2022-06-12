// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Pakhsh_TabletShifts
    public partial class PakhshTabletShiftConfiguration : IEntityTypeConfiguration<PakhshTabletShift>
    {
        public void Configure(EntityTypeBuilder<PakhshTabletShift> builder)
        {
            builder.ToTable("Pakhsh_TabletShifts", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Pakhsh_TabletShifts").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Date).HasColumnName(@"Date").HasColumnType("nvarchar(10)").IsRequired().HasMaxLength(10);
            builder.Property(x => x.ChannelLocationId).HasColumnName(@"ChannelLocationID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ShiftDetailId).HasColumnName(@"ShiftDetailID").HasColumnType("int").IsRequired();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.PersonTitleId).HasColumnName(@"PersonTitleID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsForRegi).HasColumnName(@"IsForRegi").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.PakhshPersonTitle).WithMany(b => b.PakhshTabletShifts).HasForeignKey(c => c.PersonTitleId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Pakhsh_TabletShifts_Pakhsh_PersonTitles");
            builder.HasOne(a => a.SamtAgent).WithMany(b => b.PakhshTabletShifts).HasForeignKey(c => c.AgentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Pakhsh_TabletShifts_SAMT_Agents");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<PakhshTabletShift> builder);
    }

}
// </auto-generated>
