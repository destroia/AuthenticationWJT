using System;
using System.Collections.Generic;


namespace Data.Interfaces
{
    public interface ICustomerData : IRepo<Customer>
    {
        IEnumerable<Customer> ListView(int pag, int row);
    }
}
