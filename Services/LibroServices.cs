using AutoMapper;
using libreriaAPI.Models.Autor.Dto;
using libreriaAPI.Models.Autor;
using libreriaAPI.Repositories;
using libreriaAPI.Utils.Exceptions;
using System.Net;
using libreriaAPI.Models.Libro.Dto;
using libreriaAPI.Models.Libro;

namespace libreriaAPI.Services
{
    public class LibroServices
    {
        private readonly IMapper _mapper;
        private readonly IAutoRepository _libroRepo;
        private readonly AutorServices _autorServices;

        public LibroServices(IMapper mapper, IAutoRepository libroRepo, AutorServices autorServices)
        {
            _mapper = mapper;
            _libroRepo = libroRepo;
            _autorServices = autorServices;
        }

        private async Task<Libro> GetOneByIdOrException(int id)
        {
            // Icluimos la entidad Combustible para que la traiga con la consulta.
            // ?
            var libro = await _libroRepo.GetOne(a => a.Id == id);
            if (libro == null)
            {
                throw new CustomHttpException($"No se encontro el libro con Id = {id}", HttpStatusCode.NotFound);
            }
            return libro;
        }

        public async Task<List<LibrosDTO>> GetAll()
        {
            var libros = await _libroRepo.GetAll();
            return _mapper.Map<List<LibrosDTO>>(libros);
        }

        public async Task<LibroDTO> GetOneById(int id)
        {
            var libro = await GetOneByIdOrException(id);
            //var combustible = _combustibleServices.GetOneById(auto.CombustibleId);
            //auto.Combustible = combustible;
            return _mapper.Map<LibroDTO>(libro);
        }

        public async Task<Libro> CreateOne(CreateLibroDTO createLibroDto)
        {
            Libro libro = _mapper.Map<Libro>(createLibroDto);

            // Es importante llamar a este método para que verifique que existe el combustible
            await _autorServices.GetOneById(libro.AutorId);

            await _libroRepo.Add(libro);
            return libro;
        }

        public async Task<Libro> UpdateOneById(int id, UpdateLibroDTO updateLibroDto)
        {
            Libro libro = await GetOneByIdOrException(id);

            var libroMapped = _mapper.Map(updateLibroDto, libro);

            await _autorServices.GetOneById(libroMapped.AutorId);

            await _libroRepo.Update(libroMapped);

            return libroMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var libro = await GetOneByIdOrException(id);

            await _libroRepo.Delete(libro);
        }
    }
}
