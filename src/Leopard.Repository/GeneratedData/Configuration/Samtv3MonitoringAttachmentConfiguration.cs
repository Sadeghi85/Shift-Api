// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMTV3_MonitoringAttachments
    public partial class Samtv3MonitoringAttachmentConfiguration : IEntityTypeConfiguration<Samtv3MonitoringAttachment>
    {
        public void Configure(EntityTypeBuilder<Samtv3MonitoringAttachment> builder)
        {
            builder.ToTable("SAMTV3_MonitoringAttachments", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMTV3_MonitoringAttachments").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.MonitoringId).HasColumnName(@"MonitoringId").HasColumnType("int").IsRequired();
            builder.Property(x => x.AttachmentId).HasColumnName(@"AttachmentId").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Samtv3Attachment).WithMany(b => b.Samtv3MonitoringAttachment).HasForeignKey(c => c.AttachmentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMTV3_MonitoringAttachments_SAMTV3_Attachments");
            builder.HasOne(a => a.Samtv3Monitoring).WithMany(b => b.Samtv3MonitoringAttachment).HasForeignKey(c => c.MonitoringId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMTV3_MonitoringAttachments_SAMTV3_Monitoring");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Samtv3MonitoringAttachment> builder);
    }

}
// </auto-generated>
