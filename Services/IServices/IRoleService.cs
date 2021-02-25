using ITRoot_Task.Repositres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;

namespace ITRoot_Task.Services.IServices
{
    public interface IRoleService
    {
        List<Models.Role> GetRoles();
    }
}