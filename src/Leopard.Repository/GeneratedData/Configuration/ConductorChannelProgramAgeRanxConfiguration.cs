// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorChannelProgramAgeRanges
    public partial class ConductorChannelProgramAgeRanxConfiguration : IEntityTypeConfiguration<ConductorChannelProgramAgeRanx>
    {
        public void Configure(EntityTypeBuilder<ConductorChannelProgramAgeRanx> builder)
        {
            builder.ToTable("ConductorChannelProgramAgeRanges", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorChannelProgramAgeRanges").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorChannelProgramAgeRanx> builder);
    }

}
// </auto-generated>
