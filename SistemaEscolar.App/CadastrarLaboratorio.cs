using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class CadastrarLaboratorio : Form
    {
        private readonly ILaboratorioService _laboratorioService;
        private readonly IEscolaService _escolaService;

        public CadastrarLaboratorio(
            ILaboratorioService laboratorioService,
            IEscolaService escolaService) // <- injeta a interface pedida
        {
            InitializeComponent();

            _laboratorioService = laboratorioService ?? throw new ArgumentNullException(nameof(laboratorioService));
            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));

            rbAtivo.Checked = true;
            rbInativo.Checked = false;
        }

        private async void CadastrarLaboratorio_Load(object sender, EventArgs e)
        {
            await CarregarEscolasAsync();
        }

        private async Task CarregarEscolasAsync()
        {
            try
            {
                var escolas = (await _escolaService.GetEscolasAsync())?.ToList() ?? new List<Escola>();
                if (escolas.Count == 0)
                {
                    MessageBox.Show(
                        "Não há escolas cadastradas. Cadastre uma escola antes de criar o laboratório.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    cbEscola.DataSource = null;
                    return;
                }

                cbEscola.DisplayMember = nameof(Escola.NomeCompleto);
                cbEscola.ValueMember = nameof(Escola.EscolaId);
                cbEscola.DataSource = escolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar escolas: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtTipo.Text) ||
                    string.IsNullOrWhiteSpace(txtEquipamentos.Text) ||
                    cbEscola.SelectedItem is null)
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCapacidade.Text, out int capacidade))
                {
                    MessageBox.Show("Capacidade deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // pega o ID da escola selecionada (ValueMember = EscolaId)
                if (!(cbEscola.SelectedValue is int escolaId) || escolaId <= 0)
                {
                    MessageBox.Show("Selecione uma escola válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var laboratorio = new Laboratorio
                {
                    Nome = txtNome.Text.Trim(),
                    Capacidade = capacidade,
                    Tipo = txtTipo.Text.Trim(),
                    Equipamentos = txtEquipamentos.Text.Trim(),
                    EscolaId = escolaId,
                    Ativo = rbAtivo.Checked
                };

                await _laboratorioService.AdicionarLaboratorio(laboratorio);

                MessageBox.Show("Laboratório cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar laboratório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

