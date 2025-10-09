using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Enum;
using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class EditarAluno : Form
    {
        private readonly IAlunoService _alunoService;
        private readonly Aluno _alunoOriginal;

        public EditarAluno(IAlunoService alunoService, Aluno aluno)
        {
            InitializeComponent();

            _alunoService = alunoService ?? throw new ArgumentNullException(nameof(alunoService));
            _alunoOriginal = aluno ?? throw new ArgumentNullException(nameof(aluno));
        }

        private void EditarAluno_Load(object sender, EventArgs e)
        {
            cbEstados.Items.Clear();
            cbEstados.Items.AddRange(Enum.GetNames(typeof(EstadosEnum)));

            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = _alunoOriginal.NomeCompleto;
            txtCpf.Text = _alunoOriginal.CPF;
            txtEndereco.Text = _alunoOriginal.Endereco;
            txtCidade.Text = _alunoOriginal.Cidade;

            // UF
            if (!string.IsNullOrWhiteSpace(_alunoOriginal.UF))
            {
                var idx = cbEstados.FindStringExact(_alunoOriginal.UF);
                if (idx >= 0) cbEstados.SelectedIndex = idx;
            }

            // Data de Nascimento
            dataNascimentoPicker.Value = _alunoOriginal.DataNascimento == default
                ? DateTime.Today
                : _alunoOriginal.DataNascimento;

            // Situação
            if (_alunoOriginal.Ativo) rbAtivo.Checked = true; else rbInativo.Checked = true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // validações básicas
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Informe o nome completo.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCpf.Text))
                {
                    MessageBox.Show("Informe o CPF.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbEstados.SelectedItem is null)
                {
                    MessageBox.Show("Selecione a UF.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var atualizado = new Aluno
                {
                    AlunoId = _alunoOriginal.AlunoId, // mantém o ID!
                    NomeCompleto = txtNome.Text.Trim(),
                    CPF = txtCpf.Text.Trim(),
                    Endereco = txtEndereco.Text.Trim(),
                    Cidade = txtCidade.Text.Trim(),
                    UF = cbEstados.SelectedItem.ToString(),
                    DataNascimento = dataNascimentoPicker.Value,
                    Ativo = rbAtivo.Checked
                };

                // exige IAlunoService.AtualizarAluno(Aluno aluno)
                await _alunoService.AtualizarAluno(atualizado);

                MessageBox.Show("Aluno atualizado com sucesso!", "Sucesso",
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
