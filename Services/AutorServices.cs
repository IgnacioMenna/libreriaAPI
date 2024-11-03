using AutoMapper;
using libreriaAPI.Models.Autor;
using libreriaAPI.Models.Autor.Dto;
using libreriaAPI.Repositories;
using libreriaAPI.Utils.Exceptions;
using System.Net;

namespace libreriaAPI.Services
{
    public class AutorServices
    {
        private readonly IMapper _mapper;
        private readonly IAutorRepository _autorRepo;

        public AutorServices(IMapper mapper, IAutorRepository autorRepo)
        {
            _mapper = mapper;
            _autorRepo = autorRepo;
        }

        public async Task<List<Autor>> GetAll()
        {
            var autores = await _autorRepo.GetAll();
            return autores.ToList();
        }

        public async Task<Autor> GetOneById(int id)
        {
            var autor = await _autorRepo.GetOne(c => c.Id == id);
            if (autor == null)
            {
                throw new CustomHttpException($"No se encontro el Autor con Id = {id}", HttpStatusCode.NotFound);
            }
            return autor;
        }

        public async Task<Autor> CreateOne(CreateAutorDTO createAutorDto)
        {
            Autor autor = _mapper.Map<Autor>(createAutorDto);

            await _autorRepo.Add(autor);
            return autor;
        }

        public async Task<Autor> UpdateOneById(int id, UpdateAutorDTO updateAutoDto)
        {
            Autor autor = await GetOneById(id);

            var autorMapped = _mapper.Map(updateAutoDto, autor);

            await _autorRepo.Update(autorMapped);

            return autorMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var autor = await GetOneById(id);

            await _autorRepo.Delete(autor);
        }
    }
}
