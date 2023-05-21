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
    public partial class NuevoProducto : DevExpress.XtraEditors.XtraForm
    {
        public int mar = 1,ca = 1;
        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void rlup()
        {
            
            categoriaBindingSource.DataSource =  new Categoria().GetAll();
            marcaBindingSource.DataSource = new Marca().GetAll();     
        }

        private void Message(int switch_on)
        {
            switch (switch_on)
            {
                case 1:
                    XtraMessageBox.Show("Almacenado","Nuevo Producto", MessageBoxButtons.OK);
                    break;
                case 2:
                    XtraMessageBox.Show("Se encotraron campos vacios", "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDescripcion.Focus();
                    break;
                default:
                    break;
            }
        }
        private bool validar()
        {
            if (txtCodigo.Text.Trim().Equals("")||txtPU.Text.Trim().Equals("")||
                txtStock.Text.Trim().Equals("") || txtDescripcion.Text.Trim().Equals(""))
            {
                Message(2);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Creamos un objeto con los valores obtenidos.
            XtraMessageBox.Show(""+lupCat.EditValue);
            if (!validar())
            {
                int idMarca = Convert.ToInt32(lupMarca.EditValue), idCategoria = Convert.ToInt32(lupCat.EditValue),
                stock = Convert.ToInt32(txtStock.Text.Trim());
                decimal pu = decimal.Parse(txtPU.Text.Trim());
                string desc = txtDescripcion.Text.Trim(), codigo = txtCodigo.Text.Trim();
                if (new Producto() {idMarca = idMarca, idCategoria = idCategoria, stock = stock,
                precioUnitario = pu, descripcion = desc, codigo = codigo}.Add() > 0)
                {
                    Message(1);
                }
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            rlup();
            lupCat.ItemIndex = 1;
            lupMarca.ItemIndex = this.mar;
        }
    }
}