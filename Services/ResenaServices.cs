using AutoMapper;
using libreriaAPI.Repositories;
using libreriaAPI.Utils.Exceptions;
using System.Net;
using libreriaAPI.Models.Resena;
using libreriaAPI.Models.Resena.Dto;

namespace libreriaAPI.Services
{
    public class ResenaServices
    {
        private readonly IMapper _mapper;
        private readonly IResenaRepository _resenaRepo;
        private object updateResenaDto;

        public ResenaServices(IMapper mapper, IResenaRepository resenaRepo)
        {
            _mapper = mapper;
            _resenaRepo = resenaRepo;
        }

        public async Task<List<Resena>> GetAll()
        {
            var resenas = await _resenaRepo.GetAll();
            return resenas.ToList();
        }

        public async Task<Resena> GetOneById(int id)
        {
            var resena = await _resenaRepo.GetOne(c => c.Id == id);
            if (resena == null)
            {
                throw new CustomHttpException($"No se encontro la Resena con Id = {id}", HttpStatusCode.NotFound);
            }
            return resena;
        }

        public async Task<Resena> CreateOne(CreateResenaDTO createResenaDto)
        {
            Resena resena = _mapper.Map<Resena>(createResenaDto);

            await _resenaRepo.Add(resena);
            return resena;
        }

        public async Task<Resena> UpdateOneById(int id, UpdateResenaDTO updateResenaDto)
        {
            Resena resena = await GetOneById(id);

            var resenaMapped = _mapper.Map(updateResenaDto, resena);

            await _resenaRepo.Update(resenaMapped);

            return resenaMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var resena = await GetOneById(id);

            await _resenaRepo.Delete(resena);
        }
    }
}
