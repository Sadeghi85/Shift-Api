// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // DynamicPages
    public partial class DynamicPageConfiguration : IEntityTypeConfiguration<DynamicPage>
    {
        public void Configure(EntityTypeBuilder<DynamicPage> builder)
        {
            builder.ToTable("DynamicPages", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_DynamicPages").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CategoryId).HasColumnName(@"CategoryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(4000)").IsRequired().HasMaxLength(4000);
            builder.Property(x => x.Text).HasColumnName(@"Text").HasColumnType("ntext").IsRequired();
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.PageHit).HasColumnName(@"PageHit").HasColumnType("int").IsRequired();
            builder.Property(x => x.UserId).HasColumnName(@"UserID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();
            builder.Property(x => x.AppendFile).HasColumnName(@"appendFile").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.DownloadAsPdf).HasColumnName(@"DownloadAsPdf").HasColumnType("bit").IsRequired();
            builder.Property(x => x.DownloadAsWord).HasColumnName(@"DownloadAsWord").HasColumnType("bit").IsRequired();
            builder.Property(x => x.DownloadAsExcel).HasColumnName(@"DownloadAsExcel").HasColumnType("bit").IsRequired();
            builder.Property(x => x.DownloadAsXml).HasColumnName(@"DownloadAsXML").HasColumnType("bit").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName(@"Enabled").HasColumnType("bit").IsRequired();
            builder.Property(x => x.PageIcon).HasColumnName(@"pageIcon").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.EnableComment).HasColumnName(@"EnableComment").HasColumnType("bit").IsRequired();
            builder.Property(x => x.EnableRating).HasColumnName(@"EnableRating").HasColumnType("bit").IsRequired();
            builder.Property(x => x.EnablePrint).HasColumnName(@"EnablePrint").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ShowInfirstPage).HasColumnName(@"ShowInfirstPage").HasColumnType("bit").IsRequired();
            builder.Property(x => x.PageImage).HasColumnName(@"PageImage").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.TitleAppendFile).HasColumnName(@"TitleAppendFile").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.ShowSlider).HasColumnName(@"ShowSlider").HasColumnType("bit").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<DynamicPage> builder);
    }

}
// </auto-generated>
