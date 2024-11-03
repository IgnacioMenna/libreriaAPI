using AutoMapper;
using libreriaAPI.Models.Libro;
using libreriaAPI.Models.Libro.Dto;
using libreriaAPI.Models.Autor;
using libreriaAPI.Models.Autor.Dto;
using libreriaAPI.Models.User.Dto;
using libreriaAPI.Models.User;
using libreriaAPI.Models.Genero.Dto;
using libreriaAPI.Models.Genero;
using libreriaAPI.Models.Resena;
using libreriaAPI.Models.Resena.Dto;

namespace libreriaAPI.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Para no convertir los atributos 'int?' a 0 en la conversion de los 'null'
            // valor defecto int -> 0
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

            // Aqui es necesario hacer esto con bool? ya que tampoco devuelve el tipo 'null'.
            // valor defecto bool -> false
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);

            //PD: Esta solución hay que aplicarla para todos aquellos tipos que no tengan como valor por defecto 'null'

            CreateMap<Libro, LibroDTO>().ReverseMap();
            CreateMap<Libro, LibrosDTO>().ReverseMap();
            CreateMap<Libro, CreateLibroDTO>().ReverseMap();

            // Actualizar y no parsear los valores 'NULL'
            CreateMap<UpdateLibroDTO, Libro>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });


            // Autores
            CreateMap<CreateAutorDTO, Autor>().ReverseMap();
            CreateMap<UpdateAutorDTO, Autor>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            // Usuarios
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UsersDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();

            // Actualizar y no parsear los valores 'NULL'
            CreateMap<UpdateUserDTO, User>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            // Generos
            CreateMap<CreateGeneroDTO, Genero>().ReverseMap();
            CreateMap<UpdateGeneroDTO, Genero>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            // Resenas
            CreateMap<CreateResenaDTO, Resena>().ReverseMap();
            CreateMap<UpdateResenaDTO, Resena>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
        }
    }
}
