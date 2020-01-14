namespace DB91
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tvTablasOrigen = new System.Windows.Forms.TreeView();
            this.tvTablasDestino = new System.Windows.Forms.TreeView();
            this.btnAgregarTabla = new System.Windows.Forms.Button();
            this.txtFiltroTablasOrigen = new System.Windows.Forms.TextBox();
            this.txtFiltroTablasDestino = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnQuitarTabla = new System.Windows.Forms.Button();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.TabPanel = new System.Windows.Forms.TabControl();
            this.tabTablas = new System.Windows.Forms.TabPage();
            this.tabStoreds = new System.Windows.Forms.TabPage();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScriptSQL = new System.Windows.Forms.RichTextBox();
            this.txtFiltroStoredOrigen = new System.Windows.Forms.TextBox();
            this.tvStoredOrigen = new System.Windows.Forms.TreeView();
            this.tvStoredDestino = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtFiltroStoredDestino = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvFiltroVistasOrigen = new System.Windows.Forms.TextBox();
            this.tvVistasOrigen = new System.Windows.Forms.TreeView();
            this.tvVistasDestino = new System.Windows.Forms.TreeView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tvFiltroVistasDestino = new System.Windows.Forms.TextBox();
            this.tvFiltroFuncionesOrigen = new System.Windows.Forms.TextBox();
            this.tvFuncionesOrigen = new System.Windows.Forms.TreeView();
            this.tvFuncionesDestino = new System.Windows.Forms.TreeView();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tvFiltroFuncionesDestino = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.TabPanel.SuspendLayout();
            this.tabTablas.SuspendLayout();
            this.tabStoreds.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadena de conexion Origen";
            // 
            // tvTablasOrigen
            // 
            this.tvTablasOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvTablasOrigen.Location = new System.Drawing.Point(6, 29);
            this.tvTablasOrigen.Name = "tvTablasOrigen";
            this.tvTablasOrigen.Size = new System.Drawing.Size(250, 400);
            this.tvTablasOrigen.TabIndex = 1;
            // 
            // tvTablasDestino
            // 
            this.tvTablasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvTablasDestino.Location = new System.Drawing.Point(351, 29);
            this.tvTablasDestino.Name = "tvTablasDestino";
            this.tvTablasDestino.Size = new System.Drawing.Size(250, 400);
            this.tvTablasDestino.TabIndex = 2;
            // 
            // btnAgregarTabla
            // 
            this.btnAgregarTabla.Location = new System.Drawing.Point(270, 29);
            this.btnAgregarTabla.Name = "btnAgregarTabla";
            this.btnAgregarTabla.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTabla.TabIndex = 3;
            this.btnAgregarTabla.Text = "->";
            this.btnAgregarTabla.UseVisualStyleBackColor = true;
            this.btnAgregarTabla.Click += new System.EventHandler(this.btnAgregarTabla_Click);
            // 
            // txtFiltroTablasOrigen
            // 
            this.txtFiltroTablasOrigen.Location = new System.Drawing.Point(6, 3);
            this.txtFiltroTablasOrigen.Name = "txtFiltroTablasOrigen";
            this.txtFiltroTablasOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroTablasOrigen.TabIndex = 4;
            // 
            // txtFiltroTablasDestino
            // 
            this.txtFiltroTablasDestino.Location = new System.Drawing.Point(351, 3);
            this.txtFiltroTablasDestino.Name = "txtFiltroTablasDestino";
            this.txtFiltroTablasDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroTablasDestino.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(633, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generar Script SQL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(759, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Ejecutar Script";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTabla
            // 
            this.btnQuitarTabla.Location = new System.Drawing.Point(270, 58);
            this.btnQuitarTabla.Name = "btnQuitarTabla";
            this.btnQuitarTabla.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarTabla.TabIndex = 9;
            this.btnQuitarTabla.Text = "<-";
            this.btnQuitarTabla.UseVisualStyleBackColor = true;
            this.btnQuitarTabla.Click += new System.EventHandler(this.btnQuitarTabla_Click);
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(154, 6);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(487, 20);
            this.txtConnStr.TabIndex = 10;
            this.txtConnStr.Text = "Server=192.168.0.215;Database=JDE_CRP;User Id=CRPDTA;Password=CRPDTA;";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(647, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 22);
            this.button5.TabIndex = 11;
            this.button5.Text = "Conectar y Buscar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TabPanel
            // 
            this.TabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TabPanel.Controls.Add(this.tabTablas);
            this.TabPanel.Controls.Add(this.tabStoreds);
            this.TabPanel.Controls.Add(this.tabPage1);
            this.TabPanel.Controls.Add(this.tabPage2);
            this.TabPanel.Location = new System.Drawing.Point(12, 55);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 0;
            this.TabPanel.Size = new System.Drawing.Size(615, 461);
            this.TabPanel.TabIndex = 12;
            // 
            // tabTablas
            // 
            this.tabTablas.Controls.Add(this.txtFiltroTablasOrigen);
            this.tabTablas.Controls.Add(this.tvTablasOrigen);
            this.tabTablas.Controls.Add(this.tvTablasDestino);
            this.tabTablas.Controls.Add(this.btnQuitarTabla);
            this.tabTablas.Controls.Add(this.btnAgregarTabla);
            this.tabTablas.Controls.Add(this.txtFiltroTablasDestino);
            this.tabTablas.Location = new System.Drawing.Point(4, 22);
            this.tabTablas.Name = "tabTablas";
            this.tabTablas.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablas.Size = new System.Drawing.Size(607, 435);
            this.tabTablas.TabIndex = 0;
            this.tabTablas.Text = "Tablas";
            this.tabTablas.UseVisualStyleBackColor = true;
            // 
            // tabStoreds
            // 
            this.tabStoreds.Controls.Add(this.txtFiltroStoredOrigen);
            this.tabStoreds.Controls.Add(this.tvStoredOrigen);
            this.tabStoreds.Controls.Add(this.tvStoredDestino);
            this.tabStoreds.Controls.Add(this.button1);
            this.tabStoreds.Controls.Add(this.button4);
            this.tabStoreds.Controls.Add(this.txtFiltroStoredDestino);
            this.tabStoreds.Location = new System.Drawing.Point(4, 22);
            this.tabStoreds.Name = "tabStoreds";
            this.tabStoreds.Padding = new System.Windows.Forms.Padding(3);
            this.tabStoreds.Size = new System.Drawing.Size(607, 357);
            this.tabStoreds.TabIndex = 1;
            this.tabStoreds.Text = "Stored Procedures";
            this.tabStoreds.UseVisualStyleBackColor = true;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(154, 29);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(487, 20);
            this.txtCatalog.TabIndex = 14;
            this.txtCatalog.Text = "JDE_CRP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Catalog";
            // 
            // txtScriptSQL
            // 
            this.txtScriptSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptSQL.Location = new System.Drawing.Point(633, 106);
            this.txtScriptSQL.Name = "txtScriptSQL";
            this.txtScriptSQL.ReadOnly = true;
            this.txtScriptSQL.Size = new System.Drawing.Size(571, 406);
            this.txtScriptSQL.TabIndex = 15;
            this.txtScriptSQL.Text = "";
            this.txtScriptSQL.WordWrap = false;
            // 
            // txtFiltroStoredOrigen
            // 
            this.txtFiltroStoredOrigen.Location = new System.Drawing.Point(6, 4);
            this.txtFiltroStoredOrigen.Name = "txtFiltroStoredOrigen";
            this.txtFiltroStoredOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroStoredOrigen.TabIndex = 13;
            // 
            // tvStoredOrigen
            // 
            this.tvStoredOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStoredOrigen.Location = new System.Drawing.Point(6, 30);
            this.tvStoredOrigen.Name = "tvStoredOrigen";
            this.tvStoredOrigen.Size = new System.Drawing.Size(250, 322);
            this.tvStoredOrigen.TabIndex = 10;
            // 
            // tvStoredDestino
            // 
            this.tvStoredDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStoredDestino.Location = new System.Drawing.Point(351, 30);
            this.tvStoredDestino.Name = "tvStoredDestino";
            this.tvStoredDestino.Size = new System.Drawing.Size(250, 322);
            this.tvStoredDestino.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(270, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "->";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtFiltroStoredDestino
            // 
            this.txtFiltroStoredDestino.Location = new System.Drawing.Point(351, 4);
            this.txtFiltroStoredDestino.Name = "txtFiltroStoredDestino";
            this.txtFiltroStoredDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroStoredDestino.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvFiltroVistasOrigen);
            this.tabPage1.Controls.Add(this.tvVistasOrigen);
            this.tabPage1.Controls.Add(this.tvVistasDestino);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.tvFiltroVistasDestino);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 357);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Vistas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvFiltroFuncionesOrigen);
            this.tabPage2.Controls.Add(this.tvFuncionesOrigen);
            this.tabPage2.Controls.Add(this.tvFuncionesDestino);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.tvFiltroFuncionesDestino);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 357);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Funciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvFiltroVistasOrigen
            // 
            this.tvFiltroVistasOrigen.Location = new System.Drawing.Point(6, 4);
            this.tvFiltroVistasOrigen.Name = "tvFiltroVistasOrigen";
            this.tvFiltroVistasOrigen.Size = new System.Drawing.Size(250, 20);
            this.tvFiltroVistasOrigen.TabIndex = 19;
            // 
            // tvVistasOrigen
            // 
            this.tvVistasOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvVistasOrigen.Location = new System.Drawing.Point(6, 30);
            this.tvVistasOrigen.Name = "tvVistasOrigen";
            this.tvVistasOrigen.Size = new System.Drawing.Size(250, 322);
            this.tvVistasOrigen.TabIndex = 16;
            // 
            // tvVistasDestino
            // 
            this.tvVistasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvVistasDestino.Location = new System.Drawing.Point(351, 30);
            this.tvVistasDestino.Name = "tvVistasDestino";
            this.tvVistasDestino.Size = new System.Drawing.Size(250, 322);
            this.tvVistasDestino.TabIndex = 17;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(270, 59);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "<-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(270, 30);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "->";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tvFiltroVistasDestino
            // 
            this.tvFiltroVistasDestino.Location = new System.Drawing.Point(351, 4);
            this.tvFiltroVistasDestino.Name = "tvFiltroVistasDestino";
            this.tvFiltroVistasDestino.Size = new System.Drawing.Size(250, 20);
            this.tvFiltroVistasDestino.TabIndex = 20;
            // 
            // tvFiltroFuncionesOrigen
            // 
            this.tvFiltroFuncionesOrigen.Location = new System.Drawing.Point(6, 4);
            this.tvFiltroFuncionesOrigen.Name = "tvFiltroFuncionesOrigen";
            this.tvFiltroFuncionesOrigen.Size = new System.Drawing.Size(250, 20);
            this.tvFiltroFuncionesOrigen.TabIndex = 19;
            // 
            // tvFuncionesOrigen
            // 
            this.tvFuncionesOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFuncionesOrigen.Location = new System.Drawing.Point(6, 30);
            this.tvFuncionesOrigen.Name = "tvFuncionesOrigen";
            this.tvFuncionesOrigen.Size = new System.Drawing.Size(250, 322);
            this.tvFuncionesOrigen.TabIndex = 16;
            // 
            // tvFuncionesDestino
            // 
            this.tvFuncionesDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFuncionesDestino.Location = new System.Drawing.Point(351, 30);
            this.tvFuncionesDestino.Name = "tvFuncionesDestino";
            this.tvFuncionesDestino.Size = new System.Drawing.Size(250, 322);
            this.tvFuncionesDestino.TabIndex = 17;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(270, 59);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 21;
            this.button8.Text = "<-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(270, 30);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "->";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // tvFiltroFuncionesDestino
            // 
            this.tvFiltroFuncionesDestino.Location = new System.Drawing.Point(351, 4);
            this.tvFiltroFuncionesDestino.Name = "tvFiltroFuncionesDestino";
            this.tvFiltroFuncionesDestino.Size = new System.Drawing.Size(250, 20);
            this.tvFiltroFuncionesDestino.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(778, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(426, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cadena de conexion Destino";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(647, 29);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(108, 22);
            this.button10.TabIndex = 18;
            this.button10.Text = "Desconectar";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 528);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScriptSQL);
            this.Controls.Add(this.txtCatalog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabPanel.ResumeLayout(false);
            this.tabTablas.ResumeLayout(false);
            this.tabTablas.PerformLayout();
            this.tabStoreds.ResumeLayout(false);
            this.tabStoreds.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvTablasOrigen;
        private System.Windows.Forms.TreeView tvTablasDestino;
        private System.Windows.Forms.Button btnAgregarTabla;
        private System.Windows.Forms.TextBox txtFiltroTablasOrigen;
        private System.Windows.Forms.TextBox txtFiltroTablasDestino;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnQuitarTabla;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl TabPanel;
        private System.Windows.Forms.TabPage tabTablas;
        private System.Windows.Forms.TabPage tabStoreds;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtScriptSQL;
        private System.Windows.Forms.TextBox txtFiltroStoredOrigen;
        private System.Windows.Forms.TreeView tvStoredOrigen;
        private System.Windows.Forms.TreeView tvStoredDestino;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtFiltroStoredDestino;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tvFiltroVistasOrigen;
        private System.Windows.Forms.TreeView tvVistasOrigen;
        private System.Windows.Forms.TreeView tvVistasDestino;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox tvFiltroVistasDestino;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tvFiltroFuncionesOrigen;
        private System.Windows.Forms.TreeView tvFuncionesOrigen;
        private System.Windows.Forms.TreeView tvFuncionesDestino;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox tvFiltroFuncionesDestino;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button10;
    }
}

