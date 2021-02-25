using ITRoot_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ITRoot_Task.Services.IServices
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoiceByUserID(int userID);
        int AddInvoice(List<Invoice> invoices, string loggedInUser);
    }
}