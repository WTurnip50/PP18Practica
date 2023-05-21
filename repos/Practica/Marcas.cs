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
    public partial class Marcas : DevExpress.XtraEditors.XtraForm
    {
        public Marcas()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            gcMarca.DataSource = new BML.Marca().GetAll();
            gvMarca.BestFitColumns();
        }
        private void Marca_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cargar();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevaMarca frm = new NuevaMarca();
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvMarca.GetFocusedRowCellValue(colidMarca);
            EditarMarca frm = new EditarMarca(row);
            frm.ShowDialog();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = (int)gvMarca.GetFocusedRowCellValue(colidMarca);
            DialogResult = XtraMessageBox.Show("¿Desea Eliminar el registro?\n Esta accion no se puede deshacer", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                if (new Marca() { idMarca = row }.Delete() > 0)
                {
                    XtraMessageBox.Show("Registro eliminado", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}