using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarCurso c = new CadastrarCurso();
            c.ShowDialog();
        }
    }
}
