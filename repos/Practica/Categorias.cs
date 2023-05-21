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
    public partial class Categorias : DevExpress.XtraEditors.XtraForm
    {
        public Categorias()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            gcCategoria.DataSource = new BML.Categoria().GetAll();
            gvCategoria.BestFitColumns();
        }
        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cargar();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevaCategoria frm = new NuevaCategoria();
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvCategoria.GetFocusedRowCellValue(colidCategoria);
            EditarCategoria frm = new EditarCategoria(row);
            frm.ShowDialog();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvCategoria.GetFocusedRowCellValue(colidCategoria);
            DialogResult = XtraMessageBox.Show("¿Desea Eliminar el registro?\n Esta accion no se puede deshacer", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                if (new Categoria() { idCategoria = row }.Delete() > 0)
                {
                    XtraMessageBox.Show("Registro eliminado", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}