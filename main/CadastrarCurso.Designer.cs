namespace main
{
    partial class CadastrarCurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.cbEscolas = new System.Windows.Forms.ComboBox();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBoxAtivo = new System.Windows.Forms.GroupBox();
            this.rbInativo = new System.Windows.Forms.RadioButton();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAlunos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtInstrutor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxAtivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(173, 332);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 27);
            this.label7.TabIndex = 50;
            this.label7.Text = "Escola";
            // 
            // cbEscolas
            // 
            this.cbEscolas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEscolas.FormattingEnabled = true;
            this.cbEscolas.Location = new System.Drawing.Point(179, 362);
            this.cbEscolas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbEscolas.Name = "cbEscolas";
            this.cbEscolas.Size = new System.Drawing.Size(439, 24);
            this.cbEscolas.TabIndex = 49;
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.Location = new System.Drawing.Point(643, 233);
            this.txtCargaHoraria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCargaHoraria.Multiline = true;
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(203, 30);
            this.txtCargaHoraria.TabIndex = 45;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadastrar.Location = new System.Drawing.Point(863, 458);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(220, 78);
            this.btnCadastrar.TabIndex = 44;
            this.btnCadastrar.Text = "Cadastrar Curso";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // groupBoxAtivo
            // 
            this.groupBoxAtivo.Controls.Add(this.rbInativo);
            this.groupBoxAtivo.Controls.Add(this.rbAtivo);
            this.groupBoxAtivo.Location = new System.Drawing.Point(643, 292);
            this.groupBoxAtivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAtivo.Name = "groupBoxAtivo";
            this.groupBoxAtivo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAtivo.Size = new System.Drawing.Size(204, 102);
            this.groupBoxAtivo.TabIndex = 43;
            this.groupBoxAtivo.TabStop = false;
            this.groupBoxAtivo.Text = "Situação";
            // 
            // rbInativo
            // 
            this.rbInativo.AutoSize = true;
            this.rbInativo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInativo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbInativo.Location = new System.Drawing.Point(12, 63);
            this.rbInativo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(104, 31);
            this.rbInativo.TabIndex = 35;
            this.rbInativo.TabStop = true;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;
            // 
            // rbAtivo
            // 
            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAtivo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rbAtivo.Location = new System.Drawing.Point(12, 23);
            this.rbAtivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(87, 31);
            this.rbAtivo.TabIndex = 34;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(649, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 27);
            this.label4.TabIndex = 41;
            this.label4.Text = "Carga Horária";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(179, 233);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(439, 30);
            this.txtNome.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(173, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 27);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(896, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Severinos Sistema Escolar";
            // 
            // lbAlunos
            // 
            this.lbAlunos.AutoSize = true;
            this.lbAlunos.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlunos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbAlunos.Location = new System.Drawing.Point(69, 60);
            this.lbAlunos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlunos.Name = "lbAlunos";
            this.lbAlunos.Size = new System.Drawing.Size(533, 60);
            this.lbAlunos.TabIndex = 34;
            this.lbAlunos.Text = "CADASTRO DE CURSO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::main.Properties.Resources.logo_projeto;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = global::main.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(956, 54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // txtInstrutor
            // 
            this.txtInstrutor.Location = new System.Drawing.Point(179, 297);
            this.txtInstrutor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInstrutor.Multiline = true;
            this.txtInstrutor.Name = "txtInstrutor";
            this.txtInstrutor.Size = new System.Drawing.Size(439, 30);
            this.txtInstrutor.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(173, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 51;
            this.label3.Text = "Instrutor";
            // 
            // CadastrarCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 607);
            this.Controls.Add(this.txtInstrutor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbEscolas);
            this.Controls.Add(this.txtCargaHoraria);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.groupBoxAtivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbAlunos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CadastrarCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastrarCurso";
            this.groupBoxAtivo.ResumeLayout(false);
            this.groupBoxAtivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbEscolas;
        private System.Windows.Forms.TextBox txtCargaHoraria;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.GroupBox groupBoxAtivo;
        private System.Windows.Forms.RadioButton rbInativo;
        private System.Windows.Forms.RadioButton rbAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbAlunos;
        private System.Windows.Forms.TextBox txtInstrutor;
        private System.Windows.Forms.Label label3;
    }
}