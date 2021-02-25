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
    public class UserService : IUserService
    {
        private readonly IUserRepositry _userRepositry;
        public UserService(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }
        public Models.User CheckLogIn(Models.LogInUser logInUser)
        {
            Models.User user = new Models.User();
            CheckLogin_Result checkLogin_Result = new CheckLogin_Result();
            try
            {
                if (logInUser != null)
                {
                    checkLogin_Result = _userRepositry.CheckLogIn(logInUser);
                    user = MapCheckLogin_ResultToUserModel(checkLogin_Result);
                    return user;
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }
        public List<Models.User> GetUsers()
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                users = _userRepositry.GetUsers().Select(e => new Models.User { ID = e.ID, FullName = e.FullName, UserName = e.UserName, Password = e.Password, Email = e.Email, Phone = e.Phone, RoleID = e.RoleID, RoleName = e.RoleName }).ToList();
                return users;
            }
            catch (Exception ex)
            {

            }
            return users;
        }
        public List<Models.User> SearchUsers(string searchValue)
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                users = _userRepositry.SearchUsers(searchValue).Select(e => new Models.User { ID = e.ID, FullName = e.FullName, UserName = e.UserName, Password = e.Password, Email = e.Email, Phone = e.Phone, RoleID = e.RoleID, RoleName = e.RoleName }).ToList();

                return users;
            }
            catch (Exception ex)
            {

            }
            return users;
        }
        public Models.User GetUserByID(int id)
        {
            Data.User dbUser = new Data.User();
            Models.User user = new Models.User();
            try
            {
                dbUser = _userRepositry.GetUserByID(id);
                user = MapDBUserToUserModel(dbUser);
                if (user != null)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }
        public Models.User GetUserByUserName(string userName)
        {
            Data.User dbUser = new Data.User();
            Models.User user = new Models.User();
            try
            {
                dbUser = _userRepositry.GetUserByUserName(userName);
                user = MapDBUserToUserModel(dbUser);
                if (user != null)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }
        public int AddOrEditUser(ITRoot_Task.Models.User user)
        {
            int result = 0;
            bool checkRole = false;
            User user1 = new User();
            try
            {
                if (user != null)
                {
                    if (user.ID==0)
                    {
                        checkRole = _userRepositry.GetUserByRole("Admin");
                        if (checkRole==false)
                        {
                            user.RoleID = 1;
                            user.RoleName = "Admin";
                        }
                        else
                        {
                            user.RoleID = 2;
                            user.RoleName = "User";
                        }
                    }
                    result = _userRepositry.AddOrEditUser(user);
                    return result;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int DeleteUser(int id)
        {
            try
            {
                int userID = _userRepositry.DeleteUser(id);
                return userID;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public Models.User MapDBUserToUserModel(Data.User user)
        {
            Models.User user1 = new Models.User();
            if (user != null)
            {
                user1 = new Models.User { ID = user.ID, FullName = user.FullName, UserName = user.UserName, Password = user.Password, Email = user.Email, Phone = user.Phone, RoleID = user.Roles.First().ID, RoleName = user.Roles.First().RoleName, Roles = user.Roles.Select(e => new Models.Role { ID = e.ID, RoleName = e.RoleName }).ToList() };
            }
            return user1;
        }
        public Models.User MapCheckLogin_ResultToUserModel(Data.CheckLogin_Result checkLogin_Result)
        {
            Models.User user = new Models.User();
            if (checkLogin_Result != null)
            {
                user = new Models.User { ID = checkLogin_Result.ID, FullName = checkLogin_Result.FullName, UserName = checkLogin_Result.UserName, Password = checkLogin_Result.Password, Email = checkLogin_Result.Email,ConfirmedEmail=checkLogin_Result.ConfirmedEmail, Phone = checkLogin_Result.Phone, RoleID = checkLogin_Result.RoleID, RoleName = checkLogin_Result.RoleName};
            }
            return user;
        }
    }
}