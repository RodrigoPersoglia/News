using AutoMapper;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Entities;

namespace Presentation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tag, TagDtoEdit>();
            CreateMap<TagDtoEdit, Tag>();
            CreateMap<TagDtoOut, Tag>();
            CreateMap<Tag, TagDtoOut>();
            CreateMap<Tag, TagDtoAdd>();
            CreateMap<TagDtoAdd, Tag>();

        }
    }
}