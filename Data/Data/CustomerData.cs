using Dapper;
using Data.Interfaces;
using Data.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class CustomerData : Repo<Customer>, ICustomerData
    {
        public CustomerData(string conect):base(conect)
        {

        }

        public IEnumerable<Customer> ListView(int pag, int row)
        {
            var param = new DynamicParameters();

            param.Add("@page", pag);
            param.Add("@rows", row);

            using (var conecction = new SqlConnection( Conect))
            {
                return conecction.Query<Customer>("[dbo].[SupplierPagedList]",
                    param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
