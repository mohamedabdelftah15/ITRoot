using ITRoot_Task.Models;
using ITRoot_Task.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITRoot_Task.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IUserService _userService;
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IUserService userService, IInvoiceService invoiceService)
        {
            _userService = userService;
            _invoiceService = invoiceService;
        }

        public ActionResult Index()
        {
            string username = Session["UserName"] != null ? Session["UserName"].ToString() : "";
            string role = Session["Role"] != null ? Session["Role"].ToString() : "";
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(role))
            {
                return RedirectToAction("LogIn","User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetInvoices()
        {
            List<Models.Invoice> invoices = new List<Models.Invoice>();
            User user = new User();
           
            try
            {
                string username = Session["UserName"] != null ? Session["UserName"].ToString() : "";
                if (!string.IsNullOrEmpty(username))
                {
                    user = _userService.GetUserByUserName(username);
                    if (user!=null)
                    {
                        invoices = _invoiceService.GetInvoiceByUserID(user.ID);
                        return Json(invoices);
                    }
                    
                }
                
                return Json(invoices);
            }
            catch (Exception ex)
            {
            }
            return Json(invoices);
        }


        [HttpPost]
        public ActionResult AddInvoice(List<Invoice> invoices)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                   var currentUser = Session["UserName"] != null ? Session["UserName"].ToString() : "";
                        result = _invoiceService.AddInvoice(invoices,currentUser);
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
            }
            return Json(result);
        }
    }
}