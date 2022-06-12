// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // temp_step5RemovedLOGs
    public partial class TempStep5RemovedLoGsConfiguration : IEntityTypeConfiguration<TempStep5RemovedLoGs>
    {
        public void Configure(EntityTypeBuilder<TempStep5RemovedLoGs> builder)
        {
            builder.ToTable("temp_step5RemovedLOGs", "dbo");
            builder.HasKey(x => new { x.Id, x.Step, x.IsDeleted, x.LastLogStep, x.BaseYear });

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.OldRequestId).HasColumnName(@"OldRequestID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.Step).HasColumnName(@"Step").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Part).HasColumnName(@"Part").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Time).HasColumnName(@"Time").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.LastLogStep).HasColumnName(@"LastLogStep").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.OmidId).HasColumnName(@"OmidId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.QuranId).HasColumnName(@"QuranId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.BaseYear).HasColumnName(@"BaseYear").HasColumnType("int").IsRequired().ValueGeneratedNever();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TempStep5RemovedLoGs> builder);
    }

}
// </auto-generated>
