using Alperen.AdvertisamentApp.Business.Mappings.AutoMapper;
using AutoMapper;
using System.Collections.Generic;

namespace Alperen.AdvertisamentApp.Business.Helpers
{
    public static class ProfileHelpers
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>()
            {
                new ProvidedServiceMappings(),
                new AdvertisamentProfile(),
                new GenderProfile(),
                new AppUserProfile(),
                new AppRoleProfile(),
                new AdvertisamentAppUserProfile(),
                new MilitaryStatusProfile(),
                new AdvertisamentAppUserStatusProfile()
            };
        }
    }
}


