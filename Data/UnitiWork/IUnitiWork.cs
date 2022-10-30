﻿using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitiWork
{
    public interface IUnitiWork
    {
        ICustomerData Customer { get;  }
        IUserData User { get; }
        ISupplierData Supplier { get; }
    }
}
