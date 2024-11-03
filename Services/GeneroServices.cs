using AutoMapper;
using libreriaAPI.Models.Genero;
using libreriaAPI.Models.Genero.Dto;
using libreriaAPI.Repositories;
using libreriaAPI.Utils.Exceptions;
using System.Net;

namespace libreriaAPI.Services
{
    public class GeneroServices
    {
        private readonly IMapper _mapper;
        private readonly IGeneroRepository _generoRepo;
        private object updateGeneroDto;

        public GeneroServices(IMapper mapper, IGeneroRepository generoRepo)
        {
            _mapper = mapper;
            _generoRepo = generoRepo;
        }

        public async Task<List<Genero>> GetAll()
        {
            var generos = await _generoRepo.GetAll();
            return generos.ToList();
        }

        public async Task<Genero> GetOneById(int id)
        {
            var genero = await _generoRepo.GetOne(c => c.Id == id);
            if (genero == null)
            {
                throw new CustomHttpException($"No se encontro el Genero con Id = {id}", HttpStatusCode.NotFound);
            }
            return genero;
        }

        public async Task<Genero> CreateOne(CreateGeneroDTO createGeneroDto)
        {
            Genero genero = _mapper.Map<Genero>(createGeneroDto);

            await _generoRepo.Add(genero);
            return genero;
        }

        public async Task<Genero> UpdateOneById(int id, UpdateGeneroDTO updateGeneroDto)
        {
            Genero genero = await GetOneById(id);

            var generoMapped = _mapper.Map(updateGeneroDto, genero);

            await _generoRepo.Update(generoMapped);

            return generoMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var genero = await GetOneById(id);

            await _generoRepo.Delete(genero);
        }
    }
}
