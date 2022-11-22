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

            CreateMap<Categoria, CategoriaDtoEdit>();
            CreateMap<CategoriaDtoEdit, Categoria>();
            CreateMap<CategoriaDtoOut, Categoria>();
            CreateMap<Categoria, CategoriaDtoOut>();
            CreateMap<Categoria, CategoriaDtoAdd>();
            CreateMap<CategoriaDtoAdd, Categoria>();

            CreateMap<User, UserDtoEdit>();
            CreateMap<UserDtoEdit, User>();
            CreateMap<UserDtoOut, User>();
            CreateMap<User, UserDtoOut>();
            CreateMap<User, UserDtoAdd>();
            CreateMap<UserDtoAdd, User>();


            CreateMap<Noticia, NoticiaDtoEdit>();
            CreateMap<NoticiaDtoEdit, Noticia>();
            CreateMap<NoticiaDtoOut, Noticia>();
            CreateMap<Noticia, NoticiaDtoOut>();
            CreateMap<Noticia, NoticiaDtoAdd>();
            CreateMap<NoticiaDtoAdd, Noticia>();
        }
    }
}