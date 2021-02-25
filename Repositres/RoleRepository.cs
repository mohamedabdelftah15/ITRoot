using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;
using ITRoot_Task.Repositres.IRepositries;


namespace ITRoot_Task.Repositres
{
    public class RoleRepository:IRoleRepository
    {
        private readonly ITRoot_Task_DBEntities _db;
        public RoleRepository(ITRoot_Task_DBEntities db)
        {
            _db = db;
        }
        public IQueryable<Role> GetRoles()
        {
            IQueryable<Role> roles = null;
            try
            {
                roles =_db.Roles;
                return roles;
            }
            catch (Exception ex)
            {

            }
            return roles;
        }
    }
}