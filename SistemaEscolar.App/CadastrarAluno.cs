using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Enum;
using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class CadastrarAluno : Form
    {
        private readonly IAlunoService _alunoService;

        public CadastrarAluno(IAlunoService alunoService)
        {
            InitializeComponent();

            _alunoService = alunoService ?? throw new ArgumentNullException(nameof(alunoService));

            cbEstados.Items.AddRange(Enum.GetNames(typeof(EstadosEnum)));
        }

        private void CadastrarAluno_Load(object sender, EventArgs e)
        {

        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var aluno = new Aluno
                {
                    NomeCompleto = txtNome.Text,
                    CPF = txtCpf.Text,
                    Endereco = txtEndereco.Text,
                    Cidade = txtCidade.Text,
                    UF = cbEstados.SelectedItem?.ToString(),
                    DataNascimento = dataNascimentoPicker.Value,
                    Ativo = rbAtivo.Checked
                };

                await _alunoService.AdicionarAluno(aluno);

                MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
