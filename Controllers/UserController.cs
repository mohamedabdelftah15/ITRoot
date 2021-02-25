using ITRoot_Task.Models;
using ITRoot_Task.Services;
using ITRoot_Task.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ITRoot_Task.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        //[AllowAnonymous]
        public ActionResult Csv()
        {
            List<User> users = new List<User>();
            var builder = new StringBuilder();
            users = _userService.GetUsers();
            builder.AppendLine("ID,FullName,UserName,Email,Phone");
            foreach (var user in users)
            {
                builder.AppendLine($"{user.ID},{user.FullName},{user.UserName},{user.Email},{user.Phone}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "users.csv");
        }
        public ActionResult LogIn()
        {
            List<SelectListItem> roleList = new SelectList(_roleService.GetRoles(),"ID","RoleName").ToList();
            roleList.Insert(0,new SelectListItem { Value = "", Text = "Select User Type", Selected = true, Disabled = true });
            ViewBag.Roles = roleList;
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ConfirmEmail(string Token, string Email)
        {
            User user = null;
            int userID = string.IsNullOrEmpty(Token) ? 0 : int.Parse(Token.Split('-')[0]);
            user = _userService.GetUserByID(userID);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.ConfirmedEmail = true;
                    _userService.AddOrEditUser(user);
                    return RedirectToAction("LogIn", "User");
                }
            }
            return RedirectToAction("Register", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                 result = _userService.AddOrEditUser(user);
                if (result!=0)
                {
                    var message = string.Format("Dear {0}<BR/> Thank you for your registration, please click on thebelow link to complete your registration: <a href =\"{1}\"title =\"User Email Confirm\">{1}</a>",
                                            user.UserName, Url.Action("ConfirmEmail", "User",
                                            new { Token = result + "-" + Guid.NewGuid(), Email = user.Email }, Request.Url.Scheme));

                   await ITRoot_Task.Helper.EmailHelper.SendEmailAsync(user.Email, "Email confirmation",message);
                    
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            // If we got this far, something failed, redisplay form
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInUser logInUser)
        {
            User user = new User();
            if (ModelState.IsValid)
            {
                user = _userService.CheckLogIn(logInUser);
                if (user.UserName!=null&&user.Password!=null&&user.Email!=null)
                {
                    if (user.ConfirmedEmail == true)
                    {
                        Session["UserName"] = user.UserName;
                        Session["Role"] =user.RoleName;
                        return Json(new { Value=user , Message="" });
                    }
                    else
                    {
                        return Json(new {Value="", Message= "Confirm Email Address." });
                    }
                }
                else
                {
                    return Json(new { Value = "", Message = "Invalid username or password or user type." });
                }
            }
            // If we got this far, something failed, redisplay form
            return View("LogIn");
        }
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            Session["Role"] = null;
            Session.Clear();
            return RedirectToAction("LogIn", "User");
        }
        public ActionResult Index()
        {
            string username = Session["UserName"] != null ? Session["UserName"].ToString() : "";
            string role = Session["Role"] != null ? Session["Role"].ToString() : "";
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(role))
            {
                return RedirectToAction("LogIn");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetUsers()
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                users = _userService.GetUsers();
                return Json(users);
            }
            catch (Exception ex)
            {
            }
            return Json(users);
        }
 
        [HttpPost]
        public ActionResult GetRoles()
        {
            List<ITRoot_Task.Models.Role> roles = new List<Models.Role>();
            try
            {
                roles = _roleService.GetRoles();
                return Json(roles);
            }
            catch (Exception ex)
            {
            }
            return Json(roles);
        }

        [HttpPost]
        public ActionResult SearchUsers(string searchValue)
        {
           List<Models.User> users = new List<Models.User>();
            try
            {
                users = _userService.SearchUsers(searchValue);
                return Json(users);
            }
            catch (Exception ex)
            {

            }
            return Json(users);
        }

        [HttpPost]
        public ActionResult GetUserByID(int id)
        {
            Models.User user = new Models.User();
            try
            {
                    user = _userService.GetUserByID(id);
                    return Json(user);
            }
            catch (Exception ex)
            {

            }
            return Json(user);
        }

        [HttpPost]
        public ActionResult AddOrEditUser(Models.User user)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    user.CurrentUser = Session["UserName"] != null ? Session["UserName"].ToString() : "";
                    user.ConfirmedEmail = true;
                     result = _userService.AddOrEditUser(user);
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                    int result = _userService.DeleteUser(id);
                    return Json(result);
            }
            catch (Exception ex)
            {
            }
            return Json(0);
        }
    }
}