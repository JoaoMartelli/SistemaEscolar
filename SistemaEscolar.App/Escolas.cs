using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Escolas : Form
    {
        private readonly IEscolaService _escolaService;

        public Escolas()
        {
            InitializeComponent();


            var escolaRepository = new EscolaRepository();
            _escolaService = new EscolaService(escolaRepository);

            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            CarregarEscolasAsync();
        }

        private async void CarregarEscolasAsync()
        {
            try
            {
                var escolas = await _escolaService.GetEscolasAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = escolas.ToList();

                AdicionarColunasDeAcoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar escolas: " + ex.Message, "Erro",
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

            colEditar.DisplayIndex = dataGridView1.Columns.Count -1;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var coluna = dataGridView1.Columns[e.ColumnIndex];
            var linha = dataGridView1.Rows[e.RowIndex];
            var escolaSelecionada = linha?.DataBoundItem as Escola;

            if (escolaSelecionada == null) return;

            if (coluna.Name == "colEditar")
            {
                // Abre a tela de edição com a Escola atual
                using (var edit = new EditarEscola(_escolaService, escolaSelecionada))
                {
                    if (edit.ShowDialog(this) == DialogResult.OK)
                    {
                        CarregarEscolasAsync(); // atualiza a lista após salvar
                    }
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var c = new CadastrarEscola(_escolaService))
            {
                if (c.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarEscolasAsync();
                }
            }
        }
    }
}
