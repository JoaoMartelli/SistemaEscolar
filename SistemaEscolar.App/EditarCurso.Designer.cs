using System;
using System.Windows.Forms;

namespace SistemaEscolar.App
{
    partial class EditarCurso
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private Label lbTitulo;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox txtNome;
        private Label label3;
        private TextBox txtInstrutor;
        private Label label4;
        private TextBox txtCargaHoraria;
        private Label label7;
        private ComboBox cbEscolas;
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInstrutor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEscolas = new System.Windows.Forms.ComboBox();
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
            this.ClientSize = new System.Drawing.Size(1148, 607);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EditarCurso";
            this.Name = "EditarCurso";
            this.Load += new System.EventHandler(this.EditarCurso_Load);

            // lbTitulo
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F);
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lbTitulo.Location = new System.Drawing.Point(69, 60);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(468, 48);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "EDIÇÃO DE CURSO";

            // pictureBox1
            this.pictureBox1.BackgroundImage = global::SistemaEscolar.App.Properties.Resources.logo_projeto;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(956, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // label2 - Nome
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.label2.Location = new System.Drawing.Point(173, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.Text = "Nome";
            this.label2.TabIndex = 1;

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(179, 233);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(439, 30);
            this.txtNome.TabIndex = 2;

            // label3 - Instrutor
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.label3.Location = new System.Drawing.Point(173, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.Text = "Instrutor";
            this.label3.TabIndex = 3;

            // txtInstrutor
            this.txtInstrutor.Location = new System.Drawing.Point(179, 297);
            this.txtInstrutor.Multiline = true;
            this.txtInstrutor.Name = "txtInstrutor";
            this.txtInstrutor.Size = new System.Drawing.Size(439, 30);
            this.txtInstrutor.TabIndex = 4;

            // label4 - Carga Horária
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.label4.Location = new System.Drawing.Point(649, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.Text = "Carga Horária";
            this.label4.TabIndex = 5;

            // txtCargaHoraria
            this.txtCargaHoraria.Location = new System.Drawing.Point(643, 233);
            this.txtCargaHoraria.Multiline = true;
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(203, 30);
            this.txtCargaHoraria.TabIndex = 6;

            // label7 - Escola
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.label7.Location = new System.Drawing.Point(173, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 21);
            this.label7.Text = "Escola";
            this.label7.TabIndex = 7;

            // cbEscolas
            this.cbEscolas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbEscolas.Location = new System.Drawing.Point(179, 362);
            this.cbEscolas.Name = "cbEscolas";
            this.cbEscolas.Size = new System.Drawing.Size(439, 24);
            this.cbEscolas.TabIndex = 8;

            // groupBoxAtivo
            this.groupBoxAtivo.Controls.Add(this.rbInativo);
            this.groupBoxAtivo.Controls.Add(this.rbAtivo);
            this.groupBoxAtivo.Location = new System.Drawing.Point(643, 292);
            this.groupBoxAtivo.Name = "groupBoxAtivo";
            this.groupBoxAtivo.Size = new System.Drawing.Size(204, 102);
            this.groupBoxAtivo.TabStop = false;
            this.groupBoxAtivo.Text = "Situação";
            this.groupBoxAtivo.TabIndex = 9;
            this.groupBoxAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // rbAtivo
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

            // rbInativo
            this.rbInativo.AutoSize = true;
            this.rbInativo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbInativo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbInativo.Location = new System.Drawing.Point(12, 63);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(78, 25);
            this.rbInativo.TabIndex = 1;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;

            // btnSalvar
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSalvar.Location = new System.Drawing.Point(863, 458);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(220, 78);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar Alterações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.Location = new System.Drawing.Point(637, 458);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 78);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ORDEM DE ADD: adicione os outros primeiro…
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInstrutor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCargaHoraria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbEscolas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);

            // …e o GroupBox por último (para ficar por cima no z-order)
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
