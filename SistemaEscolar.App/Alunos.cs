using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Alunos : Form
    {
        private readonly IAlunoService _alunoService;

        public Alunos()
        {
            InitializeComponent();

            var alunoRepository = new AlunoRepository();
            _alunoService = new AlunoService(alunoRepository);

            if (btnVincular != null)
                btnVincular.Click += btnVincular_Click;

            CarregarAlunosAsync();
        }

        private async void CarregarAlunosAsync()
        {
            try
            {
                var alunos = await _alunoService.GetAlunosAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = alunos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar alunos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var c = new CadastrarAluno(_alunoService))
            {
                if (c.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarAlunosAsync();
                }
            }
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            using (var v = new VincularAlunoCurso())
            {
                v.ShowDialog(this);
            }
        }
    }
}
