using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class CadastrarCurso : Form
    {
        private readonly ICursoService _cursoService;
        private readonly IEscolaService _escolaService;

        public CadastrarCurso(ICursoService cursoService, IEscolaService escolaService)
        {
            InitializeComponent();

            _cursoService = cursoService ?? throw new ArgumentNullException(nameof(cursoService));
            _escolaService = escolaService ?? throw new ArgumentNullException(nameof(escolaService));

            this.Load += CadastrarCurso_Load;
            rbAtivo.Checked = true;
            rbInativo.Checked = false;
        }

        private async void CadastrarCurso_Load(object sender, EventArgs e)
        {
            try
            {
                cbEscolas.DropDownStyle = ComboBoxStyle.DropDownList;

                var escolas = (await _escolaService.GetEscolasAsync() ?? Enumerable.Empty<Escola>())
                    .OrderBy(escola => escola.NomeCompleto)
                    .ToList();

                cbEscolas.DisplayMember = nameof(Escola.NomeCompleto);
                cbEscolas.ValueMember = nameof(Escola.EscolaId);
                cbEscolas.DataSource = escolas;

                cbEscolas.SelectedIndex = escolas.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar escolas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int cargaHoraria;
                if (!int.TryParse(txtCargaHoraria.Text, out cargaHoraria))
                {
                    MessageBox.Show("Carga horária inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(cbEscolas.SelectedValue is int escolaId))
                {
                    MessageBox.Show("Selecione uma escola válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var curso = new Curso
                {
                    Nome = txtNome.Text,
                    Instrutor = txtInstrutor.Text,
                    CargaHoraria = cargaHoraria,
                    EscolaId = escolaId,
                    Ativo = rbAtivo.Checked
                };

                await _cursoService.AdicionarCurso(curso);

                MessageBox.Show("Curso cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar curso: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
