using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class VincularAlunoCurso : Form
    {
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;
        private readonly IAlunoCursoService _alunoCursoService;

        public VincularAlunoCurso()
        {
            InitializeComponent();

            var alunoRepository = new AlunoRepository();
            _alunoService = new AlunoService(alunoRepository);

            var cursoRepository = new CursoRepository();
            _cursoService = new CursoService(cursoRepository);

            var alunoCursoRepository = new AlunoCursoRepository();
            _alunoCursoService = new AlunoCursoService(alunoCursoRepository);

            this.Load += VincularAlunoCurso_Load;
            btnVincular.Click += btnVincular_Click;
        }

        private async void VincularAlunoCurso_Load(object sender, EventArgs e)
        {
            await CarregarCombosAsync();
        }

        private async Task CarregarCombosAsync()
        {
            try
            {
                cbAlunos.DropDownStyle = ComboBoxStyle.DropDownList;
                cbCursos.DropDownStyle = ComboBoxStyle.DropDownList;

                var alunos = (await _alunoService.GetAlunosAsync() ?? Enumerable.Empty<Aluno>())
                    .OrderBy(a => a.NomeCompleto)
                    .ToList();
                cbAlunos.DisplayMember = nameof(Aluno.NomeCompleto);
                cbAlunos.ValueMember = nameof(Aluno.AlunoId);
                cbAlunos.DataSource = alunos;
                cbAlunos.SelectedIndex = alunos.Count > 0 ? 0 : -1;

                var cursos = (await _cursoService.GetCursosAsync() ?? Enumerable.Empty<Curso>())
                    .OrderBy(c => c.Nome)
                    .ToList();
                cbCursos.DisplayMember = nameof(Curso.Nome);
                cbCursos.ValueMember = nameof(Curso.CursoId);
                cbCursos.DataSource = cursos;
                cbCursos.SelectedIndex = cursos.Count > 0 ? 0 : -1;

                dtMatricula.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnVincular_Click(object sender, EventArgs e)
        {
            try
            {
                btnVincular.Enabled = false;

                if (!(cbAlunos.SelectedValue is int alunoId))
                {
                    MessageBox.Show("Selecione um aluno válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!(cbCursos.SelectedValue is int cursoId))
                {
                    MessageBox.Show("Selecione um curso válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var vinculo = new AlunoCurso
                {
                    AlunoId = alunoId,
                    CursoId = cursoId,
                    DataMatricula = dtMatricula.Value.Date
                };

                await _alunoCursoService.AdicionarAlunoCurso(vinculo);

                MessageBox.Show("Aluno vinculado ao curso com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao vincular aluno e curso: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnVincular.Enabled = true;
            }
        }
    }
}
