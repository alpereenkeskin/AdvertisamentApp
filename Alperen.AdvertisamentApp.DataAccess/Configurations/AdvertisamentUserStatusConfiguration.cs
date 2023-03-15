using Alperen.AdvertisamentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.DataAccess.Configurations
{
    public class AdvertisamentUserStatusConfiguration : IEntityTypeConfiguration<AdvertisamentUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisamentUserStatus> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();

        }
    }
}
