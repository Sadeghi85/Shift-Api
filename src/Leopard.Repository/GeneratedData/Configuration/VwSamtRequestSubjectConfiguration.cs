// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // VW_SAMT_Request_Subjects
    public partial class VwSamtRequestSubjectConfiguration : IEntityTypeConfiguration<VwSamtRequestSubject>
    {
        public void Configure(EntityTypeBuilder<VwSamtRequestSubject> builder)
        {
            builder.ToView("VW_SAMT_Request_Subjects", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.Level2).HasColumnName(@"Level2").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.RequestId).HasColumnName(@"requestId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Level1).HasColumnName(@"Level1").HasColumnType("int").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<VwSamtRequestSubject> builder);
    }

}
// </auto-generated>
