using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BML
{
    public class Producto
    {
        private DataAccess dataAccess = DataAccess.Instance();
        public int idProducto { get; set; }
        public String descripcion { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public string codigo { get; set; }
        public bool activo { get; set; }

        public Producto() { }

        public int Add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@descripcion",descripcion);
            parametros.Add("@idCategoria", idCategoria);
            parametros.Add("@idMarca", idMarca);
            parametros.Add("@precioUnitario", precioUnitario);
            parametros.Add("@stock",stock);
            parametros.Add("@codigo", codigo);
            return dataAccess.Execute("Producto_Add", parametros);
        }
        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            parametros.Add("@descripcion", descripcion);
            parametros.Add("@idCategoria", idCategoria);
            parametros.Add("@idMarca", idMarca);
            parametros.Add("@precioUnitario", precioUnitario);
            parametros.Add("@stock", stock);
            parametros.Add("@codigo", codigo);
            return dataAccess.Execute("Producto_Update", parametros);
        }
        public int Delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            return dataAccess.Execute("Producto_Delete", parametros);
        }
        public Producto GetByID()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            return dataAccess.QuerySingle<Producto>("Producto_GetByID", parametros);
        }
        public IEnumerable<Producto> GetAll()
        {
            return dataAccess.Query<Producto>("Producto_GetAll");
        }

    }
}
