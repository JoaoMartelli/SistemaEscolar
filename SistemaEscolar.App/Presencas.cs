// SistemaEscolar.App/Presencas.cs
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using SistemaEscolar.Core.Repositorys;
using SistemaEscolar.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Presencas : Form
    {
        private readonly ICursoService _cursoService;
        private readonly IAlunoService _alunoService;
        private readonly IPresencaService _presencaService;

        private BindingList<AlunoPresencaVM> _bindLista; // fonte do grid

        public Presencas()
        {
            InitializeComponent();

            // Repositórios concretos (ajuste para suas classes reais)
            var cursoRepository = new CursoRepository();
            _cursoService = new CursoService(cursoRepository);

            var alunoRepository = new AlunoRepository();      // <-- implemente o contrato
            _alunoService = new AlunoService(alunoRepository);

            var presencaRepository = new PresencaRepository(); // <-- implemente o contrato
            _presencaService = new PresencaService(presencaRepository);

            dataGridView1.AutoGenerateColumns = false;
            ConfigurarGrid();

            this.Load += Presencas_Load;
            button1.Click += ButtonCarregarAlunos_Click; // CARREGAR ALUNOS
            button2.Click += ButtonSalvar_Click;         // SALVAR
        }

        #region UI/Grid
        private void ConfigurarGrid()
        {
            // Garante colunas ocultas para IDs
            if (!dataGridView1.Columns.Contains("AlunoId"))
                dataGridView1.Columns.Insert(0, new DataGridViewTextBoxColumn { Name = "AlunoId", Visible = false });

            if (!dataGridView1.Columns.Contains("PresencaId"))
                dataGridView1.Columns.Insert(1, new DataGridViewTextBoxColumn { Name = "PresencaId", Visible = false });

            // Ajusta colunas existentes do designer
            dataGridView1.Columns["Nome"].ReadOnly = true;
            dataGridView1.Columns["Nome"].Width = 300;

            var colPresente = dataGridView1.Columns["Presente"] as DataGridViewCheckBoxColumn;
            if (colPresente != null)
            {
                colPresente.TrueValue = true;
                colPresente.FalseValue = false;
                colPresente.ThreeState = false;
            }

            dataGridView1.Columns["Justificativa"].Width = 500;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        #region Load inicial
        private async void Presencas_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Value = DateTime.Today;

                var cursos = (await _cursoService.GetCursosAsync())
                    .Where(c => c.Ativo)
                    .OrderBy(c => c.Nome)
                    .ToList();

                comboBox1.DataSource = cursos;
                comboBox1.DisplayMember = "Nome";
                comboBox1.ValueMember = "CursoId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cursos: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Carregar alunos + presenças
        private async void ButtonCarregarAlunos_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Selecione um curso.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int cursoId = (int)comboBox1.SelectedValue;
            var data = dateTimePicker1.Value.Date;

            try
            {
                var alunos = (await _alunoService.GetMatriculadosPorCursoAsync(cursoId))
                    .Where(a => a.Ativo)
                    .OrderBy(a => a.NomeCompleto)
                    .Select(a => new Aluno // Conversão explícita para o tipo correto
                    {
                        AlunoId = a.AlunoId,
                        NomeCompleto = a.NomeCompleto,
                        Ativo = a.Ativo
                    })
                    .ToList();

                var presencas = (await _presencaService.GetByCursoDataAsync(cursoId, data))
                    .ToList();

                // Merge para VM do grid
                var vms = MergeAlunosComPresencas(alunos, presencas, cursoId, data);
                _bindLista = new BindingList<AlunoPresencaVM>(vms);

                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = _bindLista;

                // Mapear propriedades nos nomes das colunas existentes
                dataGridView1.Columns["AlunoId"].DataPropertyName = nameof(AlunoPresencaVM.AlunoId);
                dataGridView1.Columns["PresencaId"].DataPropertyName = nameof(AlunoPresencaVM.PresencaId);
                dataGridView1.Columns["Nome"].DataPropertyName = nameof(AlunoPresencaVM.Nome);
                dataGridView1.Columns["Presente"].DataPropertyName = nameof(AlunoPresencaVM.Presente);
                dataGridView1.Columns["Justificativa"].DataPropertyName = nameof(AlunoPresencaVM.Justificativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar presenças: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<AlunoPresencaVM> MergeAlunosComPresencas(
            IEnumerable<Aluno> alunos,
            IEnumerable<PresencaDto> presencas,
            int cursoId,
            DateTime data)
        {
            var map = presencas.ToDictionary(
                p => p.AlunoId,
                p => p
            );

            var list = new List<AlunoPresencaVM>();

            foreach (var a in alunos)
            {
                map.TryGetValue(a.AlunoId, out var p);

                list.Add(new AlunoPresencaVM
                {
                    AlunoId = a.AlunoId,
                    PresencaId = p?.PresencaId,
                    Nome = a.NomeCompleto,
                    Presente = p?.StatusPresenca ?? true, // default presente
                    Justificativa = p?.Justificativa ?? string.Empty,
                    Data = data,
                    CursoId = cursoId
                });
            }

            return list;
        }
        #endregion

        #region Salvar
        private async void ButtonSalvar_Click(object sender, EventArgs e)
        {
            if (_bindLista == null || _bindLista.Count == 0)
            {
                MessageBox.Show("Nada para salvar. Carregue os alunos primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Converte VM -> DTO para upsert em lote
                var dtos = _bindLista.Select(vm => new PresencaDto
                {
                    PresencaId = vm.PresencaId,
                    CursoId = vm.CursoId,
                    AlunoId = vm.AlunoId,
                    DataPresenca = vm.Data.Date,
                    StatusPresenca = vm.Presente,
                    Justificativa = string.IsNullOrWhiteSpace(vm.Justificativa) ? null : vm.Justificativa,
                    Ativo = true
                }).ToList();

                await _presencaService.UpsertRangeAsync(dtos);

                MessageBox.Show("Presenças salvas com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarrega para refletir IDs gerados
                ButtonCarregarAlunos_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
