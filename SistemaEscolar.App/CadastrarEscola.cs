using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    public partial class CadastrarEscola : Form
    {
        public CadastrarEscola()
        {
            InitializeComponent();

            string[] estados = new string[]
            {
            "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES",
            "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE",
            "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC",
            "SE", "SP", "TO"
            };

            cbEstados.Items.AddRange(estados);
        }

        private void CadastrarEscola_Load(object sender, EventArgs e)
        {

        }
    }
}
