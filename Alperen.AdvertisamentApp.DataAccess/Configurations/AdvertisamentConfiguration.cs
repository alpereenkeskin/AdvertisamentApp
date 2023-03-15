using Alperen.AdvertisamentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.DataAccess.Configurations
{
    public class AdvertisamentConfiguration : IEntityTypeConfiguration<Advertisament>
    {
        public void Configure(EntityTypeBuilder<Advertisament> builder)
        {

            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");
        }
    }
}
