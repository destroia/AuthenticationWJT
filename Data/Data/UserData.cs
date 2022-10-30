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
    public class UserData : Repo<User>, IUserData
    {
        public UserData(string Conecction):base (Conecction)
        {

        }
        public User ValidatieUser(string email, string password)
        {
            var param = new DynamicParameters();
            param.Add("@email", email);
            param.Add("@password", password);

            using (var conecction = new SqlConnection(Conect))
            {
                return conecction.QueryFirstOrDefault<User>("[dbo].[ValidateUser]",
                   param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
