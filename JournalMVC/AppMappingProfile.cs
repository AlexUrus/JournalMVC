using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;


namespace JournalMVC
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<TypeActivity, TypeActivityDTO>().ReverseMap();

            CreateMap<MonthlyRecord, MonthlyRecordDTO>().ReverseMap();

            CreateMap<DailyRecord, DailyRecordDTO>().ReverseMap()
                .ForMember(dest => dest.MonthlyRecord, opt => opt.MapFrom(src => src.MonthlyRecord));

            CreateMap<TimeInterval, TimeIntervalDTO>()
               .ForMember(dest => dest.StartActivity, opt => opt.MapFrom(src => DateTime.Today.Add(src.StartActivity)))
               .ForMember(dest => dest.EndActivity, opt => opt.MapFrom(src => DateTime.Today.Add(src.EndActivity)));

            CreateMap<TimeIntervalDTO, TimeInterval>()
                .ForMember(dest => dest.StartActivity, opt => opt.MapFrom(src => src.StartActivity.TimeOfDay))
                .ForMember(dest => dest.EndActivity, opt => opt.MapFrom(src => src.EndActivity.TimeOfDay));

            CreateMap<Activity, ActivityDTO>().ReverseMap()
                .ForMember(dest => dest.TimeInterval, opt => opt.MapFrom(src => src.TimeInterval))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.DailyRecord, opt => opt.MapFrom(src => src.DailyRecord));
        }
    }
}
