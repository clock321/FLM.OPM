using AutoMapper;
using OPM.Data.Dto;

namespace OPM.Common
{
    public class NLogProfile : Profile
    {
        public NLogProfile()
        {
            CreateMap<Data.NLog, NLogDto>().ReverseMap();
        }
    }
}
