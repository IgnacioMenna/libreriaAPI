using libreriaAPI.Models.Role;
using libreriaAPI.Repositories;
using libreriaAPI.Utils.Exceptions;
using System.Net;

namespace libreriaAPI.Services
{
    public class RoleServices
    {
        private readonly IRoleRepository _roleRepo;

        public RoleServices(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<Role> GetOneByName(string name)
        {
            var role = await _roleRepo.GetOne(r => r.Name == name);
            if (role == null)
            {
                throw new CustomHttpException($"No se encontro el rol con Nombre = {name}", HttpStatusCode.NotFound);
            }
            return role;
        }

        public async Task<List<Role>> GetManyByIds(List<int> roleIds)
        {
            if (roleIds == null || roleIds.Count == 0)
            {
                throw new CustomHttpException("Roles vacios.", HttpStatusCode.BadRequest);
            }

            var roles = await _roleRepo.GetAll(r => roleIds.Contains(r.Id));
            return roles.ToList();
        }
    }
}
