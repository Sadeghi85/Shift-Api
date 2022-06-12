// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // vw_samt_Log_subject
    public partial class VwSamtLogSubjectConfiguration : IEntityTypeConfiguration<VwSamtLogSubject>
    {
        public void Configure(EntityTypeBuilder<VwSamtLogSubject> builder)
        {
            builder.ToView("vw_samt_Log_subject", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.LogId).HasColumnName(@"LogId").HasColumnType("int").IsRequired();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.Step).HasColumnName(@"Step").HasColumnType("int").IsRequired();
            builder.Property(x => x.Part).HasColumnName(@"Part").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Time).HasColumnName(@"Time").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SubjectId).HasColumnName(@"SubjectID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<VwSamtLogSubject> builder);
    }

}
// </auto-generated>
