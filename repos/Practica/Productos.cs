using BML;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class Productos : DevExpress.XtraEditors.XtraForm
    {
        public Productos()
        {
            InitializeComponent();
        }
        
        private void cargar()
        {
            gcProducto.DataSource = new Producto().GetAll();
            rlupCategoria.DataSource = new Categoria().GetAll();
            rlupMarca.DataSource = new Marca().GetAll();
            gvProducto.BestFitColumns();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cargar();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoProducto frm = new NuevoProducto();
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvProducto.GetFocusedRowCellValue(colidProducto);
            EditarProducto frm = new EditarProducto(row);
            frm.ShowDialog();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvProducto.GetFocusedRowCellValue(colidProducto);
          DialogResult =  XtraMessageBox.Show("¿Desea Eliminar el registro?\n Esta accion no se puede deshacer","Confirmación",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(DialogResult == DialogResult.Yes)
            {
                if(new Producto() { idProducto = row }.Delete() > 0)
                {
                    XtraMessageBox.Show("Registro eliminado", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
