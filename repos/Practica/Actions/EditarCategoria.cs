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
    public partial class EditarCategoria : DevExpress.XtraEditors.XtraForm
    {
        private int idCategoria;
        public EditarCategoria()
        {
            InitializeComponent();
        }

        public EditarCategoria(int id)
        {
            InitializeComponent();
            this.idCategoria = id;
        }

        private void EditarCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}