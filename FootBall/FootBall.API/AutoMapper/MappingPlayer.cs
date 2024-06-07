using FootBall.API.RestModels;
using FootBall.Model;
using AutoMapper;
using FootBall.Common;

namespace FootBall.API.NewFolder2
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<FootBallPlayer, RestFootBallPlayer>()
                .ForMember(dest => dest.RestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Nation, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));


        }


    }
}
