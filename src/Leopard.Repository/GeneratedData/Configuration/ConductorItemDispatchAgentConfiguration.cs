// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorItemDispatchAgents
    public partial class ConductorItemDispatchAgentConfiguration : IEntityTypeConfiguration<ConductorItemDispatchAgent>
    {
        public void Configure(EntityTypeBuilder<ConductorItemDispatchAgent> builder)
        {
            builder.ToTable("ConductorItemDispatchAgents", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorItemDispatchAgents").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DispatchId).HasColumnName(@"DispatchID").HasColumnType("int").IsRequired();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired();
            builder.Property(x => x.AgentName).HasColumnName(@"AgentName").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ConductorItemDispatch).WithMany(b => b.ConductorItemDispatchAgents).HasForeignKey(c => c.DispatchId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorItemDispatchAgents_ConductorItemDispatch");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorItemDispatchAgent> builder);
    }

}
// </auto-generated>