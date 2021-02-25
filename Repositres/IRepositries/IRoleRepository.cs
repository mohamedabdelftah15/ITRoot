using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;

namespace ITRoot_Task.Repositres.IRepositries
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetRoles();
    }
}