using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;

namespace SistemaEscolar.App
{
    public partial class Alunos : Form
    {
        public Alunos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var alunoRepository = new AlunoRepository();
            IAlunoService alunoService = new AlunoService(alunoRepository);

            CadastrarAluno c = new CadastrarAluno(alunoService);
            c.ShowDialog();
        }
    }
}
