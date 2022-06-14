// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_HistoryAgent
    public partial class SamtHistoryAgentConfiguration : IEntityTypeConfiguration<SamtHistoryAgent>
    {
        public void Configure(EntityTypeBuilder<SamtHistoryAgent> builder)
        {
            builder.ToTable("SAMT_HistoryAgent", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_HistoryAgent").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ResorceTypeId).HasColumnName(@"ResorceTypeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Program).HasColumnName(@"Program").HasColumnType("nvarchar(400)").IsRequired().HasMaxLength(400);
            builder.Property(x => x.Year).HasColumnName(@"Year").HasColumnType("char(4)").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(4);
            builder.Property(x => x.Evaluation).HasColumnName(@"Evaluation").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Festival).HasColumnName(@"Festival").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtHistoryAgent> builder);
    }

}
// </auto-generated>