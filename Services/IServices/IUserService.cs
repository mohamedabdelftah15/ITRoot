using ITRoot_Task.Repositres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;

namespace ITRoot_Task.Services.IServices
{
    public interface IUserService
    {
        Models.User CheckLogIn(Models.LogInUser logInUser);
        List<Models.User> GetUsers();
        List<Models.User> SearchUsers(string searchValue);
        Models.User GetUserByID(int id);
        Models.User GetUserByUserName(string userName);
        int AddOrEditUser(ITRoot_Task.Models.User user);
        int DeleteUser(int id);
        Models.User MapDBUserToUserModel(Data.User user);
    }
}