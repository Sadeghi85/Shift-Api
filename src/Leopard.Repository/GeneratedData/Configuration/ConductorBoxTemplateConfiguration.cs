// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorBoxTemplates
    public partial class ConductorBoxTemplateConfiguration : IEntityTypeConfiguration<ConductorBoxTemplate>
    {
        public void Configure(EntityTypeBuilder<ConductorBoxTemplate> builder)
        {
            builder.ToTable("ConductorBoxTemplates", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorBoxItems").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.TypeId).HasColumnName(@"TypeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ChannelId).HasColumnName(@"ChannelID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Date).HasColumnName(@"Date").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Duration).HasColumnName(@"Duration").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.ConductorBoxType).WithMany(b => b.ConductorBoxTemplates).HasForeignKey(c => c.TypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorBoxItems_ConductorBoxItemTypes");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorBoxTemplate> builder);
    }

}
// </auto-generated>