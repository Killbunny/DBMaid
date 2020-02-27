namespace DBMaid
{
    partial class FrmPincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.tvTablasOrigen = new System.Windows.Forms.TreeView();
            this.tvTablasDestino = new System.Windows.Forms.TreeView();
            this.btnAgregarTabla = new System.Windows.Forms.Button();
            this.txtFiltroTablasOrigen = new System.Windows.Forms.TextBox();
            this.txtFiltroTablasDestino = new System.Windows.Forms.TextBox();
            this.btnGenerarScript = new System.Windows.Forms.Button();
            this.btnEjecutarScript = new System.Windows.Forms.Button();
            this.btnQuitarTabla = new System.Windows.Forms.Button();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFiltroFuncionesOrigen = new System.Windows.Forms.TextBox();
            this.tvFuncionesOrigen = new System.Windows.Forms.TreeView();
            this.tvFuncionesDestino = new System.Windows.Forms.TreeView();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtFiltroFuncionesDestino = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFiltroVistasOrigen = new System.Windows.Forms.TextBox();
            this.tvVistasOrigen = new System.Windows.Forms.TreeView();
            this.tvVistasDestino = new System.Windows.Forms.TreeView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.txtFiltroVistasDestino = new System.Windows.Forms.TextBox();
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
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.lbHelpBulk = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtConnStr = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarAmbienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarAmbienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoNoEsUnMemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button10 = new System.Windows.Forms.Button();
            this.TabPanel.SuspendLayout();
            this.tabTablas.SuspendLayout();
            this.tabStoreds.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadena de conexion Origen:";
            // 
            // tvTablasOrigen
            // 
            this.tvTablasOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvTablasOrigen.CheckBoxes = true;
            this.tvTablasOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvTablasOrigen.Name = "tvTablasOrigen";
            this.tvTablasOrigen.Size = new System.Drawing.Size(250, 365);
            this.tvTablasOrigen.TabIndex = 1;
            this.tvTablasOrigen.Click += new System.EventHandler(this.tvTablasOrigen_Click);
            this.tvTablasOrigen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvTablasOrigen_MouseDoubleClick);
            // 
            // tvTablasDestino
            // 
            this.tvTablasDestino.AllowDrop = true;
            this.tvTablasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvTablasDestino.Location = new System.Drawing.Point(351, 32);
            this.tvTablasDestino.Name = "tvTablasDestino";
            this.tvTablasDestino.Size = new System.Drawing.Size(250, 365);
            this.tvTablasDestino.TabIndex = 2;
            this.tvTablasDestino.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvTablasDestino_ItemDrag);
            this.tvTablasDestino.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvTablasDestino_DragDrop);
            this.tvTablasDestino.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvTablasDestino_DragEnter);
            this.tvTablasDestino.DragOver += new System.Windows.Forms.DragEventHandler(this.tvTablasDestino_DragOver);
            this.tvTablasDestino.DoubleClick += new System.EventHandler(this.tvTablasDestino_DoubleClick);
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
            this.btnGenerarScript.Location = new System.Drawing.Point(338, 13);
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
            this.btnEjecutarScript.Location = new System.Drawing.Point(338, 42);
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
            // btnConectarYBuscar
            // 
            this.btnConectarYBuscar.Location = new System.Drawing.Point(633, 27);
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
            this.TabPanel.Controls.Add(this.tabPage2);
            this.TabPanel.Controls.Add(this.tabPage1);
            this.TabPanel.Location = new System.Drawing.Point(12, 90);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 0;
            this.TabPanel.Size = new System.Drawing.Size(615, 426);
            this.TabPanel.TabIndex = 2;
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
            this.tabTablas.Size = new System.Drawing.Size(607, 400);
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
            this.tabStoreds.Size = new System.Drawing.Size(607, 413);
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
            this.tvStoredOrigen.CheckBoxes = true;
            this.tvStoredOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvStoredOrigen.Name = "tvStoredOrigen";
            this.tvStoredOrigen.Size = new System.Drawing.Size(250, 378);
            this.tvStoredOrigen.TabIndex = 10;
            this.tvStoredOrigen.DoubleClick += new System.EventHandler(this.tvStoredOrigen_DoubleClick);
            // 
            // tvStoredDestino
            // 
            this.tvStoredDestino.AllowDrop = true;
            this.tvStoredDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvStoredDestino.Location = new System.Drawing.Point(351, 32);
            this.tvStoredDestino.Name = "tvStoredDestino";
            this.tvStoredDestino.Size = new System.Drawing.Size(250, 378);
            this.tvStoredDestino.TabIndex = 11;
            this.tvStoredDestino.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvStoredDestino_ItemDrag);
            this.tvStoredDestino.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvStoredDestino_DragDrop);
            this.tvStoredDestino.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvStoredDestino_DragEnter);
            this.tvStoredDestino.DragOver += new System.Windows.Forms.DragEventHandler(this.tvStoredDestino_DragOver);
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
            this.tabPage2.Size = new System.Drawing.Size(607, 413);
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
            this.tvFuncionesOrigen.CheckBoxes = true;
            this.tvFuncionesOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvFuncionesOrigen.Name = "tvFuncionesOrigen";
            this.tvFuncionesOrigen.Size = new System.Drawing.Size(250, 378);
            this.tvFuncionesOrigen.TabIndex = 16;
            this.tvFuncionesOrigen.DoubleClick += new System.EventHandler(this.tvFuncionesOrigen_DoubleClick);
            // 
            // tvFuncionesDestino
            // 
            this.tvFuncionesDestino.AllowDrop = true;
            this.tvFuncionesDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFuncionesDestino.Location = new System.Drawing.Point(351, 32);
            this.tvFuncionesDestino.Name = "tvFuncionesDestino";
            this.tvFuncionesDestino.Size = new System.Drawing.Size(250, 378);
            this.tvFuncionesDestino.TabIndex = 17;
            this.tvFuncionesDestino.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvFuncionesDestino_ItemDrag);
            this.tvFuncionesDestino.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvFuncionesDestino_DragDrop);
            this.tvFuncionesDestino.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvFuncionesDestino_DragEnter);
            this.tvFuncionesDestino.DragOver += new System.Windows.Forms.DragEventHandler(this.tvFuncionesDestino_DragOver);
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
            this.tabPage1.Size = new System.Drawing.Size(607, 413);
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
            this.tvVistasOrigen.CheckBoxes = true;
            this.tvVistasOrigen.Location = new System.Drawing.Point(6, 32);
            this.tvVistasOrigen.Name = "tvVistasOrigen";
            this.tvVistasOrigen.Size = new System.Drawing.Size(250, 378);
            this.tvVistasOrigen.TabIndex = 16;
            this.tvVistasOrigen.DoubleClick += new System.EventHandler(this.tvVistasOrigen_DoubleClick);
            // 
            // tvVistasDestino
            // 
            this.tvVistasDestino.AllowDrop = true;
            this.tvVistasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvVistasDestino.Location = new System.Drawing.Point(351, 32);
            this.tvVistasDestino.Name = "tvVistasDestino";
            this.tvVistasDestino.Size = new System.Drawing.Size(250, 378);
            this.tvVistasDestino.TabIndex = 17;
            this.tvVistasDestino.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvVistasDestino_ItemDrag);
            this.tvVistasDestino.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvVistasDestino_DragDrop);
            this.tvVistasDestino.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvVistasDestino_DragEnter);
            this.tvVistasDestino.DragOver += new System.Windows.Forms.DragEventHandler(this.tvVistasDestino_DragOver);
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
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(158, 52);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.ReadOnly = true;
            this.txtCatalog.Size = new System.Drawing.Size(470, 20);
            this.txtCatalog.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Catalog:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtScriptSQL
            // 
            this.txtScriptSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptSQL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptSQL.Location = new System.Drawing.Point(6, 30);
            this.txtScriptSQL.Name = "txtScriptSQL";
            this.txtScriptSQL.ReadOnly = true;
            this.txtScriptSQL.Size = new System.Drawing.Size(427, 375);
            this.txtScriptSQL.TabIndex = 15;
            this.txtScriptSQL.Text = "";
            this.txtScriptSQL.WordWrap = false;
            this.txtScriptSQL.TextChanged += new System.EventHandler(this.txtScriptSQL_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "DB Local Destino";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(634, 52);
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
            this.btnGuardarScript.Location = new System.Drawing.Point(339, 100);
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
            this.cbDBsLocales.Location = new System.Drawing.Point(103, 10);
            this.cbDBsLocales.Name = "cbDBsLocales";
            this.cbDBsLocales.Size = new System.Drawing.Size(216, 21);
            this.cbDBsLocales.TabIndex = 1;
            // 
            // btnBulkCopy
            // 
            this.btnBulkCopy.Enabled = false;
            this.btnBulkCopy.Location = new System.Drawing.Point(338, 71);
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
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 0;
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
            this.tabControl1.Location = new System.Drawing.Point(633, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 436);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.txtOutput);
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
            this.tabPage3.Size = new System.Drawing.Size(439, 410);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tareas";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(13, 159);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(420, 248);
            this.txtOutput.TabIndex = 27;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(211, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 23);
            this.button5.TabIndex = 3;
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
            this.button3.Location = new System.Drawing.Point(211, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 2;
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
            this.tabPage4.Size = new System.Drawing.Size(439, 411);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Script SQL";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtConnStr
            // 
            this.txtConnStr.FormattingEnabled = true;
            this.txtConnStr.Location = new System.Drawing.Point(158, 28);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(470, 21);
            this.txtConnStr.TabIndex = 26;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarAmbienteToolStripMenuItem,
            this.cargarAmbienteToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarAmbienteToolStripMenuItem
            // 
            this.guardarAmbienteToolStripMenuItem.Name = "guardarAmbienteToolStripMenuItem";
            this.guardarAmbienteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.guardarAmbienteToolStripMenuItem.Text = "Guardar ambiente";
            this.guardarAmbienteToolStripMenuItem.Click += new System.EventHandler(this.guardarAmbienteToolStripMenuItem_Click);
            // 
            // cargarAmbienteToolStripMenuItem
            // 
            this.cargarAmbienteToolStripMenuItem.Name = "cargarAmbienteToolStripMenuItem";
            this.cargarAmbienteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cargarAmbienteToolStripMenuItem.Text = "Cargar ambiente";
            this.cargarAmbienteToolStripMenuItem.Click += new System.EventHandler(this.cargarAmbienteToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estoNoEsUnMemeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // estoNoEsUnMemeToolStripMenuItem
            // 
            this.estoNoEsUnMemeToolStripMenuItem.Name = "estoNoEsUnMemeToolStripMenuItem";
            this.estoNoEsUnMemeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.estoNoEsUnMemeToolStripMenuItem.Text = "Esto no es un meme";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(747, 27);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(108, 22);
            this.button10.TabIndex = 28;
            this.button10.Text = "Conectar y Buscar";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_2);
            // 
            // FrmPincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 528);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.txtCatalog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.btnConectarYBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPincipal";
            this.Text = "Probar conexión";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabPanel.ResumeLayout(false);
            this.tabTablas.ResumeLayout(false);
            this.tabTablas.PerformLayout();
            this.tabStoreds.ResumeLayout(false);
            this.tabStoreds.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ComboBox txtConnStr;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarAmbienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarAmbienteToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ToolStripMenuItem estoNoEsUnMemeToolStripMenuItem;
        private System.Windows.Forms.Button button10;
    }
}

