using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            Alunos a = new Alunos();
            a.ShowDialog();
        }

        private void btnEscolas_Click(object sender, EventArgs e)
        {
            Escolas esc = new Escolas();
            esc.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos c = new Cursos();
            c.ShowDialog();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Tem certeza que deseja sair?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
