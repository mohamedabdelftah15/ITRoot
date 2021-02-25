using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITRoot_Task.Data;
using ITRoot_Task.Repositres.IRepositries;

namespace ITRoot_Task.Repositres
{
    public class InvoiceRepositry:IInvoiceRepositry
    {
        private readonly ITRoot_Task_DBEntities _db;
        public InvoiceRepositry(ITRoot_Task_DBEntities db)
        {
            _db = db;
        }

        public IQueryable<Invoice> GetInvoiceByUserID(int userID)
        {
            IQueryable<Invoice> invoices = null;
            try
            {
                invoices = _db.Invoices.Where(e=>e.UserID==userID&&e.IsDeleted==false);
                return invoices;
            }
            catch (Exception ex)
            {

            }
            return invoices;
        }

        public int AddInvoice(Invoice invoice)
        {
            int result = 0;

            try
            {
                if (invoice != null)
                {
                    _db.Invoices.Add(invoice);
                    _db.SaveChanges();
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