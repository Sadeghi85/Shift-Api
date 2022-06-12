// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // MojriFilmographys
    public partial class MojriFilmographyConfiguration : IEntityTypeConfiguration<MojriFilmography>
    {
        public void Configure(EntityTypeBuilder<MojriFilmography> builder)
        {
            builder.ToTable("MojriFilmographys", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_MojriFilmography").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.OfficeDescription).HasColumnName(@"OfficeDescription").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.ProgramName).HasColumnName(@"ProgramName").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.EpisodeCount).HasColumnName(@"EpisodeCount").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProductionYear).HasColumnName(@"ProductionYear").HasColumnType("int").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<MojriFilmography> builder);
    }

}
// </auto-generated>
