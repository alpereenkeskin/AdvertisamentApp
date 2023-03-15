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
    public class AdvertisamentUserConfiguration : IEntityTypeConfiguration<AdvertisamentUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisamentUser> builder)
        {
            builder.HasIndex(x => new
            {
                x.UserId,
                x.AdvertisamentId,
            }).IsUnique();// AdvertisamentUser userıd ve Advertisamentıd uniqe key olarak belirledik
            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.Advertisament).WithMany(x => x.AdvertisamentUsers).HasForeignKey(x => x.AdvertisamentId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisamentUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.AdvertisamentUserStatus).WithMany(x => x.AdvertisamentUsers).HasForeignKey(x => x.AdvertisamentUserStatusId);
            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.advertisamentUsers).HasForeignKey(x => x.MilitaryStatusId);

        }
    }
}
