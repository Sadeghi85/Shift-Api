// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // RayanModuleDefinitionLogs
    public partial class RayanModuleDefinitionLogConfiguration : IEntityTypeConfiguration<RayanModuleDefinitionLog>
    {
        public void Configure(EntityTypeBuilder<RayanModuleDefinitionLog> builder)
        {
            builder.ToTable("RayanModuleDefinitionLogs", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ModuleDefinitionLohs").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RayanModuleDefinitionId).HasColumnName(@"RayanModuleDefinitionID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Version).HasColumnName(@"Version").HasColumnType("nchar(5)").IsRequired().IsFixedLength().HasMaxLength(5);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.RayanModuleDefinition).WithMany(b => b.RayanModuleDefinitionLogs).HasForeignKey(c => c.RayanModuleDefinitionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RayanModuleDefinitionLogs_RayanModuleDefinitions");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<RayanModuleDefinitionLog> builder);
    }

}
// </auto-generated>
