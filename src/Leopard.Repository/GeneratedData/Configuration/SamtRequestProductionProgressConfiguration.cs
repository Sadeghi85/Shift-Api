// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_RequestProductionProgresses
    public partial class SamtRequestProductionProgressConfiguration : IEntityTypeConfiguration<SamtRequestProductionProgress>
    {
        public void Configure(EntityTypeBuilder<SamtRequestProductionProgress> builder)
        {
            builder.ToTable("SAMT_RequestProductionProgresses", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_RequestProductionProgresses").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestProductionId).HasColumnName(@"RequestProductionID").HasColumnType("int").IsRequired();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SettingItemId).HasColumnName(@"SettingItemID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Value).HasColumnName(@"Value").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.SamtProductionSettingItem).WithMany(b => b.SamtRequestProductionProgresses).HasForeignKey(c => c.SettingItemId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMT_RequestProductionProgresses_SAMT_ProductionSettingItems");
            builder.HasOne(a => a.SamtRequest).WithMany(b => b.SamtRequestProductionProgresses).HasForeignKey(c => c.RequestId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMT_RequestProductionProgresses_SAMT_Requests");
            builder.HasOne(a => a.SamtRequestProduction).WithMany(b => b.SamtRequestProductionProgresses).HasForeignKey(c => c.RequestProductionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMT_RequestProductionProgresses_SAMT_RequestProductions");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtRequestProductionProgress> builder);
    }

}
// </auto-generated>