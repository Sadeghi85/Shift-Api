// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ConductorTablePakhsh
    public partial class ConductorTablePakhshConfiguration : IEntityTypeConfiguration<ConductorTablePakhsh>
    {
        public void Configure(EntityTypeBuilder<ConductorTablePakhsh> builder)
        {
            builder.ToTable("ConductorTablePakhsh", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ConductorTablePakhsh").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ChannelId).HasColumnName(@"ChannelID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProgramId).HasColumnName(@"ProgramID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProgramPartNo).HasColumnName(@"ProgramPartNo").HasColumnType("int").IsRequired();
            builder.Property(x => x.BroadcastDate).HasColumnName(@"BroadcastDate").HasColumnType("nchar(10)").IsRequired().IsFixedLength().HasMaxLength(10);
            builder.Property(x => x.BroadcastTime).HasColumnName(@"BroadcastTime").HasColumnType("time").IsRequired();
            builder.Property(x => x.ProgramLength).HasColumnName(@"ProgramLength").HasColumnType("time").IsRequired();
            builder.Property(x => x.EndTime).HasColumnName(@"EndTime").HasColumnType("time").IsRequired();
            builder.Property(x => x.IsLocked).HasColumnName(@"isLocked").HasColumnType("bit").IsRequired();
            builder.Property(x => x.WeekNumber).HasColumnName(@"WeekNumber").HasColumnType("int").IsRequired();
            builder.Property(x => x.VersionNumber).HasColumnName(@"VersionNumber").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsReleased).HasColumnName(@"isReleased").HasColumnType("bit").IsRequired();
            builder.Property(x => x.ReleasedVersion).HasColumnName(@"ReleasedVersion").HasColumnType("int").IsRequired();
            builder.Property(x => x.CurrentStatus).HasColumnName(@"CurrentStatus").HasColumnType("int").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsRepeat).HasColumnName(@"isRepeat").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsLive).HasColumnName(@"isLive").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsBuggy).HasColumnName(@"isBuggy").HasColumnType("bit").IsRequired();
            builder.Property(x => x.FullDescription).HasColumnName(@"FullDescription").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.RegieDescription).HasColumnName(@"RegieDescription").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Source).HasColumnName(@"Source").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.TapeNumber).HasColumnName(@"TapeNumber").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.IsWorkedByRegie).HasColumnName(@"IsWorkedByRegie").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SystemId).HasColumnName(@"SystemID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.HasTimeChange).HasColumnName(@"HasTimeChange").HasColumnType("bit").IsRequired();
            builder.Property(x => x.TimeChangeBy).HasColumnName(@"TimeChangeBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsCordinator).HasColumnName(@"IsCordinator").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsBroadCastUser).HasColumnName(@"IsBroadCastUser").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CordinatorLastChangeDate).HasColumnName(@"CordinatorLastChangeDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.BroadCastUserLastChangeDate).HasColumnName(@"BroadCastUserLastChangeDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsBold).HasColumnName(@"IsBold").HasColumnType("bit").IsRequired();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SentToBroadcastDateTime).HasColumnName(@"SentToBroadcastDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.BoxItemId).HasColumnName(@"BoxItemID").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.ConductorChannelProgram).WithMany(b => b.ConductorTablePakhshes).HasForeignKey(c => c.ProgramId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ConductorTablePakhsh_ConductorChannelPrograms");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ConductorTablePakhsh> builder);
    }

}
// </auto-generated>