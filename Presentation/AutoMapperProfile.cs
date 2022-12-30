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
            CreateMap<Tag, TagDtoEdit>().ReverseMap();
            CreateMap<TagDtoOut, Tag>().ReverseMap();
            CreateMap<Tag, TagDtoAdd>().ReverseMap();

            CreateMap<Categoria, CategoriaDtoEdit>().ReverseMap();
            CreateMap<Categoria, CategoriaDtoOut>().ReverseMap();
            CreateMap<Categoria, CategoriaDtoAdd>().ReverseMap();

            CreateMap<User, UserDtoEdit>().ReverseMap();
            CreateMap<User, UserDtoOut>().ReverseMap();
            CreateMap<User, UserDtoAdd>().ReverseMap();

            CreateMap<Noticia, NoticiaDtoEdit>().ReverseMap();
            CreateMap<Noticia, NoticiaDtoOut>().ReverseMap();
            CreateMap<Noticia, NoticiaDtoAdd>().ReverseMap();

            CreateMap<Comentario, ComentarioDtoEdit>().ReverseMap();
            CreateMap<Comentario, ComentarioDtoOut>().ReverseMap();
            CreateMap<Comentario, ComentarioDtoAdd>().ReverseMap();

            CreateMap<Reaccion, ReaccionDtoOut>().ReverseMap();
        }
    }
}