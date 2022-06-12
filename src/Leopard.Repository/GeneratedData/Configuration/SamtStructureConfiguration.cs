// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_Structures
    public partial class SamtStructureConfiguration : IEntityTypeConfiguration<SamtStructure>
    {
        public void Configure(EntityTypeBuilder<SamtStructure> builder)
        {
            builder.ToTable("SAMT_Structures", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatProgramStructures").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName(@"IsExpired").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtStructure> builder);
    }

}
// </auto-generated>
