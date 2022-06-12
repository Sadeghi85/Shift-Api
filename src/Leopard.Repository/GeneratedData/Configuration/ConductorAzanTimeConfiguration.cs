// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorAzanTimes
    public partial class ConductorAzanTimeConfiguration : IEntityTypeConfiguration<ConductorAzanTime>
    {
        public void Configure(EntityTypeBuilder<ConductorAzanTime> builder)
        {
            builder.ToTable("ConductorAzanTimes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorAzanTimes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.TheDate).HasColumnName(@"TheDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.MorningTime).HasColumnName(@"MorningTime").HasColumnType("time").IsRequired(false);
            builder.Property(x => x.LaunchTime).HasColumnName(@"LaunchTime").HasColumnType("time").IsRequired(false);
            builder.Property(x => x.DinnerTime).HasColumnName(@"DinnerTime").HasColumnType("time").IsRequired(false);
            builder.Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorAzanTime> builder);
    }

}
// </auto-generated>
