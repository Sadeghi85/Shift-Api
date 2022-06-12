// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_Events
    public partial class SamtEventConfiguration : IEntityTypeConfiguration<SamtEvent>
    {
        public void Configure(EntityTypeBuilder<SamtEvent> builder)
        {
            builder.ToTable("SAMT_Events", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_Events").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.HasChild).HasColumnName(@"HasChild").HasColumnType("bit").IsRequired();
            builder.Property(x => x.EventTitle).HasColumnName(@"EventTitle").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EventDescription).HasColumnName(@"EventDescription").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.EventType).HasColumnName(@"EventType").HasColumnType("int").IsRequired();
            builder.Property(x => x.EventYear).HasColumnName(@"EventYear").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EventMonth).HasColumnName(@"EventMonth").HasColumnType("int").IsRequired();
            builder.Property(x => x.EventDayFrom).HasColumnName(@"EventDayFrom").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EventDayTo).HasColumnName(@"EventDayTo").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EventDuration).HasColumnName(@"EventDuration").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsReligious).HasColumnName(@"IsReligious").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsNational).HasColumnName(@"IsNational").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsInternational).HasColumnName(@"IsInternational").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsPublicHoliday).HasColumnName(@"IsPublicHoliday").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Sadness).HasColumnName(@"Sadness").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName(@"IsExpired").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtEvent> builder);
    }

}
// </auto-generated>
