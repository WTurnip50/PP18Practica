using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BML
{
    public class Marca
    {
        private DataAccess dataAccess = DataAccess.Instance();
        public int idMarca { get; set; }

        public string nombre { get; set; }

        public bool activo { get; set; }

        public Marca() { }


        public int Add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            return dataAccess.Execute("Marca_Add", parametros);
        }

        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            parametros.Add("@idMarca", idMarca);
            return dataAccess.Execute("Marca_Update", parametros);
        }
        public int Delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idMarca", idMarca);
            return dataAccess.Execute("Marca_Delete", parametros);
        }

        public Marca GetByID()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idMarca", idMarca);
            return dataAccess.QuerySingle<Marca>("Marca_GetByID", parametros);
        }
        public IEnumerable<Marca> GetAll()
        {
            return dataAccess.Query<Marca>("Marca_GetAll");
        }

    }
}
