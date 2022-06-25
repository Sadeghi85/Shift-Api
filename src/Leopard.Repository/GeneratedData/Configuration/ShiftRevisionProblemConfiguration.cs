// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // Shift_RevisionProblem
    public partial class ShiftRevisionProblemConfiguration : IEntityTypeConfiguration<ShiftRevisionProblem>
    {
        public void Configure(EntityTypeBuilder<ShiftRevisionProblem> builder)
        {
            builder.ToTable("Shift_RevisionProblem", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Shift_RevisionProblem").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ShiftTabletId).HasColumnName(@"ShiftTabletId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.FileNumber).HasColumnName(@"FileNumber").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.ClacketNo).HasColumnName(@"ClacketNo").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProblemDescription).HasColumnName(@"ProblemDescription").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.RevisorCode).HasColumnName(@"RevisorCode").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.ShiftShiftTablet).WithMany(b => b.ShiftRevisionProblems).HasForeignKey(c => c.ShiftTabletId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Shift_RevisionProblem_Shift_ShiftTablet");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ShiftRevisionProblem> builder);
    }

}
// </auto-generated>
