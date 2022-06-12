// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorChannelProgramSupplyTypes
    public partial class ConductorChannelProgramSupplyTypeConfiguration : IEntityTypeConfiguration<ConductorChannelProgramSupplyType>
    {
        public void Configure(EntityTypeBuilder<ConductorChannelProgramSupplyType> builder)
        {
            builder.ToTable("ConductorChannelProgramSupplyTypes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorChannelProgramSupplyTypes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(150)").IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorChannelProgramSupplyType> builder);
    }

}
// </auto-generated>
