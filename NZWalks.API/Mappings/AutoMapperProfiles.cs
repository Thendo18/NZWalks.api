using AutoMapper;
using NZWalks.API.Controllers;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Regions, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Regions>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walks>().ReverseMap();
            CreateMap<Walks, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walks>().ReverseMap();
        }
    }
}
