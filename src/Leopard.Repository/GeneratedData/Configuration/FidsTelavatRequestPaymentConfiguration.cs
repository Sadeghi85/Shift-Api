// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // FIDS_TelavatRequestPayments
    public partial class FidsTelavatRequestPaymentConfiguration : IEntityTypeConfiguration<FidsTelavatRequestPayment>
    {
        public void Configure(EntityTypeBuilder<FidsTelavatRequestPayment> builder)
        {
            builder.ToTable("FIDS_TelavatRequestPayments", "dbo");
            builder.HasKey(x => new { x.Id, x.RequestId, x.Amount, x.IsCreditor, x.BaseYear });

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Amount).HasColumnName(@"Amount").HasColumnType("float").HasPrecision(53).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsCreditor).HasColumnName(@"IsCreditor").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.DatePayment).HasColumnName(@"DatePayment").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.BaseYear).HasColumnName(@"BaseYear").HasColumnType("int").IsRequired().ValueGeneratedNever();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<FidsTelavatRequestPayment> builder);
    }

}
// </auto-generated>