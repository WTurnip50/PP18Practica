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
    public partial class EditarProducto : DevExpress.XtraEditors.XtraForm
    {
        private int idProd =0, idC = 1, idM = 1, idce = 0, idme = 0;
        public EditarProducto()
        {
            InitializeComponent();
        }

        public EditarProducto(int id)
        {
            InitializeComponent();
            Producto producto = new Producto() { idProducto = id}.GetByID();
            this.idProd = id;
            this.idce = producto.idCategoria;
            this.idme = producto.idMarca;
            this.idC = producto.idCategoria - 1;
            this.idM = producto.idMarca - 1;
            this.txtDescripcion.Text = producto.descripcion;
            this.txtPU.Text = ""+producto.precioUnitario;
            this.txtStock.Text = "" + producto.stock;
            this.txtCodigo.Text = producto.codigo;
        }
        private void rlup()
        {

            categoriaBindingSource.DataSource = new Categoria().GetAll();
            marcaBindingSource.DataSource = new Marca().GetAll();
        }

        private bool validar()
        {
            if (txtCodigo.Text.Trim().Equals("") || txtPU.Text.Trim().Equals("") ||
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
            if (!validar())
            {
                int idMarca = Convert.ToInt32(lupMarca.EditValue), idCategoria = Convert.ToInt32(lupCat.EditValue),
                stock = Convert.ToInt32(txtStock.Text.Trim());
                decimal pu = decimal.Parse(txtPU.Text.Trim());
                string desc = txtDescripcion.Text.Trim(), codigo = txtCodigo.Text.Trim();
                if (new Producto()
                {
                    idProducto = this.idProd,
                    idMarca = idMarca,
                    idCategoria = idCategoria,
                    stock = stock,
                    precioUnitario = pu,
                    descripcion = desc,
                    codigo = codigo
                }.Update() > 0)
                {
                    Message(1);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Message(int switch_on)
        {
            switch (switch_on)
            {
                case 1:
                    XtraMessageBox.Show("Actualizado", "Nuevo Producto", MessageBoxButtons.OK);
                    break;
                case 2:
                    XtraMessageBox.Show("Se encotraron campos vacios", "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDescripcion.Focus();
                    break;
                default:
                    break;
            }
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            rlup();
            lupCat.ItemIndex = this.idC;
            lupMarca.ItemIndex = this.idM;
        }
    }
}