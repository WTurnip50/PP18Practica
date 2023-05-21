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
    public partial class EditarMarca : DevExpress.XtraEditors.XtraForm
    {
        private int idMarca;
        public EditarMarca()
        {
            InitializeComponent();
        }

        public EditarMarca(int id)
        {
            InitializeComponent();
            this.idMarca = id;
        }
        private void EditarMarca_Load(object sender, EventArgs e)
        {

        }
    }
}