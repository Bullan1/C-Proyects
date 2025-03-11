using CarteleraCine.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteleraCine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
             //Realizamos una instancia del formulario de la segunda ventana
            FormularioCRUD ventana2 = new FormularioCRUD();
            //Mostramos la segunda ventana con .Show();
            ventana2.Show();
        }
    }
}
