using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Models;
using ITRoot_Task.Repositres.IRepositries;
using ITRoot_Task.Services.IServices;

namespace ITRoot_Task.Services
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IInvoiceRepositry _invoiceRepositry;
        private readonly IUserRepositry _userRepositry;
        public InvoiceService(IInvoiceRepositry invoiceRepositry, IUserRepositry userRepositry)
        {
            _invoiceRepositry = invoiceRepositry;
            _userRepositry = userRepositry;
        }
        public List<Invoice> GetInvoiceByUserID(int userID)
        {
            List<Invoice> invoices = new List<Invoice>();
            try
            {
                invoices =_invoiceRepositry.GetInvoiceByUserID(userID).Select(e=>new Invoice {ID=e.ID,InvoiceNumber=e.InvoiceNumber,Product=e.Product,Quantity=e.Quantity,Price=e.Price,UserID=e.UserID }).ToList();
                return invoices;
            }
            catch (Exception ex)
            {

            }
            return invoices;
        }

        public int AddInvoice(List<Invoice> invoices,string loggedInUser)
        {
            int result = 0;
            Data.Invoice dbInvoice = new Data.Invoice();
            Data.User user = new Data.User();
            try
            {
                string invoiceNumber = Guid.NewGuid().ToString();
                var createdBy = !string.IsNullOrEmpty(loggedInUser) ? loggedInUser : "";
                user = _userRepositry.GetUserByUserName(loggedInUser);
                if (user!=null)
                {
                    if (invoices != null)
                    {
                        foreach (Invoice item in invoices)
                        {
                            dbInvoice.InvoiceNumber = invoiceNumber;
                            dbInvoice.Product = item.Product;
                            dbInvoice.Quantity = item.Quantity;
                            dbInvoice.Price = item.Price;
                            dbInvoice.IsDeleted = false;
                            dbInvoice.UserID = user.ID;
                            dbInvoice.CreatedBy = createdBy;
                            dbInvoice.CreatedDate = DateTime.Now;
                            result = _invoiceRepositry.AddInvoice(dbInvoice);
                            if (result == 0)
                            {
                                return result;

                            }
                        }
                    }
                    
                }
                
                   
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}