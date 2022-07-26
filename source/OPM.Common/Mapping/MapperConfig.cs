using AutoMapper;
using OPM.Data.Dto;

namespace OPM.Common
{
    public static class MapperConfig
    {
        public static IMapper GetMapperConfigs()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new NLogProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
