// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // RayanModuleDefinitions
    public partial class RayanModuleDefinitionConfiguration : IEntityTypeConfiguration<RayanModuleDefinition>
    {
        public void Configure(EntityTypeBuilder<RayanModuleDefinition> builder)
        {
            builder.ToTable("RayanModuleDefinitions", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_RayanModuleDefinitions").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Version).HasColumnName(@"Version").HasColumnType("nchar(5)").IsRequired().IsFixedLength().HasMaxLength(5);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<RayanModuleDefinition> builder);
    }

}
// </auto-generated>