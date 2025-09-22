using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{
    public partial class CadastrarAluno : Form
    {
        public CadastrarAluno()
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

        private void CadastrarAluno_Load(object sender, EventArgs e)
        {

        }
    }
}
