using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;
using ITRoot_Task.Repositres.IRepositries;

namespace ITRoot_Task.Repositres
{
    public class UserRepositry:IUserRepositry
    {
        private readonly ITRoot_Task_DBEntities _db;
        public UserRepositry(ITRoot_Task_DBEntities db)
        {
            _db = db;
        }

        public CheckLogin_Result CheckLogIn(Models.LogInUser logInUser)
        {
            //IQueryable<CheckLogin_Result> checkLoginResult = null;
            CheckLogin_Result dbUser = new CheckLogin_Result();
            try
            {
                dbUser = _db.CheckLogin(logInUser.UserName, logInUser.Password,logInUser.RoleID).Select(e=>new CheckLogin_Result 
                {
                ID=e.ID,
                FullName=e.FullName,
                UserName=e.UserName,
                Password=e.Password,
                Phone=e.Phone,
                Email=e.Email,
                ConfirmedEmail=e.ConfirmedEmail,
                RoleID=e.RoleID,
                RoleName=e.RoleName,
                CreatedBy=e.CreatedBy,
                CreatedDate=e.CreatedDate,
                UpdatedBy=e.UpdatedBy,
                UpdatedDate=e.UpdatedDate,
                IsDeleted=e.IsDeleted
                }).FirstOrDefault();
                 
                if (dbUser != null)
                {
                    if (dbUser.ConfirmedEmail == true)
                    {
                        return dbUser;
                    }
                 
                }
            }
            catch (Exception ex)
            {
            }
            return dbUser;
        }
        public IQueryable<UserList_Result> GetUsers()
        {
            IQueryable<UserList_Result> users = null;
            try
            {
                users = _db.UserList().AsQueryable();
                return users;
            }
            catch (Exception ex)
            {

            }
            return users;
        }
        public IQueryable<UserList_Result> SearchUsers(string searchValue)
        {
            IQueryable<UserList_Result> users = null;
            try
            {
                users = _db.UserList().Where(e=>e.FullName.ToLower().Contains(searchValue.ToLower())|| e.UserName.ToLower().Contains(searchValue.ToLower())|| e.Email.ToLower().Contains(searchValue.ToLower())|| e.Phone.Contains(searchValue)).AsQueryable();
                return users;
            }
            catch (Exception ex)
            {

            }
            return users;
        }
        public User GetUserByID(int id)
        {
            User user = new User();
            try
            {
                user = _db.Users.Include("Roles").Include("Invoices").FirstOrDefault(e=>e.ID==id);
                if (user!=null)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            User user = new User();
            try
            {
                user = _db.Users.Include("Roles").Include("Invoices").FirstOrDefault(e => e.UserName == userName);
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
        public bool GetUserByRole(string roleName)
        {
            User user = new User();
            bool check = false;
            try
            {
                check = _db.Users.Include("Roles").Any(e => e.Roles.Any(x=>x.RoleName==roleName));
                if (check)
                {
                    return check;
                }
            }
            catch (Exception ex)
            {

            }
            return check;
        }
        public int AddOrEditUser(Models.User user)
        {
            User existUser = new User();
            int result = 0;
            
            try
            {
                if (user != null&&user.ID==0)
                {
                    existUser = _db.Users.FirstOrDefault(e => (e.UserName == user.UserName && e.Email == user.Email && e.Phone == user.Phone)&&e.IsDeleted==false);
                    if (existUser==null)
                    {
                        var createdBy = !string.IsNullOrEmpty(user.CurrentUser) ? user.CurrentUser : user.UserName;
                        var x = _db.AddUser(user.FullName, user.UserName, user.Password, user.Email, user.Phone, user.RoleID,createdBy, DateTime.Now);
                        var userID = _db.Users.FirstOrDefault(e => (e.UserName == user.UserName && e.Email == user.Email && e.Phone == user.Phone)&&e.IsDeleted==false).ID;
                        result = userID;
                        return result;
                    }
                }
                else if (user != null && user.ID != 0)
                {
                    User dbUser = new User();
                    dbUser = _db.Users.FirstOrDefault(e => e.ID == user.ID && e.IsDeleted==false);
                    if (dbUser != null)
                    {
                        var updatedBy = !string.IsNullOrEmpty(user.CurrentUser) ? user.CurrentUser : user.UserName;
                        _db.EditUser(user.ID, user.FullName, user.UserName, user.Password, user.Email,user.ConfirmedEmail, user.Phone, user.RoleID,updatedBy, DateTime.Now);
                        result = user.ID;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int DeleteUser(int id)
        {
            int result = 0;
            User dbUser = new User();
            try
            {
                dbUser = _db.Users.FirstOrDefault(e => e.ID == id);
                if (dbUser != null)
                {
                  _db.DeleteUser(id);
                    result = 1;
                    return result;
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        
    }
}