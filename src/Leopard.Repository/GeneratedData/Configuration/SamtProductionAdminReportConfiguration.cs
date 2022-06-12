// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_ProductionAdminReports
    public partial class SamtProductionAdminReportConfiguration : IEntityTypeConfiguration<SamtProductionAdminReport>
    {
        public void Configure(EntityTypeBuilder<SamtProductionAdminReport> builder)
        {
            builder.ToTable("SAMT_ProductionAdminReports", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_ProductionReports").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtProductionAdminReport> builder);
    }

}
// </auto-generated>
