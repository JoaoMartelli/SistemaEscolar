namespace SistemaEscolar.App
{
    partial class Laboratorios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLateral = new System.Windows.Forms.Panel();
            this.lbMarca = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iconTopo = new System.Windows.Forms.PictureBox();
            this.panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTopo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLateral.Controls.Add(this.lbMarca);
            this.panelLateral.Controls.Add(this.logo);
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(199, 661);
            this.panelLateral.TabIndex = 0;
            // 
            // lbMarca
            // 
            this.lbMarca.AutoSize = true;
            this.lbMarca.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbMarca.Location = new System.Drawing.Point(22, 103);
            this.lbMarca.Name = "lbMarca";
            this.lbMarca.Size = new System.Drawing.Size(140, 16);
            this.lbMarca.TabIndex = 1;
            this.lbMarca.Text = "Severinos Sistema Escolar";
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::SistemaEscolar.App.Properties.Resources.logo_projeto;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(59, 20);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(80, 80);
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F);
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lbTitulo.Location = new System.Drawing.Point(232, 60);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(267, 48);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Laboratórios";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadastrar.Location = new System.Drawing.Point(930, 146);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(164, 36);
            this.btnCadastrar.TabIndex = 3;
            this.btnCadastrar.Text = "Cadastrar Laboratório";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(236, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(858, 398);
            this.dataGridView1.TabIndex = 4;
            // 
            // iconTopo
            // 
            this.iconTopo.BackgroundImage = global::SistemaEscolar.App.Properties.Resources.Home;
            this.iconTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconTopo.Location = new System.Drawing.Point(1034, 48);
            this.iconTopo.Name = "iconTopo";
            this.iconTopo.Size = new System.Drawing.Size(40, 40);
            this.iconTopo.TabIndex = 5;
            this.iconTopo.TabStop = false;
            // 
            // Laboratorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 649);
            this.Controls.Add(this.iconTopo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.panelLateral);
            this.Name = "Laboratorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratórios";
            this.panelLateral.ResumeLayout(false);
            this.panelLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTopo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Label lbMarca;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox iconTopo;
    }
}
