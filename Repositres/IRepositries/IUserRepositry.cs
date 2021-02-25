using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;

namespace ITRoot_Task.Repositres.IRepositries
{
    public interface IUserRepositry
    {
        CheckLogin_Result CheckLogIn(Models.LogInUser logInUser);
        IQueryable<UserList_Result> GetUsers();
        IQueryable<UserList_Result> SearchUsers(string searchValue);
        bool GetUserByRole(string roleName);
        User GetUserByID(int id);
        User GetUserByUserName(string userName);
        int AddOrEditUser(Models.User user);
        int DeleteUser(int id);
       
    }
}