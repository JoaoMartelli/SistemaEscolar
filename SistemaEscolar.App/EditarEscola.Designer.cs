using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    partial class EditarEscola
    {
        private System.ComponentModel.IContainer components = null;

        private Label lbTitulo;
        private PictureBox pictureBox1;
        private Label labelMarca;

        private Label labelNome;
        private TextBox txtNome;

        private Label labelCnpj;
        private TextBox txtCnpj;

        private Label labelEndereco;
        private TextBox txtEndereco;

        private Label labelCidade;
        private TextBox txtCidade;

        private Label labelUf;
        private ComboBox cbEstados;

        private Label labelData;
        private DateTimePicker dataInauguracaoPicker;

        private GroupBox groupBoxAtivo;
        private RadioButton rbAtivo;
        private RadioButton rbInativo;

        private Button btnSalvar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lbTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMarca = new System.Windows.Forms.Label();

            this.labelNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();

            this.labelCnpj = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.TextBox();

            this.labelEndereco = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();

            this.labelCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();

            this.labelUf = new System.Windows.Forms.Label();
            this.cbEstados = new System.Windows.Forms.ComboBox();

            this.labelData = new System.Windows.Forms.Label();
            this.dataInauguracaoPicker = new System.Windows.Forms.DateTimePicker();

            this.groupBoxAtivo = new System.Windows.Forms.GroupBox();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.rbInativo = new System.Windows.Forms.RadioButton();

            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxAtivo.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 607);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EditarEscola";
            this.Name = "EditarEscola";
            this.Load += new System.EventHandler(this.EditarEscola_Load);

            // Título
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F);
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lbTitulo.Location = new System.Drawing.Point(69, 78);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(438, 48);
            this.lbTitulo.Text = "EDIÇÃO DE ESCOLA";

            // Logo
            this.pictureBox1.BackgroundImage = global::SistemaEscolar.App.Properties.Resources.logo_projeto;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1069, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Marca
            this.labelMarca.AutoSize = true;
            this.labelMarca.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelMarca.Location = new System.Drawing.Point(1009, 117);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(161, 16);
            this.labelMarca.Text = "Severinos Sistema Escolar";

            // Nome
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelNome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelNome.Location = new System.Drawing.Point(141, 199);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(129, 21);
            this.labelNome.Text = "Nome completo";

            this.txtNome.Location = new System.Drawing.Point(147, 229);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(439, 30);

            // CNPJ
            this.labelCnpj.AutoSize = true;
            this.labelCnpj.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelCnpj.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelCnpj.Location = new System.Drawing.Point(617, 199);
            this.labelCnpj.Name = "labelCnpj";
            this.labelCnpj.Size = new System.Drawing.Size(48, 21);
            this.labelCnpj.Text = "CNPJ";

            this.txtCnpj.Location = new System.Drawing.Point(611, 229);
            this.txtCnpj.Multiline = true;
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(252, 30);

            // Endereço
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelEndereco.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEndereco.Location = new System.Drawing.Point(141, 270);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(82, 21);
            this.labelEndereco.Text = "Endereço";

            this.txtEndereco.Location = new System.Drawing.Point(147, 299);
            this.txtEndereco.Multiline = true;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(439, 30);

            // Cidade
            this.labelCidade.AutoSize = true;
            this.labelCidade.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelCidade.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelCidade.Location = new System.Drawing.Point(617, 270);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(63, 21);
            this.labelCidade.Text = "Cidade";

            this.txtCidade.Location = new System.Drawing.Point(611, 299);
            this.txtCidade.Multiline = true;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(252, 30);

            // UF
            this.labelUf.AutoSize = true;
            this.labelUf.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelUf.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelUf.Location = new System.Drawing.Point(141, 353);
            this.labelUf.Name = "labelUf";
            this.labelUf.Size = new System.Drawing.Size(31, 21);
            this.labelUf.Text = "UF";

            this.cbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbEstados.Location = new System.Drawing.Point(141, 383);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(125, 24);

            // Data Inauguração
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelData.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelData.Location = new System.Drawing.Point(289, 353);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(167, 21);
            this.labelData.Text = "Data de inauguração";

            this.dataInauguracaoPicker.Location = new System.Drawing.Point(295, 384);
            this.dataInauguracaoPicker.Name = "dataInauguracaoPicker";
            this.dataInauguracaoPicker.Size = new System.Drawing.Size(252, 22);

            // Situação (GroupBox + rádios)
            this.groupBoxAtivo.Controls.Add(this.rbInativo);
            this.groupBoxAtivo.Controls.Add(this.rbAtivo);
            this.groupBoxAtivo.Location = new System.Drawing.Point(611, 353);
            this.groupBoxAtivo.Name = "groupBoxAtivo";
            this.groupBoxAtivo.Size = new System.Drawing.Size(252, 84);
            this.groupBoxAtivo.TabStop = true;
            this.groupBoxAtivo.Text = "Situação";

            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbAtivo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbAtivo.Location = new System.Drawing.Point(12, 23);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(66, 25);
            this.rbAtivo.TabIndex = 0;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;

            this.rbInativo.AutoSize = true;
            this.rbInativo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbInativo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbInativo.Location = new System.Drawing.Point(12, 48);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(78, 25);
            this.rbInativo.TabIndex = 1;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;

            // Botões
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSalvar.Location = new System.Drawing.Point(976, 478);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(220, 78);
            this.btnSalvar.Text = "Salvar Alterações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.Location = new System.Drawing.Point(750, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 78);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Adiciona controles (groupBoxAtivo por último para ficar acima)
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMarca);

            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.txtNome);

            this.Controls.Add(this.labelCnpj);
            this.Controls.Add(this.txtCnpj);

            this.Controls.Add(this.labelEndereco);
            this.Controls.Add(this.txtEndereco);

            this.Controls.Add(this.labelCidade);
            this.Controls.Add(this.txtCidade);

            this.Controls.Add(this.labelUf);
            this.Controls.Add(this.cbEstados);

            this.Controls.Add(this.labelData);
            this.Controls.Add(this.dataInauguracaoPicker);

            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);

            this.Controls.Add(this.groupBoxAtivo);

            this.groupBoxAtivo.ResumeLayout(false);
            this.groupBoxAtivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
