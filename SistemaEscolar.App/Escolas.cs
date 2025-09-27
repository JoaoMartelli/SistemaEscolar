using SistemaEscolar.Core.Domain.Contracts.Services;
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

            CarregarEscolasAsync();
        }

        private async void CarregarEscolasAsync()
        {
            try
            {
                var escolas = await _escolaService.GetEscolasAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = escolas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar escolas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
