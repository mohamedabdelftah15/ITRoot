using ITRoot_Task.Repositres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;
using ITRoot_Task.Services.IServices;
using ITRoot_Task.Repositres.IRepositries;

namespace ITRoot_Task.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<Models.Role> GetRoles()
        {
            List<Models.Role> roles = new List<Models.Role>();
            try
            {
                roles = _roleRepository.GetRoles().Select(e=>new Models.Role {ID=e.ID,RoleName=e.RoleName }).ToList();
                
                return roles;
            }
            catch (Exception ex)
            {

            }
            return roles;
        }
    }
}