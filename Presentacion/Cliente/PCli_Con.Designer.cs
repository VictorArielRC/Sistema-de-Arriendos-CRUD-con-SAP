namespace Presentacion.Cliente
{
    partial class PCli_Con
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
            this.ButClien = new System.Windows.Forms.Button();
            this.ButLimBus = new System.Windows.Forms.Button();
            this.ButBus = new System.Windows.Forms.Button();
            this.TextBus = new System.Windows.Forms.TextBox();
            this.ComboBus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ButEli = new System.Windows.Forms.Button();
            this.ButMod = new System.Windows.Forms.Button();
            this.ButSal = new System.Windows.Forms.Button();
            this.ButVol = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Giro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // ButClien
            // 
            this.ButClien.Enabled = false;
            this.ButClien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButClien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButClien.Location = new System.Drawing.Point(443, 422);
            this.ButClien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButClien.Name = "ButClien";
            this.ButClien.Size = new System.Drawing.Size(118, 49);
            this.ButClien.TabIndex = 244;
            this.ButClien.TabStop = false;
            this.ButClien.Text = "Importar Cliente";
            this.ButClien.UseVisualStyleBackColor = true;
            this.ButClien.Visible = false;
            this.ButClien.Click += new System.EventHandler(this.ButClien_Click);
            // 
            // ButLimBus
            // 
            this.ButLimBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButLimBus.Location = new System.Drawing.Point(635, 76);
            this.ButLimBus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButLimBus.Name = "ButLimBus";
            this.ButLimBus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButLimBus.Size = new System.Drawing.Size(198, 35);
            this.ButLimBus.TabIndex = 243;
            this.ButLimBus.Text = "Limpiar Busqueda";
            this.ButLimBus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButLimBus.UseVisualStyleBackColor = true;
            this.ButLimBus.Click += new System.EventHandler(this.ButLimBus_Click);
            // 
            // ButBus
            // 
            this.ButBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButBus.Location = new System.Drawing.Point(486, 76);
            this.ButBus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButBus.Name = "ButBus";
            this.ButBus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButBus.Size = new System.Drawing.Size(89, 31);
            this.ButBus.TabIndex = 242;
            this.ButBus.Text = "Buscar";
            this.ButBus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButBus.UseVisualStyleBackColor = true;
            this.ButBus.Click += new System.EventHandler(this.ButBus_Click);
            // 
            // TextBus
            // 
            this.TextBus.Location = new System.Drawing.Point(87, 84);
            this.TextBus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBus.Name = "TextBus";
            this.TextBus.Size = new System.Drawing.Size(335, 26);
            this.TextBus.TabIndex = 241;
            this.TextBus.TabStop = false;
            this.TextBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBus.TextChanged += new System.EventHandler(this.TextBus_TextChanged);
            // 
            // ComboBus
            // 
            this.ComboBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBus.FormattingEnabled = true;
            this.ComboBus.Location = new System.Drawing.Point(192, 49);
            this.ComboBus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBus.Name = "ComboBus";
            this.ComboBus.Size = new System.Drawing.Size(142, 28);
            this.ComboBus.TabIndex = 240;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 239;
            this.label4.Text = "Buscar Por:";
            // 
            // TextBox1
            // 
            this.TextBox1.Enabled = false;
            this.TextBox1.Location = new System.Drawing.Point(575, 436);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(101, 26);
            this.TextBox1.TabIndex = 238;
            this.TextBox1.TabStop = false;
            this.TextBox1.Visible = false;
            // 
            // ButEli
            // 
            this.ButEli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButEli.Enabled = false;
            this.ButEli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButEli.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButEli.Location = new System.Drawing.Point(443, 422);
            this.ButEli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButEli.Name = "ButEli";
            this.ButEli.Size = new System.Drawing.Size(118, 49);
            this.ButEli.TabIndex = 237;
            this.ButEli.TabStop = false;
            this.ButEli.Text = "Eliminar";
            this.ButEli.UseVisualStyleBackColor = true;
            this.ButEli.Visible = false;
            this.ButEli.Click += new System.EventHandler(this.ButEli_Click);
            // 
            // ButMod
            // 
            this.ButMod.Enabled = false;
            this.ButMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButMod.Location = new System.Drawing.Point(443, 422);
            this.ButMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButMod.Name = "ButMod";
            this.ButMod.Size = new System.Drawing.Size(118, 49);
            this.ButMod.TabIndex = 236;
            this.ButMod.TabStop = false;
            this.ButMod.Text = "Actualizar";
            this.ButMod.UseVisualStyleBackColor = true;
            this.ButMod.Visible = false;
            this.ButMod.Click += new System.EventHandler(this.ButMod_Click);
            // 
            // ButSal
            // 
            this.ButSal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButSal.Location = new System.Drawing.Point(921, 422);
            this.ButSal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButSal.Name = "ButSal";
            this.ButSal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButSal.Size = new System.Drawing.Size(71, 49);
            this.ButSal.TabIndex = 235;
            this.ButSal.Text = "Salir";
            this.ButSal.UseVisualStyleBackColor = true;
            this.ButSal.Click += new System.EventHandler(this.ButSal_Click);
            // 
            // ButVol
            // 
            this.ButVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButVol.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButVol.Location = new System.Drawing.Point(12, 422);
            this.ButVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButVol.Name = "ButVol";
            this.ButVol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButVol.Size = new System.Drawing.Size(71, 49);
            this.ButVol.TabIndex = 234;
            this.ButVol.Text = "Volver";
            this.ButVol.UseVisualStyleBackColor = true;
            this.ButVol.Click += new System.EventHandler(this.ButVol_Click);
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.Grilla.ColumnHeadersHeight = 34;
            this.Grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.IdCli,
            this.Nombre,
            this.Rut,
            this.IdCom,
            this.Comuna,
            this.Direccion,
            this.Tel,
            this.Email,
            this.Giro});
            this.Grilla.EnableHeadersVisualStyles = false;
            this.Grilla.Location = new System.Drawing.Point(12, 123);
            this.Grilla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.RowHeadersVisible = false;
            this.Grilla.RowHeadersWidth = 62;
            this.Grilla.Size = new System.Drawing.Size(980, 277);
            this.Grilla.TabIndex = 233;
            this.Grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellContentClick);
            this.Grilla.DoubleClick += new System.EventHandler(this.Grilla_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // IdCli
            // 
            this.IdCli.HeaderText = "IdCli";
            this.IdCli.MinimumWidth = 6;
            this.IdCli.Name = "IdCli";
            this.IdCli.ReadOnly = true;
            this.IdCli.Visible = false;
            this.IdCli.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 400;
            // 
            // Rut
            // 
            this.Rut.HeaderText = "Rut";
            this.Rut.MinimumWidth = 8;
            this.Rut.Name = "Rut";
            this.Rut.ReadOnly = true;
            this.Rut.Width = 120;
            // 
            // IdCom
            // 
            this.IdCom.HeaderText = "IdCom";
            this.IdCom.MinimumWidth = 8;
            this.IdCom.Name = "IdCom";
            this.IdCom.ReadOnly = true;
            this.IdCom.Visible = false;
            this.IdCom.Width = 150;
            // 
            // Comuna
            // 
            this.Comuna.HeaderText = "Comuna";
            this.Comuna.MinimumWidth = 8;
            this.Comuna.Name = "Comuna";
            this.Comuna.ReadOnly = true;
            this.Comuna.Width = 240;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.MinimumWidth = 8;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Visible = false;
            this.Direccion.Width = 150;
            // 
            // Tel
            // 
            this.Tel.HeaderText = "Tel";
            this.Tel.MinimumWidth = 8;
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            this.Tel.Visible = false;
            this.Tel.Width = 150;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            this.Email.Width = 150;
            // 
            // Giro
            // 
            this.Giro.HeaderText = "Giro";
            this.Giro.MinimumWidth = 8;
            this.Giro.Name = "Giro";
            this.Giro.ReadOnly = true;
            this.Giro.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 232;
            this.label1.Text = "Información sobre Cliente";
            // 
            // PCli_Con
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 512);
            this.ControlBox = false;
            this.Controls.Add(this.ButClien);
            this.Controls.Add(this.ButLimBus);
            this.Controls.Add(this.ButBus);
            this.Controls.Add(this.TextBus);
            this.Controls.Add(this.ComboBus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ButEli);
            this.Controls.Add(this.ButMod);
            this.Controls.Add(this.ButSal);
            this.Controls.Add(this.ButVol);
            this.Controls.Add(this.Grilla);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PCli_Con";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información sobre Cliente";
            this.Load += new System.EventHandler(this.PCli_Con_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ButClien;
        private System.Windows.Forms.Button ButLimBus;
        private System.Windows.Forms.Button ButBus;
        private System.Windows.Forms.TextBox TextBus;
        public System.Windows.Forms.ComboBox ComboBus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox1;
        public System.Windows.Forms.Button ButEli;
        public System.Windows.Forms.Button ButMod;
        public System.Windows.Forms.Button ButSal;
        public System.Windows.Forms.Button ButVol;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Giro;
    }
}