using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BML
{
    public class Categoria
    {
        private DataAccess dataAccess = DataAccess.Instance();
        public int idCategoria { get; set; }

        public string nombre { get; set; }

        public bool activo { get; set; }

        public Categoria() { }


        public int Add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            return dataAccess.Execute("Categoria_Add", parametros);
        }

        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            parametros.Add("@idCategoria", idCategoria);
            return dataAccess.Execute("Categoria_Update", parametros);
        }
        public int Delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idCategoria", idCategoria);
            return dataAccess.Execute("Categoria_Delete", parametros);
        }

        public Categoria GetByID()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idCategoria", idCategoria);
            return dataAccess.QuerySingle<Categoria>("Categoria_GetByID", parametros);
        }
        public IEnumerable<Categoria> GetAll()
        {
            return dataAccess.Query<Categoria>("Categoria_GetAll");
        }

    }
}
