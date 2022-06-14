// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // InternalBaravordLogs
    public partial class InternalBaravordLogConfiguration : IEntityTypeConfiguration<InternalBaravordLog>
    {
        public void Configure(EntityTypeBuilder<InternalBaravordLog> builder)
        {
            builder.ToTable("InternalBaravordLogs", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_InternalBaravordLogs").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.InternalResourceId).HasColumnName(@"InternalResourceID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LogId).HasColumnName(@"LogID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.MainQualityId).HasColumnName(@"MainQualityID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Accept).HasColumnName(@"Accept").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<InternalBaravordLog> builder);
    }

}
// </auto-generated>