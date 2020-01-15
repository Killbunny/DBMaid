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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tvTablasOrigen = new System.Windows.Forms.TreeView();
            this.tvTablasDestino = new System.Windows.Forms.TreeView();
            this.btnAgregarTabla = new System.Windows.Forms.Button();
            this.txtFiltroTablasOrigen = new System.Windows.Forms.TextBox();
            this.txtFiltroTablasDestino = new System.Windows.Forms.TextBox();
            this.btnGenerarScript = new System.Windows.Forms.Button();
            this.btnEjecutarScript = new System.Windows.Forms.Button();
            this.btnQuitarTabla = new System.Windows.Forms.Button();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.btnConectarYBuscar = new System.Windows.Forms.Button();
            this.TabPanel = new System.Windows.Forms.TabControl();
            this.tabTablas = new System.Windows.Forms.TabPage();
            this.tabStoreds = new System.Windows.Forms.TabPage();
            this.txtFiltroStoredOrigen = new System.Windows.Forms.TextBox();
            this.tvStoredOrigen = new System.Windows.Forms.TreeView();
            this.tvStoredDestino = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtFiltroStoredDestino = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFiltroVistasOrigen = new System.Windows.Forms.TextBox();
            this.tvVistasOrigen = new System.Windows.Forms.TreeView();
            this.tvVistasDestino = new System.Windows.Forms.TreeView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.txtFiltroVistasDestino = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFiltroFuncionesOrigen = new System.Windows.Forms.TextBox();
            this.tvFuncionesOrigen = new System.Windows.Forms.TreeView();
            this.tvFuncionesDestino = new System.Windows.Forms.TreeView();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtFiltroFuncionesDestino = new System.Windows.Forms.TextBox();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScriptSQL = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.btnGuardarScript = new System.Windows.Forms.Button();
            this.cbDBsLocales = new System.Windows.Forms.ComboBox();
            this.btnBulkCopy = new System.Windows.Forms.Button();
            this.ckMostrar = new System.Windows.Forms.CheckBox();
            this.ckGuardar = new System.Windows.Forms.CheckBox();
            this.ckEjecutar = new System.Windows.Forms.CheckBox();
            this.ckBulkCopy = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.lbHelpBulk = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TabPanel.SuspendLayout();
            this.tabTablas.SuspendLayout();
            this.tabStoreds.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.tvTablasOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvTablasOrigen.Name = "tvTablasOrigen";
            this.tvTablasOrigen.Size = new System.Drawing.Size(250, 400);
            this.tvTablasOrigen.TabIndex = 1;
            // 
            // tvTablasDestino
            // 
            this.tvTablasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvTablasDestino.Location = new System.Drawing.Point(351, 32);
            this.tvTablasDestino.Name = "tvTablasDestino";
            this.tvTablasDestino.Size = new System.Drawing.Size(250, 400);
            this.tvTablasDestino.TabIndex = 2;
            // 
            // btnAgregarTabla
            // 
            this.btnAgregarTabla.Location = new System.Drawing.Point(270, 32);
            this.btnAgregarTabla.Name = "btnAgregarTabla";
            this.btnAgregarTabla.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTabla.TabIndex = 3;
            this.btnAgregarTabla.Text = "->";
            this.btnAgregarTabla.UseVisualStyleBackColor = true;
            this.btnAgregarTabla.Click += new System.EventHandler(this.btnAgregarTabla_Click);
            // 
            // txtFiltroTablasOrigen
            // 
            this.txtFiltroTablasOrigen.Location = new System.Drawing.Point(6, 6);
            this.txtFiltroTablasOrigen.Name = "txtFiltroTablasOrigen";
            this.txtFiltroTablasOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroTablasOrigen.TabIndex = 4;
            this.txtFiltroTablasOrigen.TextChanged += new System.EventHandler(this.txtFiltroTablasOrigen_TextChanged);
            // 
            // txtFiltroTablasDestino
            // 
            this.txtFiltroTablasDestino.Location = new System.Drawing.Point(351, 6);
            this.txtFiltroTablasDestino.Name = "txtFiltroTablasDestino";
            this.txtFiltroTablasDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroTablasDestino.TabIndex = 5;
            this.txtFiltroTablasDestino.TextChanged += new System.EventHandler(this.txtFiltroTablasDestino_TextChanged);
            // 
            // btnGenerarScript
            // 
            this.btnGenerarScript.Location = new System.Drawing.Point(27, 167);
            this.btnGenerarScript.Name = "btnGenerarScript";
            this.btnGenerarScript.Size = new System.Drawing.Size(59, 23);
            this.btnGenerarScript.TabIndex = 7;
            this.btnGenerarScript.Text = "Generar";
            this.btnGenerarScript.UseVisualStyleBackColor = true;
            this.btnGenerarScript.Visible = false;
            this.btnGenerarScript.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEjecutarScript
            // 
            this.btnEjecutarScript.Enabled = false;
            this.btnEjecutarScript.Location = new System.Drawing.Point(92, 167);
            this.btnEjecutarScript.Name = "btnEjecutarScript";
            this.btnEjecutarScript.Size = new System.Drawing.Size(66, 23);
            this.btnEjecutarScript.TabIndex = 8;
            this.btnEjecutarScript.Text = "Ejecutar";
            this.btnEjecutarScript.UseVisualStyleBackColor = true;
            this.btnEjecutarScript.Visible = false;
            this.btnEjecutarScript.Click += new System.EventHandler(this.btnEjecutarScript_Click);
            // 
            // btnQuitarTabla
            // 
            this.btnQuitarTabla.Location = new System.Drawing.Point(270, 61);
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
            // btnConectarYBuscar
            // 
            this.btnConectarYBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnConectarYBuscar.Name = "btnConectarYBuscar";
            this.btnConectarYBuscar.Size = new System.Drawing.Size(108, 22);
            this.btnConectarYBuscar.TabIndex = 11;
            this.btnConectarYBuscar.Text = "Conectar y Buscar";
            this.btnConectarYBuscar.UseVisualStyleBackColor = true;
            this.btnConectarYBuscar.Click += new System.EventHandler(this.button5_Click);
            // 
            // TabPanel
            // 
            this.TabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TabPanel.Controls.Add(this.tabTablas);
            this.TabPanel.Controls.Add(this.tabStoreds);
            this.TabPanel.Controls.Add(this.tabPage1);
            this.TabPanel.Controls.Add(this.tabPage2);
            this.TabPanel.Location = new System.Drawing.Point(12, 58);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 0;
            this.TabPanel.Size = new System.Drawing.Size(615, 461);
            this.TabPanel.TabIndex = 12;
            // 
            // tabTablas
            // 
            this.tabTablas.BackColor = System.Drawing.SystemColors.Control;
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
            // 
            // tabStoreds
            // 
            this.tabStoreds.BackColor = System.Drawing.SystemColors.Control;
            this.tabStoreds.Controls.Add(this.txtFiltroStoredOrigen);
            this.tabStoreds.Controls.Add(this.tvStoredOrigen);
            this.tabStoreds.Controls.Add(this.tvStoredDestino);
            this.tabStoreds.Controls.Add(this.button1);
            this.tabStoreds.Controls.Add(this.button4);
            this.tabStoreds.Controls.Add(this.txtFiltroStoredDestino);
            this.tabStoreds.Location = new System.Drawing.Point(4, 22);
            this.tabStoreds.Name = "tabStoreds";
            this.tabStoreds.Padding = new System.Windows.Forms.Padding(3);
            this.tabStoreds.Size = new System.Drawing.Size(607, 435);
            this.tabStoreds.TabIndex = 1;
            this.tabStoreds.Text = "Stored Procedures";
            // 
            // txtFiltroStoredOrigen
            // 
            this.txtFiltroStoredOrigen.Location = new System.Drawing.Point(6, 6);
            this.txtFiltroStoredOrigen.Name = "txtFiltroStoredOrigen";
            this.txtFiltroStoredOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroStoredOrigen.TabIndex = 13;
            this.txtFiltroStoredOrigen.TextChanged += new System.EventHandler(this.txtFiltroStoredOrigen_TextChanged);
            // 
            // tvStoredOrigen
            // 
            this.tvStoredOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStoredOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvStoredOrigen.Name = "tvStoredOrigen";
            this.tvStoredOrigen.Size = new System.Drawing.Size(250, 400);
            this.tvStoredOrigen.TabIndex = 10;
            // 
            // tvStoredDestino
            // 
            this.tvStoredDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStoredDestino.Location = new System.Drawing.Point(351, 32);
            this.tvStoredDestino.Name = "tvStoredDestino";
            this.tvStoredDestino.Size = new System.Drawing.Size(250, 400);
            this.tvStoredDestino.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(270, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "->";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtFiltroStoredDestino
            // 
            this.txtFiltroStoredDestino.Location = new System.Drawing.Point(351, 6);
            this.txtFiltroStoredDestino.Name = "txtFiltroStoredDestino";
            this.txtFiltroStoredDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroStoredDestino.TabIndex = 14;
            this.txtFiltroStoredDestino.TextChanged += new System.EventHandler(this.txtFiltroStoredDestino_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtFiltroVistasOrigen);
            this.tabPage1.Controls.Add(this.tvVistasOrigen);
            this.tabPage1.Controls.Add(this.tvVistasDestino);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.txtFiltroVistasDestino);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 435);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Vistas";
            // 
            // txtFiltroVistasOrigen
            // 
            this.txtFiltroVistasOrigen.Location = new System.Drawing.Point(6, 6);
            this.txtFiltroVistasOrigen.Name = "txtFiltroVistasOrigen";
            this.txtFiltroVistasOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroVistasOrigen.TabIndex = 19;
            this.txtFiltroVistasOrigen.TextChanged += new System.EventHandler(this.tvFiltroVistasOrigen_TextChanged);
            // 
            // tvVistasOrigen
            // 
            this.tvVistasOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvVistasOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvVistasOrigen.Name = "tvVistasOrigen";
            this.tvVistasOrigen.Size = new System.Drawing.Size(250, 400);
            this.tvVistasOrigen.TabIndex = 16;
            // 
            // tvVistasDestino
            // 
            this.tvVistasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvVistasDestino.Location = new System.Drawing.Point(351, 32);
            this.tvVistasDestino.Name = "tvVistasDestino";
            this.tvVistasDestino.Size = new System.Drawing.Size(250, 400);
            this.tvVistasDestino.TabIndex = 17;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(270, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "<-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(270, 32);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "->";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtFiltroVistasDestino
            // 
            this.txtFiltroVistasDestino.Location = new System.Drawing.Point(351, 6);
            this.txtFiltroVistasDestino.Name = "txtFiltroVistasDestino";
            this.txtFiltroVistasDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroVistasDestino.TabIndex = 20;
            this.txtFiltroVistasDestino.TextChanged += new System.EventHandler(this.tvFiltroVistasDestino_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.txtFiltroFuncionesOrigen);
            this.tabPage2.Controls.Add(this.tvFuncionesOrigen);
            this.tabPage2.Controls.Add(this.tvFuncionesDestino);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.txtFiltroFuncionesDestino);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 435);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Funciones";
            // 
            // txtFiltroFuncionesOrigen
            // 
            this.txtFiltroFuncionesOrigen.Location = new System.Drawing.Point(6, 6);
            this.txtFiltroFuncionesOrigen.Name = "txtFiltroFuncionesOrigen";
            this.txtFiltroFuncionesOrigen.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroFuncionesOrigen.TabIndex = 19;
            this.txtFiltroFuncionesOrigen.TextChanged += new System.EventHandler(this.tvFiltroFuncionesOrigen_TextChanged);
            // 
            // tvFuncionesOrigen
            // 
            this.tvFuncionesOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFuncionesOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvFuncionesOrigen.Name = "tvFuncionesOrigen";
            this.tvFuncionesOrigen.Size = new System.Drawing.Size(250, 400);
            this.tvFuncionesOrigen.TabIndex = 16;
            // 
            // tvFuncionesDestino
            // 
            this.tvFuncionesDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFuncionesDestino.Location = new System.Drawing.Point(351, 32);
            this.tvFuncionesDestino.Name = "tvFuncionesDestino";
            this.tvFuncionesDestino.Size = new System.Drawing.Size(250, 400);
            this.tvFuncionesDestino.TabIndex = 17;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(270, 61);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 21;
            this.button8.Text = "<-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(270, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "->";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtFiltroFuncionesDestino
            // 
            this.txtFiltroFuncionesDestino.Location = new System.Drawing.Point(351, 6);
            this.txtFiltroFuncionesDestino.Name = "txtFiltroFuncionesDestino";
            this.txtFiltroFuncionesDestino.Size = new System.Drawing.Size(250, 20);
            this.txtFiltroFuncionesDestino.TabIndex = 20;
            this.txtFiltroFuncionesDestino.TextChanged += new System.EventHandler(this.tvFiltroFuncionesDestino_TextChanged);
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
            this.txtScriptSQL.Location = new System.Drawing.Point(3, 6);
            this.txtScriptSQL.Name = "txtScriptSQL";
            this.txtScriptSQL.ReadOnly = true;
            this.txtScriptSQL.Size = new System.Drawing.Size(564, 430);
            this.txtScriptSQL.TabIndex = 15;
            this.txtScriptSQL.Text = "";
            this.txtScriptSQL.Visible = false;
            this.txtScriptSQL.WordWrap = false;
            this.txtScriptSQL.TextChanged += new System.EventHandler(this.txtScriptSQL_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "DB Local destino";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(647, 29);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(108, 22);
            this.btnDesconectar.TabIndex = 18;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnGuardarScript
            // 
            this.btnGuardarScript.Enabled = false;
            this.btnGuardarScript.Location = new System.Drawing.Point(243, 167);
            this.btnGuardarScript.Name = "btnGuardarScript";
            this.btnGuardarScript.Size = new System.Drawing.Size(65, 23);
            this.btnGuardarScript.TabIndex = 19;
            this.btnGuardarScript.Text = "Guardar";
            this.btnGuardarScript.UseVisualStyleBackColor = true;
            this.btnGuardarScript.Visible = false;
            this.btnGuardarScript.Click += new System.EventHandler(this.button11_Click);
            // 
            // cbDBsLocales
            // 
            this.cbDBsLocales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDBsLocales.FormattingEnabled = true;
            this.cbDBsLocales.Location = new System.Drawing.Point(147, 10);
            this.cbDBsLocales.Name = "cbDBsLocales";
            this.cbDBsLocales.Size = new System.Drawing.Size(216, 21);
            this.cbDBsLocales.TabIndex = 22;
            // 
            // btnBulkCopy
            // 
            this.btnBulkCopy.Enabled = false;
            this.btnBulkCopy.Location = new System.Drawing.Point(164, 167);
            this.btnBulkCopy.Name = "btnBulkCopy";
            this.btnBulkCopy.Size = new System.Drawing.Size(73, 23);
            this.btnBulkCopy.TabIndex = 23;
            this.btnBulkCopy.Text = "Bulk Copy";
            this.btnBulkCopy.UseVisualStyleBackColor = true;
            this.btnBulkCopy.Visible = false;
            this.btnBulkCopy.Click += new System.EventHandler(this.btnBulkCopy_Click);
            // 
            // ckMostrar
            // 
            this.ckMostrar.AutoSize = true;
            this.ckMostrar.Checked = true;
            this.ckMostrar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMostrar.Location = new System.Drawing.Point(10, 67);
            this.ckMostrar.Name = "ckMostrar";
            this.ckMostrar.Size = new System.Drawing.Size(91, 17);
            this.ckMostrar.TabIndex = 0;
            this.ckMostrar.Text = "Mostrar Script";
            this.ckMostrar.UseVisualStyleBackColor = true;
            // 
            // ckGuardar
            // 
            this.ckGuardar.AutoSize = true;
            this.ckGuardar.Location = new System.Drawing.Point(10, 90);
            this.ckGuardar.Name = "ckGuardar";
            this.ckGuardar.Size = new System.Drawing.Size(94, 17);
            this.ckGuardar.TabIndex = 1;
            this.ckGuardar.Text = "Guardar Script";
            this.ckGuardar.UseVisualStyleBackColor = true;
            // 
            // ckEjecutar
            // 
            this.ckEjecutar.AutoSize = true;
            this.ckEjecutar.Checked = true;
            this.ckEjecutar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEjecutar.Location = new System.Drawing.Point(10, 113);
            this.ckEjecutar.Name = "ckEjecutar";
            this.ckEjecutar.Size = new System.Drawing.Size(95, 17);
            this.ckEjecutar.TabIndex = 2;
            this.ckEjecutar.Text = "Ejecutar Script";
            this.ckEjecutar.UseVisualStyleBackColor = true;
            // 
            // ckBulkCopy
            // 
            this.ckBulkCopy.AutoSize = true;
            this.ckBulkCopy.Checked = true;
            this.ckBulkCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBulkCopy.Location = new System.Drawing.Point(10, 136);
            this.ckBulkCopy.Name = "ckBulkCopy";
            this.ckBulkCopy.Size = new System.Drawing.Size(116, 17);
            this.ckBulkCopy.TabIndex = 3;
            this.ckBulkCopy.Text = "Ejecutar Bulk Copy";
            this.ckBulkCopy.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Iniciar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(633, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 461);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.lbHelpBulk);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.btnBulkCopy);
            this.tabPage3.Controls.Add(this.ckBulkCopy);
            this.tabPage3.Controls.Add(this.btnGuardarScript);
            this.tabPage3.Controls.Add(this.cbDBsLocales);
            this.tabPage3.Controls.Add(this.ckMostrar);
            this.tabPage3.Controls.Add(this.ckEjecutar);
            this.tabPage3.Controls.Add(this.ckGuardar);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnGenerarScript);
            this.tabPage3.Controls.Add(this.btnEjecutarScript);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(563, 435);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tareas";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(261, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "Cargar ambiente";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // lbHelpBulk
            // 
            this.lbHelpBulk.AutoSize = true;
            this.lbHelpBulk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHelpBulk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHelpBulk.Location = new System.Drawing.Point(123, 137);
            this.lbHelpBulk.Name = "lbHelpBulk";
            this.lbHelpBulk.Size = new System.Drawing.Size(13, 13);
            this.lbHelpBulk.TabIndex = 26;
            this.lbHelpBulk.Text = "?";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(147, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Guardar ambiente";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.txtScriptSQL);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(563, 435);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Resultado";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 528);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.txtCatalog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.btnConectarYBuscar);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DB Maid";
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnGenerarScript;
        private System.Windows.Forms.Button btnEjecutarScript;
        private System.Windows.Forms.Button btnQuitarTabla;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Button btnConectarYBuscar;
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
        private System.Windows.Forms.TextBox txtFiltroVistasOrigen;
        private System.Windows.Forms.TreeView tvVistasOrigen;
        private System.Windows.Forms.TreeView tvVistasDestino;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtFiltroVistasDestino;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtFiltroFuncionesOrigen;
        private System.Windows.Forms.TreeView tvFuncionesOrigen;
        private System.Windows.Forms.TreeView tvFuncionesDestino;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtFiltroFuncionesDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.Button btnGuardarScript;
        private System.Windows.Forms.ComboBox cbDBsLocales;
        private System.Windows.Forms.Button btnBulkCopy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ckBulkCopy;
        private System.Windows.Forms.CheckBox ckEjecutar;
        private System.Windows.Forms.CheckBox ckGuardar;
        private System.Windows.Forms.CheckBox ckMostrar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lbHelpBulk;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

