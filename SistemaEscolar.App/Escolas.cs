using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Escolas : Form
    {
        public Escolas()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarEscola cad = new CadastrarEscola();
            cad.ShowDialog();
        }
    }
}
