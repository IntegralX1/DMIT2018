using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using ChinookSystem.DAL;
using ChinookSystem.Data.Entities;
using System.ComponentModel;
using DMIT2018Common.UserControls;
using ChinookSystem.Data.POCOs;
using ChinookSystem.Data.DTOs;
#endregion


namespace ChinookSystem.BLL
{
    public class CustomerController
    {
        public Customer Customer_Get(int customerid)
        {
            using (var context = new ChinookContext())
            {
                return context.Customers.Find(customerid);
            }
        }
    }
}
