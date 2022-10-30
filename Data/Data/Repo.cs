using Dapper.Contrib.Extensions;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        protected string Conect;
        public Repo(string conect)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name }"; };
            Conect = conect;
        }
        public bool Delete(T entity)
        {
            using (var conection = new SqlConnection(Conect))
            {
                return conection.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            using (var conection = new SqlConnection(Conect))
            {
                return conection.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var conection = new SqlConnection(Conect))
            {
                return conection.GetAll<T>();
            }
        }

        public bool Update(T entity)
        {
            using (var conection = new SqlConnection(Conect))
            {
                return conection.Update<T>(entity);
            }
        }
    }
}
