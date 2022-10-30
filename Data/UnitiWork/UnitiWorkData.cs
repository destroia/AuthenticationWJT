using Data.Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitiWork
{
    public class UnitiWorkData : IUnitiWork
    {
        public UnitiWorkData(string conecction)
        {
            Customer = new CustomerData(conecction);
            User = new UserData(conecction);
            Supplier = new SupplierData(conecction);
        }

        public ICustomerData Customer { get; private set; }

        public IUserData User { get; private set; }

        public ISupplierData Supplier { get; private set; }
    }
}
