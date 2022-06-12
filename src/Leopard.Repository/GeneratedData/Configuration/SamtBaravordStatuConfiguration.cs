// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_BaravordStatus
    public partial class SamtBaravordStatuConfiguration : IEntityTypeConfiguration<SamtBaravordStatu>
    {
        public void Configure(EntityTypeBuilder<SamtBaravordStatu> builder)
        {
            builder.ToTable("SAMT_BaravordStatus", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatBaravordStatus").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired();
            builder.Property(x => x.StatusId).HasColumnName(@"StatusID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.CreationDateTime).HasColumnName(@"CreationDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.UserId).HasColumnName(@"UserID").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.SamtRequest).WithMany(b => b.SamtBaravordStatus).HasForeignKey(c => c.RequestId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMT_BaravordStatus_SAMT_Requests");

            builder.HasIndex(x => x.RequestId).HasDatabaseName("IX_BSTATUS");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtBaravordStatu> builder);
    }

}
// </auto-generated>
