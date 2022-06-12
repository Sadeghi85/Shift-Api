// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorProgramApproachs
    public partial class ConductorProgramApproachConfiguration : IEntityTypeConfiguration<ConductorProgramApproach>
    {
        public void Configure(EntityTypeBuilder<ConductorProgramApproach> builder)
        {
            builder.ToTable("ConductorProgramApproachs", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorProgramApproachs").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ProgramId).HasColumnName(@"ProgramID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ApproachId).HasColumnName(@"ApproachID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ApproachPercent).HasColumnName(@"ApproachPercent").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.ConductorChannelProgram).WithMany(b => b.ConductorProgramApproaches).HasForeignKey(c => c.ProgramId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorProgramApproachs_ConductorChannelPrograms");
            builder.HasOne(a => a.SamtApproach).WithMany(b => b.ConductorProgramApproaches).HasForeignKey(c => c.ApproachId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorProgramApproachs_SAMT_Approach");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorProgramApproach> builder);
    }

}
// </auto-generated>
