namespace Gerenciador.Kelly.Bolos.Ui
{
    partial class TabelasPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.cbResultado = new System.Windows.Forms.ComboBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjToggleButton1 = new Gerenciador.Kelly.Bolos.Ui.RJToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(182, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(737, 427);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(427, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ultimos Pedidos";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(936, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbFiltro
            // 
            this.cbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(202, 58);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(277, 28);
            this.cbFiltro.TabIndex = 9;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged_1);
            // 
            // cbResultado
            // 
            this.cbResultado.Enabled = false;
            this.cbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResultado.FormattingEnabled = true;
            this.cbResultado.Location = new System.Drawing.Point(510, 57);
            this.cbResultado.Name = "cbResultado";
            this.cbResultado.Size = new System.Drawing.Size(254, 28);
            this.cbResultado.TabIndex = 10;
            this.cbResultado.SelectedIndexChanged += new System.EventHandler(this.cbResultado_SelectedIndexChanged);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.Red;
            this.btnLimpar.Location = new System.Drawing.Point(799, 50);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(104, 31);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.ForeColor = System.Drawing.Color.Red;
            this.btnDeletar.Location = new System.Drawing.Point(799, 17);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(104, 30);
            this.btnDeletar.TabIndex = 12;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Visible = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(156)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.rjToggleButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnTables);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 569);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Gerenciador.Kelly.Bolos.Ui.Properties.Resources.Group_96;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 50);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // rjToggleButton1
            // 
            this.rjToggleButton1.AutoSize = true;
            this.rjToggleButton1.Location = new System.Drawing.Point(12, 274);
            this.rjToggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.rjToggleButton1.Name = "rjToggleButton1";
            this.rjToggleButton1.Size = new System.Drawing.Size(124, 22);
            this.rjToggleButton1.TabIndex = 2;
            this.rjToggleButton1.Text = "rjToggleButton1";
            this.rjToggleButton1.UseVisualStyleBackColor = true;
            this.rjToggleButton1.CheckedChanged += new System.EventHandler(this.rjToggleButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modo Escuro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImage = global::Gerenciador.Kelly.Bolos.Ui.Properties.Resources.Group_95;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Location = new System.Drawing.Point(4, 134);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(139, 61);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "          Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // btnTables
            // 
            this.btnTables.BackgroundImage = global::Gerenciador.Kelly.Bolos.Ui.Properties.Resources.Group_94;
            this.btnTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTables.Location = new System.Drawing.Point(4, 67);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(139, 61);
            this.btnTables.TabIndex = 2;
            this.btnTables.Text = "          Tabelas";
            this.btnTables.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::Gerenciador.Kelly.Bolos.Ui.Properties.Resources.Group_93;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Location = new System.Drawing.Point(3, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(139, 61);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "         Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // TabelasPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(228)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(981, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.cbResultado);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabelasPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TabelasPage";
            this.Load += new System.EventHandler(this.TabelasPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.ComboBox cbResultado;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJToggleButton rjToggleButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnHome;
    }
}