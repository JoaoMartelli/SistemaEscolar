using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Services;
using SistemaEscolar.Core.Repositorys;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class Cursos : Form
    {
        private readonly ICursoService _cursoService;
        private readonly IEscolaService _escolaService;

        public Cursos()
        {
            InitializeComponent();

            var cursoRepository = new CursoRepository();
            _cursoService = new CursoService(cursoRepository);

            var escolaRepository = new EscolaRepository();
            _escolaService = new EscolaService(escolaRepository);

            CarregarCursosAsync();
        }

        private async void CarregarCursosAsync()
        {
            try
            {
                var cursos = await _cursoService.GetCursosAsync();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cursos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cursos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var c = new CadastrarCurso(_cursoService, _escolaService))
            {
                if (c.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarCursosAsync();
                }
            }
        }
    }
}
