// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMTV3_MonitoringKeywords
    public partial class Samtv3MonitoringKeywordConfiguration : IEntityTypeConfiguration<Samtv3MonitoringKeyword>
    {
        public void Configure(EntityTypeBuilder<Samtv3MonitoringKeyword> builder)
        {
            builder.ToTable("SAMTV3_MonitoringKeywords", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMTV3_MonitoringKeywords").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.MonitoringId).HasColumnName(@"MonitoringId").HasColumnType("int").IsRequired();
            builder.Property(x => x.KeywordId).HasColumnName(@"KeywordId").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.SamtSubject).WithMany(b => b.Samtv3MonitoringKeyword).HasForeignKey(c => c.KeywordId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMTV3_MonitoringKeywords_SAMT_Subjects");
            builder.HasOne(a => a.Samtv3Monitoring).WithMany(b => b.Samtv3MonitoringKeyword).HasForeignKey(c => c.MonitoringId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMTV3_MonitoringKeywords_SAMTV3_Monitoring");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Samtv3MonitoringKeyword> builder);
    }

}
// </auto-generated>
