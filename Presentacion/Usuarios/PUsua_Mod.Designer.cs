namespace Presentacion.Usuarios
{
    partial class PUsua_Mod
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
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IProv = new System.Windows.Forms.CheckBox();
            this.ILReg = new System.Windows.Forms.CheckBox();
            this.IUsu = new System.Windows.Forms.CheckBox();
            this.IProductos = new System.Windows.Forms.CheckBox();
            this.ILCom = new System.Windows.Forms.CheckBox();
            this.ILPro = new System.Windows.Forms.CheckBox();
            this.ICliente = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AProv = new System.Windows.Forms.CheckBox();
            this.AUsu = new System.Windows.Forms.CheckBox();
            this.AProductos = new System.Windows.Forms.CheckBox();
            this.ALReg = new System.Windows.Forms.CheckBox();
            this.ALPro = new System.Windows.Forms.CheckBox();
            this.ACliente = new System.Windows.Forms.CheckBox();
            this.ALCom = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EUsu = new System.Windows.Forms.CheckBox();
            this.EProductos = new System.Windows.Forms.CheckBox();
            this.EProv = new System.Windows.Forms.CheckBox();
            this.ELReg = new System.Windows.Forms.CheckBox();
            this.ECliente = new System.Windows.Forms.CheckBox();
            this.ELPro = new System.Windows.Forms.CheckBox();
            this.ELCom = new System.Windows.Forms.CheckBox();
            this.ButGua = new System.Windows.Forms.Button();
            this.ButLim = new System.Windows.Forms.Button();
            this.ButVol = new System.Windows.Forms.Button();
            this.ButSal = new System.Windows.Forms.Button();
            this.GrillaUsuarios = new System.Windows.Forms.DataGridView();
            this.Selec = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextIngMod = new System.Windows.Forms.TextBox();
            this.TextPass = new System.Windows.Forms.TextBox();
            this.TextCon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckCon = new System.Windows.Forms.CheckBox();
            this.CheckPass = new System.Windows.Forms.CheckBox();
            this.textIdMod = new System.Windows.Forms.TextBox();
            this.textIdPer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1.
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Permisos";
            // 
            // GroupBox1.
            // 
            this.groupBox1.Controls.Add(this.IProv);
            this.groupBox1.Controls.Add(this.ILReg);
            this.groupBox1.Controls.Add(this.IUsu);
            this.groupBox1.Controls.Add(this.IProductos);
            this.groupBox1.Controls.Add(this.ILCom);
            this.groupBox1.Controls.Add(this.ILPro);
            this.groupBox1.Controls.Add(this.ICliente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(162, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 237);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INGRESAR";
            // 
            // IProv.
            // 
            this.IProv.AutoSize = true;
            this.IProv.Location = new System.Drawing.Point(6, 151);
            this.IProv.Name = "IProv";
            this.IProv.Size = new System.Drawing.Size(109, 24);
            this.IProv.TabIndex = 32;
            this.IProv.Text = "Proveedor";
            this.IProv.UseVisualStyleBackColor = true;
            // 
            // ILReg.
            // 
            this.ILReg.AutoSize = true;
            this.ILReg.Location = new System.Drawing.Point(6, 88);
            this.ILReg.Name = "ILReg";
            this.ILReg.Size = new System.Drawing.Size(85, 24);
            this.ILReg.TabIndex = 27;
            this.ILReg.Text = "Region";
            this.ILReg.UseVisualStyleBackColor = true;
            // 
            // IUsu.
            // 
            this.IUsu.AutoSize = true;
            this.IUsu.Location = new System.Drawing.Point(6, 211);
            this.IUsu.Name = "IUsu";
            this.IUsu.Size = new System.Drawing.Size(99, 24);
            this.IUsu.TabIndex = 32;
            this.IUsu.Text = "Usuarios";
            this.IUsu.UseVisualStyleBackColor = true;
            // 
            // IProductos.
            // 
            this.IProductos.AutoSize = true;
            this.IProductos.Location = new System.Drawing.Point(6, 181);
            this.IProductos.Name = "IProductos";
            this.IProductos.Size = new System.Drawing.Size(109, 24);
            this.IProductos.TabIndex = 27;
            this.IProductos.Text = "Productos";
            this.IProductos.UseVisualStyleBackColor = true;
            // 
            // ILCom.
            // 
            this.ILCom.AutoSize = true;
            this.ILCom.Location = new System.Drawing.Point(6, 28);
            this.ILCom.Name = "ILCom";
            this.ILCom.Size = new System.Drawing.Size(94, 24);
            this.ILCom.TabIndex = 25;
            this.ILCom.Text = "Comuna";
            this.ILCom.UseVisualStyleBackColor = true;
            // 
            // ILPro.
            // 
            this.ILPro.AutoSize = true;
            this.ILPro.Location = new System.Drawing.Point(6, 59);
            this.ILPro.Name = "ILPro";
            this.ILPro.Size = new System.Drawing.Size(100, 24);
            this.ILPro.TabIndex = 26;
            this.ILPro.Text = "Provincia";
            this.ILPro.UseVisualStyleBackColor = true;
            // 
            // ICliente.
            // 
            this.ICliente.AutoSize = true;
            this.ICliente.Location = new System.Drawing.Point(6, 121);
            this.ICliente.Name = "ICliente";
            this.ICliente.Size = new System.Drawing.Size(84, 24);
            this.ICliente.TabIndex = 27;
            this.ICliente.Text = "Cliente";
            this.ICliente.UseVisualStyleBackColor = true;
            // 
            // GroupBox2.
            // 
            this.groupBox2.Controls.Add(this.AProv);
            this.groupBox2.Controls.Add(this.AUsu);
            this.groupBox2.Controls.Add(this.AProductos);
            this.groupBox2.Controls.Add(this.ALReg);
            this.groupBox2.Controls.Add(this.ALPro);
            this.groupBox2.Controls.Add(this.ACliente);
            this.groupBox2.Controls.Add(this.ALCom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(338, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 235);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ACTUALIZAR";
            // 
            // AProv.
            // 
            this.AProv.AutoSize = true;
            this.AProv.Location = new System.Drawing.Point(7, 145);
            this.AProv.Name = "AProv";
            this.AProv.Size = new System.Drawing.Size(109, 24);
            this.AProv.TabIndex = 30;
            this.AProv.Text = "Proveedor";
            this.AProv.UseVisualStyleBackColor = true;
            // 
            // AUsu.
            // 
            this.AUsu.AutoSize = true;
            this.AUsu.Location = new System.Drawing.Point(7, 205);
            this.AUsu.Name = "AUsu";
            this.AUsu.Size = new System.Drawing.Size(99, 24);
            this.AUsu.TabIndex = 33;
            this.AUsu.Text = "Usuarios";
            this.AUsu.UseVisualStyleBackColor = true;
            // 
            // AProductos.
            // 
            this.AProductos.AutoSize = true;
            this.AProductos.Location = new System.Drawing.Point(7, 175);
            this.AProductos.Name = "AProductos";
            this.AProductos.Size = new System.Drawing.Size(109, 24);
            this.AProductos.TabIndex = 28;
            this.AProductos.Text = "Productos";
            this.AProductos.UseVisualStyleBackColor = true;
            // 
            // ALReg.
            // 
            this.ALReg.AutoSize = true;
            this.ALReg.Location = new System.Drawing.Point(6, 85);
            this.ALReg.Name = "ALReg";
            this.ALReg.Size = new System.Drawing.Size(85, 24);
            this.ALReg.TabIndex = 2;
            this.ALReg.Text = "Region";
            this.ALReg.UseVisualStyleBackColor = true;
            // 
            // ALPro.
            // 
            this.ALPro.AutoSize = true;
            this.ALPro.Location = new System.Drawing.Point(6, 55);
            this.ALPro.Name = "ALPro";
            this.ALPro.Size = new System.Drawing.Size(100, 24);
            this.ALPro.TabIndex = 1;
            this.ALPro.Text = "Provincia";
            this.ALPro.UseVisualStyleBackColor = true;
            // 
            // ACliente.
            // 
            this.ACliente.AutoSize = true;
            this.ACliente.Location = new System.Drawing.Point(7, 115);
            this.ACliente.Name = "ACliente";
            this.ACliente.Size = new System.Drawing.Size(84, 24);
            this.ACliente.TabIndex = 28;
            this.ACliente.Text = "Cliente";
            this.ACliente.UseVisualStyleBackColor = true;
            // 
            // ALCom.
            // 
            this.ALCom.AutoSize = true;
            this.ALCom.Location = new System.Drawing.Point(6, 25);
            this.ALCom.Name = "ALCom";
            this.ALCom.Size = new System.Drawing.Size(94, 24);
            this.ALCom.TabIndex = 0;
            this.ALCom.Text = "Comuna";
            this.ALCom.UseVisualStyleBackColor = true;
            // 
            // GroupBox3.
            // 
            this.groupBox3.Controls.Add(this.EUsu);
            this.groupBox3.Controls.Add(this.EProductos);
            this.groupBox3.Controls.Add(this.EProv);
            this.groupBox3.Controls.Add(this.ELReg);
            this.groupBox3.Controls.Add(this.ECliente);
            this.groupBox3.Controls.Add(this.ELPro);
            this.groupBox3.Controls.Add(this.ELCom);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(503, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 235);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ELIMINAR";
            // 
            // EUsu.
            // 
            this.EUsu.AutoSize = true;
            this.EUsu.Location = new System.Drawing.Point(7, 211);
            this.EUsu.Name = "EUsu";
            this.EUsu.Size = new System.Drawing.Size(99, 24);
            this.EUsu.TabIndex = 34;
            this.EUsu.Text = "Usuarios";
            this.EUsu.UseVisualStyleBackColor = true;
            // 
            // EProductos.
            // 
            this.EProductos.AutoSize = true;
            this.EProductos.Location = new System.Drawing.Point(7, 183);
            this.EProductos.Name = "EProductos";
            this.EProductos.Size = new System.Drawing.Size(109, 24);
            this.EProductos.TabIndex = 29;
            this.EProductos.Text = "Productos";
            this.EProductos.UseVisualStyleBackColor = true;
            // 
            // EProv.
            // 
            this.EProv.AutoSize = true;
            this.EProv.Location = new System.Drawing.Point(7, 153);
            this.EProv.Name = "EProv";
            this.EProv.Size = new System.Drawing.Size(109, 24);
            this.EProv.TabIndex = 31;
            this.EProv.Text = "Proveedor";
            this.EProv.UseVisualStyleBackColor = true;
            // 
            // ELReg.
            // 
            this.ELReg.AutoSize = true;
            this.ELReg.Location = new System.Drawing.Point(7, 93);
            this.ELReg.Name = "ELReg";
            this.ELReg.Size = new System.Drawing.Size(85, 24);
            this.ELReg.TabIndex = 2;
            this.ELReg.Text = "Region";
            this.ELReg.UseVisualStyleBackColor = true;
            // 
            // ECliente.
            // 
            this.ECliente.AutoSize = true;
            this.ECliente.Location = new System.Drawing.Point(7, 123);
            this.ECliente.Name = "ECliente";
            this.ECliente.Size = new System.Drawing.Size(84, 24);
            this.ECliente.TabIndex = 29;
            this.ECliente.Text = "Cliente";
            this.ECliente.UseVisualStyleBackColor = true;
            // 
            // ELPro.
            // 
            this.ELPro.AutoSize = true;
            this.ELPro.Location = new System.Drawing.Point(7, 59);
            this.ELPro.Name = "ELPro";
            this.ELPro.Size = new System.Drawing.Size(100, 24);
            this.ELPro.TabIndex = 1;
            this.ELPro.Text = "Provincia";
            this.ELPro.UseVisualStyleBackColor = true;
            // 
            // ELCom.
            // 
            this.ELCom.AutoSize = true;
            this.ELCom.Location = new System.Drawing.Point(7, 29);
            this.ELCom.Name = "ELCom";
            this.ELCom.Size = new System.Drawing.Size(94, 24);
            this.ELCom.TabIndex = 0;
            this.ELCom.Text = "Comuna";
            this.ELCom.UseVisualStyleBackColor = true;
            // 
            // ButGua.
            // 
            this.ButGua.Location = new System.Drawing.Point(8, 348);
            this.ButGua.Name = "ButGua";
            this.ButGua.Size = new System.Drawing.Size(148, 23);
            this.ButGua.TabIndex = 29;
            this.ButGua.Text = "Guardar Cambios";
            this.ButGua.UseVisualStyleBackColor = true;
            this.ButGua.Click += new System.EventHandler(this.ButGua_Click);
            // 
            // ButLim.
            // 
            this.ButLim.Location = new System.Drawing.Point(22, 380);
            this.ButLim.Name = "ButLim";
            this.ButLim.Size = new System.Drawing.Size(104, 23);
            this.ButLim.TabIndex = 30;
            this.ButLim.Text = "Limpiar";
            this.ButLim.UseVisualStyleBackColor = true;
            this.ButLim.Click += new System.EventHandler(this.ButLim_Click);
            // 
            // ButVol.
            // 
            this.ButVol.Location = new System.Drawing.Point(12, 417);
            this.ButVol.Name = "ButVol";
            this.ButVol.Size = new System.Drawing.Size(75, 23);
            this.ButVol.TabIndex = 31;
            this.ButVol.Text = "Volver";
            this.ButVol.UseVisualStyleBackColor = true;
            this.ButVol.Click += new System.EventHandler(this.ButVol_Click);
            // 
            // ButSal.
            // 
            this.ButSal.Location = new System.Drawing.Point(117, 417);
            this.ButSal.Name = "ButSal";
            this.ButSal.Size = new System.Drawing.Size(75, 23);
            this.ButSal.TabIndex = 32;
            this.ButSal.Text = "Salir";
            this.ButSal.UseVisualStyleBackColor = true;
            this.ButSal.Click += new System.EventHandler(this.ButSal_Click);
            // 
            // GrillaUsuarios.
            // 
            this.GrillaUsuarios.AllowUserToAddRows = false;
            this.GrillaUsuarios.AllowUserToDeleteRows = false;
            this.GrillaUsuarios.AllowUserToResizeColumns = false;
            this.GrillaUsuarios.AllowUserToResizeRows = false;
            this.GrillaUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GrillaUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.GrillaUsuarios.ColumnHeadersHeight = 29;
            this.GrillaUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selec,
            this.Id,
            this.Nombre,
            this.Pass,
            this.IdPer});
            this.GrillaUsuarios.EnableHeadersVisualStyles = false;
            this.GrillaUsuarios.Location = new System.Drawing.Point(8, 55);
            this.GrillaUsuarios.Name = "GrillaUsuarios";
            this.GrillaUsuarios.ReadOnly = true;
            this.GrillaUsuarios.RowHeadersVisible = false;
            this.GrillaUsuarios.RowHeadersWidth = 51;
            this.GrillaUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrillaUsuarios.Size = new System.Drawing.Size(144, 280);
            this.GrillaUsuarios.TabIndex = 242;
            this.GrillaUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaUsuarios_CellContentClick);
            this.GrillaUsuarios.DoubleClick += new System.EventHandler(this.GrillaUsuarios_DoubleClick);
            // 
            // Selec.
            // 
            this.Selec.HeaderText = "";
            this.Selec.MinimumWidth = 6;
            this.Selec.Name = "Selec";
            this.Selec.ReadOnly = true;
            this.Selec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selec.Visible = false;
            this.Selec.Width = 20;
            // 
            // Id.
            // 
            this.Id.HeaderText = "IdUsu";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nombre.
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 333;
            // 
            // Pass.
            // 
            this.Pass.HeaderText = "Pass";
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            this.Pass.Visible = false;
            // 
            // IdPer.
            // 
            this.IdPer.HeaderText = "IdPer";
            this.IdPer.MinimumWidth = 6;
            this.IdPer.Name = "IdPer";
            this.IdPer.ReadOnly = true;
            this.IdPer.Visible = false;
            this.IdPer.Width = 350;
            // 
            // TextIngMod.
            // 
            this.TextIngMod.Location = new System.Drawing.Point(333, 318);
            this.TextIngMod.Name = "TextIngMod";
            this.TextIngMod.Size = new System.Drawing.Size(139, 20);
            this.TextIngMod.TabIndex = 243;
            // 
            // TextPass.
            // 
            this.TextPass.Location = new System.Drawing.Point(333, 346);
            this.TextPass.Name = "TextPass";
            this.TextPass.Size = new System.Drawing.Size(139, 20);
            this.TextPass.TabIndex = 244;
            // 
            // TextCon.
            // 
            this.TextCon.Location = new System.Drawing.Point(333, 377);
            this.TextCon.Name = "TextCon";
            this.TextCon.Size = new System.Drawing.Size(139, 20);
            this.TextCon.TabIndex = 245;
            // 
            // Label2.
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 246;
            this.label2.Text = "Nombre:";
            // 
            // Label3.
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(228, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 247;
            this.label3.Text = "Contraseña:";
            // 
            // Label4.
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 16);
            this.label4.TabIndex = 248;
            this.label4.Text = "Confirmar contraseña:";
            // 
            // CheckCon.
            // 
            this.CheckCon.AutoSize = true;
            this.CheckCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCon.Location = new System.Drawing.Point(478, 374);
            this.CheckCon.Name = "CheckCon";
            this.CheckCon.Size = new System.Drawing.Size(161, 20);
            this.CheckCon.TabIndex = 249;
            this.CheckCon.Text = "Mostrar Contraseña";
            this.CheckCon.UseVisualStyleBackColor = true;
            this.CheckCon.CheckedChanged += new System.EventHandler(this.CheckCon_CheckedChanged);
            // 
            // CheckPass.
            // 
            this.CheckPass.AutoSize = true;
            this.CheckPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckPass.Location = new System.Drawing.Point(478, 346);
            this.CheckPass.Name = "CheckPass";
            this.CheckPass.Size = new System.Drawing.Size(161, 20);
            this.CheckPass.TabIndex = 250;
            this.CheckPass.Text = "Mostrar Contraseña";
            this.CheckPass.UseVisualStyleBackColor = true;
            this.CheckPass.CheckedChanged += new System.EventHandler(this.CheckPass_CheckedChanged);
            // 
            // TextIdMod.
            // 
            this.textIdMod.Enabled = false;
            this.textIdMod.Location = new System.Drawing.Point(8, -1);
            this.textIdMod.Name = "textIdMod";
            this.textIdMod.Size = new System.Drawing.Size(100, 20);
            this.textIdMod.TabIndex = 251;
            this.textIdMod.Visible = false;
            // 
            // TextIdPer.
            // 
            this.textIdPer.Enabled = false;
            this.textIdPer.Location = new System.Drawing.Point(12, 25);
            this.textIdPer.Name = "textIdPer";
            this.textIdPer.Size = new System.Drawing.Size(100, 20);
            this.textIdPer.TabIndex = 252;
            this.textIdPer.Visible = false;
            // 
            // PUsua_Mod.
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 472);
            this.Controls.Add(this.textIdPer);
            this.Controls.Add(this.textIdMod);
            this.Controls.Add(this.CheckPass);
            this.Controls.Add(this.CheckCon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextCon);
            this.Controls.Add(this.TextPass);
            this.Controls.Add(this.TextIngMod);
            this.Controls.Add(this.GrillaUsuarios);
            this.Controls.Add(this.ButSal);
            this.Controls.Add(this.ButVol);
            this.Controls.Add(this.ButLim);
            this.Controls.Add(this.ButGua);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "PUsua_Mod";
            this.Text = "PUsua_Mod";
            this.Load += new System.EventHandler(this.PUsua_Mod_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ILReg;
        private System.Windows.Forms.CheckBox ILCom;
        private System.Windows.Forms.CheckBox ILPro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ALReg;
        private System.Windows.Forms.CheckBox ALPro;
        private System.Windows.Forms.CheckBox ALCom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ELReg;
        private System.Windows.Forms.CheckBox ELPro;
        private System.Windows.Forms.CheckBox ELCom;
        private System.Windows.Forms.CheckBox ICliente;
        private System.Windows.Forms.CheckBox ACliente;
        private System.Windows.Forms.CheckBox ECliente;
        private System.Windows.Forms.CheckBox AProv;
        private System.Windows.Forms.CheckBox IProv;
        private System.Windows.Forms.CheckBox EProv;
        private System.Windows.Forms.CheckBox IProductos;
        private System.Windows.Forms.CheckBox AProductos;
        private System.Windows.Forms.CheckBox EProductos;
        private System.Windows.Forms.Button ButGua;
        private System.Windows.Forms.Button ButLim;
        private System.Windows.Forms.Button ButVol;
        private System.Windows.Forms.CheckBox IUsu;
        private System.Windows.Forms.CheckBox AUsu;
        private System.Windows.Forms.CheckBox EUsu;
        private System.Windows.Forms.Button ButSal;
        private System.Windows.Forms.DataGridView GrillaUsuarios;
        private System.Windows.Forms.DataGridViewButtonColumn Selec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPer;
        private System.Windows.Forms.TextBox TextIngMod;
        private System.Windows.Forms.TextBox TextPass;
        private System.Windows.Forms.TextBox TextCon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckCon;
        private System.Windows.Forms.CheckBox CheckPass;
        private System.Windows.Forms.TextBox textIdMod;
        private System.Windows.Forms.TextBox textIdPer;
    }
}
