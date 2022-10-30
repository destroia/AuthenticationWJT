using Dapper;
using Data.Interfaces;
using Data.Repo;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class SupplierData : Repo<Supplier>, ISupplierData
    {
        public SupplierData(string conect) : base(conect)
        {
            
        }
        public IEnumerable<Supplier> ListView(int pag, int row)
        {
            var param = new DynamicParameters();

            param.Add("@page", pag);
            param.Add("@rows", row);

            using (var conecction = new SqlConnection(Conect))
            {
                return conecction.Query<Supplier>("[dbo].[CustomerPagedList]",
                    param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
