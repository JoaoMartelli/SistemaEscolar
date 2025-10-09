using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class EditarLaboratorio : Form
    {
        private readonly ILaboratorioService _laboratorioService;
        private readonly IEscolaService _escolaService;
        private readonly Laboratorio _laboratorioOriginal;

        public EditarLaboratorio(
            ILaboratorioService laboratorioService,
            IEscolaService escolaService,
            Laboratorio laboratorio)
        {
            InitializeComponent();

            _laboratorioService = laboratorioService ?? throw new ArgumentNullException(nameof(laboratorioService));
            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));
            _laboratorioOriginal = laboratorio ?? throw new ArgumentNullException(nameof(laboratorio));
        }

        private async void EditarLaboratorio_Load(object sender, EventArgs e)
        {
            await CarregarEscolasAsync();
            PreencherCamposComDadosAtuais();
        }

        private async Task CarregarEscolasAsync()
        {
            try
            {
                var escolas = (await _escolaService.GetEscolasAsync())?.ToList() ?? new List<Escola>();
                cbEscola.DisplayMember = nameof(Escola.NomeCompleto);
                cbEscola.ValueMember = nameof(Escola.EscolaId);
                cbEscola.DataSource = escolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar escolas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCamposComDadosAtuais()
        {
            txtNome.Text = _laboratorioOriginal.Nome;
            txtCapacidade.Text = _laboratorioOriginal.Capacidade.ToString();
            txtTipo.Text = _laboratorioOriginal.Tipo;
            txtEquipamentos.Text = _laboratorioOriginal.Equipamentos;

            // Seleciona escola atual
            cbEscola.SelectedValue = _laboratorioOriginal.EscolaId;

            // Situação
            if (_laboratorioOriginal.Ativo)
                rbAtivo.Checked = true;
            else
                rbInativo.Checked = true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtTipo.Text) ||
                    string.IsNullOrWhiteSpace(txtEquipamentos.Text) ||
                    cbEscola.SelectedItem is null)
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCapacidade.Text, out int capacidade))
                {
                    MessageBox.Show("Capacidade deve ser um número válido.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(cbEscola.SelectedValue is int escolaId) || escolaId <= 0)
                {
                    MessageBox.Show("Selecione uma escola válida.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Monta objeto atualizado mantendo o ID
                var atualizado = new Laboratorio
                {
                    LaboratorioId = _laboratorioOriginal.LaboratorioId,
                    Nome = txtNome.Text.Trim(),
                    Capacidade = capacidade,
                    Tipo = txtTipo.Text.Trim(),
                    Equipamentos = txtEquipamentos.Text.Trim(),
                    EscolaId = escolaId,
                    Ativo = rbAtivo.Checked
                };

                // >>> IMPORTANTE: exige que o service tenha o método de update <<<
                await _laboratorioService.AtualizarLaboratorio(atualizado);

                MessageBox.Show("Laboratório atualizado com sucesso!", "Sucesso",
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
