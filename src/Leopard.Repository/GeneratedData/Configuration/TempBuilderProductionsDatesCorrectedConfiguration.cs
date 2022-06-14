// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // TEMP_BuilderProductions_DatesCorrected
    public partial class TempBuilderProductionsDatesCorrectedConfiguration : IEntityTypeConfiguration<TempBuilderProductionsDatesCorrected>
    {
        public void Configure(EntityTypeBuilder<TempBuilderProductionsDatesCorrected> builder)
        {
            builder.ToTable("TEMP_BuilderProductions_DatesCorrected", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DeliveryDate).HasColumnName(@"DeliveryDate").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Id).HasColumnName(@"id").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CorrectedDate).HasColumnName(@"correctedDate").HasColumnType("nvarchar(max)").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TempBuilderProductionsDatesCorrected> builder);
    }

}
// </auto-generated>