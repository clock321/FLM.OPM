using AutoMapper;
using OPM.Data.Dto;

namespace OPM.Core
{
    public class NLogProfile : Profile
    {
        public NLogProfile()
        {
            CreateMap<Data.NLog, NLogDto>().ReverseMap();
        }
    }
}
