// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // vwPaymentDetailByBaseYear
    public partial class VwPaymentDetailByBaseYearConfiguration : IEntityTypeConfiguration<VwPaymentDetailByBaseYear>
    {
        public void Configure(EntityTypeBuilder<VwPaymentDetailByBaseYear> builder)
        {
            builder.ToView("vwPaymentDetailByBaseYear", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseYear).HasColumnName(@"BaseYear").HasColumnType("int").IsRequired();
            builder.Property(x => x.InitialBaseYear).HasColumnName(@"initialBaseYear").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseYearPayment).HasColumnName(@"BaseYearPayment").HasColumnType("float").HasPrecision(53).IsRequired();
            builder.Property(x => x.BaseYearCount).HasColumnName(@"BaseYearCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.BaseYearTime).HasColumnName(@"BaseYearTime").HasColumnType("int").IsRequired();
            builder.Property(x => x.LicenseProgramTime).HasColumnName(@"LicenseProgramTime").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LicenseProgramCount).HasColumnName(@"LicenseProgramCount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.InitialCount).HasColumnName(@"InitialCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.InitialTime).HasColumnName(@"InitialTime").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SumPayed).HasColumnName(@"SumPayed").HasColumnType("float").HasPrecision(53).IsRequired();
            builder.Property(x => x.Remained).HasColumnName(@"Remained").HasColumnType("float").HasPrecision(53).IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<VwPaymentDetailByBaseYear> builder);
    }

}
// </auto-generated>