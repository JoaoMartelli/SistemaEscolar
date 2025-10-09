using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
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

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

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

                AdicionarColunasDeAcoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar alunos: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarColunasDeAcoes()
        {
            if (dataGridView1.Columns.Contains("colEditar"))
                dataGridView1.Columns.Remove("colEditar");

            var colEditar = new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };

            dataGridView1.Columns.Add(colEditar);

            colEditar.DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];
            var row = dataGridView1.Rows[e.RowIndex];

            if (row.DataBoundItem is Aluno aluno)
            {
                if (col.Name == "colEditar")
                {
                    using (var f = new EditarAluno(_alunoService, aluno))
                    {
                        if (f.ShowDialog(this) == DialogResult.OK)
                            CarregarAlunosAsync();
                    }
                }
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
