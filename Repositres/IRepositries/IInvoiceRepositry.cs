using ITRoot_Task.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoot_Task.Repositres.IRepositries
{
    public interface IInvoiceRepositry
    {
        IQueryable<Invoice> GetInvoiceByUserID(int userID);
        int AddInvoice(Invoice invoice);
    }
}