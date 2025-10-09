using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Enum;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class EditarEscola : Form
    {
        private readonly IEscolaService _escolaService;
        private readonly Escola _escolaOriginal;

        public EditarEscola(IEscolaService escolaService, Escola escola)
        {
            InitializeComponent();

            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));
            _escolaOriginal = escola ?? throw new ArgumentNullException(nameof(escola));

            // Popular UF
            cbEstados.Items.Clear();
            cbEstados.Items.AddRange(Enum.GetNames(typeof(EstadosEnum)));

            // Garantir visibilidade dos rádios
            groupBoxAtivo.Visible = true;
            groupBoxAtivo.BringToFront();
        }

        private void EditarEscola_Load(object sender, EventArgs e)
        {
            // Preenche campos com dados atuais
            txtNome.Text = _escolaOriginal.NomeCompleto;
            txtCnpj.Text = _escolaOriginal.CNPJ;
            txtEndereco.Text = _escolaOriginal.Endereco;
            txtCidade.Text = _escolaOriginal.Cidade;

            if (!string.IsNullOrWhiteSpace(_escolaOriginal.UF))
            {
                var idx = cbEstados.Items.IndexOf(_escolaOriginal.UF);
                cbEstados.SelectedIndex = idx >= 0 ? idx : -1;
            }
            else
            {
                cbEstados.SelectedIndex = -1;
            }

            if (_escolaOriginal.DataInauguracao != default)
                dataInauguracaoPicker.Value = _escolaOriginal.DataInauguracao;

            // Ativo/Inativo
            rbAtivo.Checked = _escolaOriginal.Ativo;
            rbInativo.Checked = !_escolaOriginal.Ativo;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações simples (ajuste conforme sua regra)
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Informe o nome da escola.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCnpj.Text))
                {
                    MessageBox.Show("Informe o CNPJ.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var atualizada = new Escola
                {
                    EscolaId = _escolaOriginal.EscolaId, // mantém o ID
                    NomeCompleto = txtNome.Text?.Trim(),
                    CNPJ = txtCnpj.Text?.Trim(),
                    Endereco = txtEndereco.Text?.Trim(),
                    Cidade = txtCidade.Text?.Trim(),
                    UF = cbEstados.SelectedItem?.ToString(),
                    DataInauguracao = dataInauguracaoPicker.Value,
                    Ativo = rbAtivo.Checked
                };

                // Requer que IEscolaService tenha AtualizarEscola
                await _escolaService.AtualizarEscola(atualizada);

                MessageBox.Show("Escola atualizada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar alterações: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
