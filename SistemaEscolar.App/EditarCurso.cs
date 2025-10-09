using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class EditarCurso : Form
    {
        private readonly ICursoService _cursoService;
        private readonly IEscolaService _escolaService;
        private readonly Curso _cursoOriginal;

        public EditarCurso(ICursoService cursoService, IEscolaService escolaService, Curso curso)
        {
            InitializeComponent();

            _cursoService = cursoService ?? throw new ArgumentNullException(nameof(cursoService));
            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));
            _cursoOriginal = curso ?? throw new ArgumentNullException(nameof(curso));
        }

        private async void EditarCurso_Load(object sender, EventArgs e)
        {
            await CarregarEscolasAsync();
            PreencherCampos();
        }

        private async Task CarregarEscolasAsync()
        {
            try
            {
                var escolas = (await _escolaService.GetEscolasAsync() ?? Enumerable.Empty<Escola>())
                              .OrderBy(x => x.NomeCompleto)
                              .ToList();

                cbEscolas.DisplayMember = nameof(Escola.NomeCompleto);
                cbEscolas.ValueMember = nameof(Escola.EscolaId);
                cbEscolas.DataSource = escolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar escolas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCampos()
        {
            txtNome.Text = _cursoOriginal.Nome;
            txtInstrutor.Text = _cursoOriginal.Instrutor;
            txtCargaHoraria.Text = _cursoOriginal.CargaHoraria.ToString();

            // Escola atual
            cbEscolas.SelectedValue = _cursoOriginal.EscolaId;

            // Situação
            if (_cursoOriginal.Ativo) rbAtivo.Checked = true; else rbInativo.Checked = true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Informe o nome do curso.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCargaHoraria.Text, out int carga))
                {
                    MessageBox.Show("Carga horária inválida.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(cbEscolas.SelectedValue is int escolaId) || escolaId <= 0)
                {
                    MessageBox.Show("Selecione uma escola válida.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var atualizado = new Curso
                {
                    CursoId = _cursoOriginal.CursoId, // mantém ID!
                    Nome = txtNome.Text.Trim(),
                    Instrutor = txtInstrutor.Text.Trim(),
                    CargaHoraria = carga,
                    EscolaId = escolaId,
                    Ativo = rbAtivo.Checked
                };

                // requer ICursoService.AtualizarCurso
                await _cursoService.AtualizarCurso(atualizado);

                MessageBox.Show("Curso atualizado com sucesso!", "Sucesso",
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
