using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Enum;
using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class CadastrarEscola : Form
    {
        private readonly IEscolaService _escolaService;

        public CadastrarEscola(IEscolaService escolaService)
        {
            InitializeComponent();

            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));

            cbEstados.Items.AddRange(Enum.GetNames(typeof(EstadosEnum)));
        }

        private void CadastrarEscola_Load(object sender, EventArgs e)
        {
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var escola = new Escola
                {
                    NomeCompleto = txtNome.Text,
                    CNPJ = txtCnpj.Text,
                    Endereco = txtEndereco.Text,
                    Cidade = txtCidade.Text,
                    UF = cbEstados.SelectedItem?.ToString(),
                    DataInauguracao = dataInauguracaoPicker.Value
                };

                await _escolaService.AdicionarEscola(escola);

                MessageBox.Show("Escola cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar escola: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
