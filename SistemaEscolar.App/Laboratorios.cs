using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Laboratorios : Form
    {
        private readonly ILaboratorioService _laboratorioService;
        private readonly IEscolaService _escolaService;

        public Laboratorios()
        {
            InitializeComponent();

            var laboratorioRepository = new LaboratorioRepository();
            _laboratorioService = new LaboratorioService(laboratorioRepository);

            var escolaRepository = new EscolaRepository();
            _escolaService = new EscolaService(escolaRepository);

            // autogerar as colunas
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            CarregarLaboratoriosAsync();
        }

        private async void CarregarLaboratoriosAsync()
        {
            try
            {
                var laboratorios = await _laboratorioService.GetLaboratoriosAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = laboratorios.ToList();

                // adiciona os botões sempre após o DataSource
                AdicionarColunasDeAcoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar laboratórios: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarColunasDeAcoes()
        {
            // remove colunas duplicadas (se já existirem)
            if (dataGridView1.Columns.Contains("colEditar"))
                dataGridView1.Columns.Remove("colEditar");

            // cria as colunas de botão
            var colEditar = new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };

            // adiciona as colunas no final
            dataGridView1.Columns.Add(colEditar);

            // garante que fiquem como as últimas colunas
            colEditar.DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var coluna = dataGridView1.Columns[e.ColumnIndex];
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Laboratorio lab)
            {
                if (coluna.Name == "colEditar")
                {
                    using (var f = new EditarLaboratorio(_laboratorioService, _escolaService, lab))
                    {
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            CarregarLaboratoriosAsync();
                        }
                    }
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var c = new CadastrarLaboratorio(_laboratorioService, _escolaService))
            {
                if (c.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarLaboratoriosAsync();
                }
            }
        }
    }
}
