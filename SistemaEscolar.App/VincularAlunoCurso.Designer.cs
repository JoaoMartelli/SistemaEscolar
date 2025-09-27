namespace SistemaEscolar.App
{
    partial class VincularAlunoCurso
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAluno;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cbAlunos;
        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.Button btnVincular;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtMatricula;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAluno = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.cbAlunos = new System.Windows.Forms.ComboBox();
            this.cbCursos = new System.Windows.Forms.ComboBox();
            this.btnVincular = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.dtMatricula = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblAluno
            // 
            this.lblAluno.AutoSize = true;
            this.lblAluno.Location = new System.Drawing.Point(24, 24);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(40, 13);
            this.lblAluno.TabIndex = 0;
            this.lblAluno.Text = "Aluno:";
            // 
            // cbAlunos
            // 
            this.cbAlunos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlunos.FormattingEnabled = true;
            this.cbAlunos.Location = new System.Drawing.Point(27, 43);
            this.cbAlunos.Name = "cbAlunos";
            this.cbAlunos.Size = new System.Drawing.Size(300, 21);
            this.cbAlunos.TabIndex = 1;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(24, 84);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(40, 13);
            this.lblCurso.TabIndex = 2;
            this.lblCurso.Text = "Curso:";
            // 
            // cbCursos
            // 
            this.cbCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCursos.FormattingEnabled = true;
            this.cbCursos.Location = new System.Drawing.Point(27, 103);
            this.cbCursos.Name = "cbCursos";
            this.cbCursos.Size = new System.Drawing.Size(300, 21);
            this.cbCursos.TabIndex = 3;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(24, 144);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(90, 13);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "Data Matrícula:";
            // 
            // dtMatricula
            // 
            this.dtMatricula.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMatricula.Location = new System.Drawing.Point(27, 163);
            this.dtMatricula.Name = "dtMatricula";
            this.dtMatricula.Size = new System.Drawing.Size(120, 20);
            this.dtMatricula.TabIndex = 5;
            // 
            // btnVincular
            // 
            this.btnVincular.Location = new System.Drawing.Point(27, 205);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(120, 30);
            this.btnVincular.TabIndex = 6;
            this.btnVincular.Text = "Vincular";
            this.btnVincular.UseVisualStyleBackColor = true;
            // 
            // VincularAlunoCurso
            // 
            this.AcceptButton = this.btnVincular;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 260);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.dtMatricula);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cbCursos);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.cbAlunos);
            this.Controls.Add(this.lblAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VincularAlunoCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vincular Aluno ao Curso";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}