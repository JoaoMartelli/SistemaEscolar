using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Cursos : Form
    {
        private readonly ICursoService _cursoService;
        private readonly IEscolaService _escolaService;

        public Cursos()
        {
            InitializeComponent();

            var cursoRepository = new CursoRepository();
            _cursoService = new CursoService(cursoRepository);

            var escolaRepository = new EscolaRepository();
            _escolaService = new EscolaService(escolaRepository);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            CarregarCursosAsync();
        }

        private async void CarregarCursosAsync()
        {
            try
            {
                var cursos = await _cursoService.GetCursosAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cursos.ToList();

                AdicionarColunasDeAcoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cursos: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarColunasDeAcoes()
        {
            if (dataGridView1.Columns.Contains("colEditar"))
                dataGridView1.Columns.Remove("colEditar");
            if (dataGridView1.Columns.Contains("colAtualizar"))
                dataGridView1.Columns.Remove("colAtualizar");

            var colEditar = new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };
            var colAtualizar = new DataGridViewButtonColumn
            {
                Name = "colAtualizar",
                HeaderText = "Atualizar",
                Text = "🔄",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };

            dataGridView1.Columns.Add(colEditar);
            dataGridView1.Columns.Add(colAtualizar);

            colEditar.DisplayIndex = dataGridView1.Columns.Count - 2;
            colAtualizar.DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col.Name == "colEditar")
            {
                MessageBox.Show("Abrir tela de edição de Curso (implementar).",
                    "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (col.Name == "colAtualizar")
            {
                CarregarCursosAsync();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var c = new CadastrarCurso(_cursoService, _escolaService))
            {
                if (c.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarCursosAsync();
                }
            }
        }
    }
}
