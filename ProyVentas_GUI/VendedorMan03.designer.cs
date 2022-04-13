namespace ProyVentas_GUI
{
    partial class VendedorMan03
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
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cboSupervisor = new System.Windows.Forms.ComboBox();
            this.mskDNI = new System.Windows.Forms.MaskedTextBox();
            this.mskSueldo = new System.Windows.Forms.MaskedTextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblNumSupervisados = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpFecIng = new System.Windows.Forms.DateTimePicker();
            this.optSupervisor = new System.Windows.Forms.RadioButton();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtape = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.optEjecutivo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.pcbFoto);
            this.grpDatos.Controls.Add(this.btnCargar);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.chkActivo);
            this.grpDatos.Controls.Add(this.cboSupervisor);
            this.grpDatos.Controls.Add(this.mskDNI);
            this.grpDatos.Controls.Add(this.mskSueldo);
            this.grpDatos.Controls.Add(this.btnGrabar);
            this.grpDatos.Controls.Add(this.lblNumSupervisados);
            this.grpDatos.Controls.Add(this.lblRuta);
            this.grpDatos.Controls.Add(this.lblCodigo);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.Label1);
            this.grpDatos.Controls.Add(this.dtpFecIng);
            this.grpDatos.Controls.Add(this.optSupervisor);
            this.grpDatos.Controls.Add(this.txtnom);
            this.grpDatos.Controls.Add(this.txtEmail);
            this.grpDatos.Controls.Add(this.txtape);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.optEjecutivo);
            this.grpDatos.Controls.Add(this.label9);
            this.grpDatos.Controls.Add(this.Label2);
            this.grpDatos.Controls.Add(this.Label3);
            this.grpDatos.Controls.Add(this.Label4);
            this.grpDatos.Controls.Add(this.btnCancelar);
            this.grpDatos.Location = new System.Drawing.Point(12, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(651, 402);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos";
            // 
            // pcbFoto
            // 
            this.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbFoto.Location = new System.Drawing.Point(373, 106);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(152, 117);
            this.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFoto.TabIndex = 13;
            this.pcbFoto.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(373, 76);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(72, 24);
            this.btnCargar.TabIndex = 14;
            this.btnCargar.Text = "Cargar foto";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nro. Supervisados:";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(89, 317);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(62, 17);
            this.chkActivo.TabIndex = 19;
            this.chkActivo.Text = "Activo?";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cboSupervisor
            // 
            this.cboSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupervisor.FormattingEnabled = true;
            this.cboSupervisor.Location = new System.Drawing.Point(89, 274);
            this.cboSupervisor.Name = "cboSupervisor";
            this.cboSupervisor.Size = new System.Drawing.Size(287, 21);
            this.cboSupervisor.TabIndex = 18;
            // 
            // mskDNI
            // 
            this.mskDNI.Location = new System.Drawing.Point(285, 125);
            this.mskDNI.Mask = "99999999";
            this.mskDNI.Name = "mskDNI";
            this.mskDNI.Size = new System.Drawing.Size(62, 20);
            this.mskDNI.TabIndex = 9;
            this.mskDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mskSueldo
            // 
            this.mskSueldo.Location = new System.Drawing.Point(89, 125);
            this.mskSueldo.Mask = "9999.99";
            this.mskSueldo.Name = "mskSueldo";
            this.mskSueldo.Size = new System.Drawing.Size(62, 20);
            this.mskSueldo.TabIndex = 7;
            this.mskSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(340, 346);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(72, 24);
            this.btnGrabar.TabIndex = 22;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblNumSupervisados
            // 
            this.lblNumSupervisados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumSupervisados.Location = new System.Drawing.Point(147, 351);
            this.lblNumSupervisados.Name = "lblNumSupervisados";
            this.lblNumSupervisados.Size = new System.Drawing.Size(64, 20);
            this.lblNumSupervisados.TabIndex = 21;
            // 
            // lblRuta
            // 
            this.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuta.Location = new System.Drawing.Point(373, 237);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(272, 20);
            this.lblRuta.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigo.Location = new System.Drawing.Point(89, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(64, 20);
            this.lblCodigo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Codigo:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(17, 61);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Nombre:";
            // 
            // dtpFecIng
            // 
            this.dtpFecIng.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIng.Location = new System.Drawing.Point(89, 157);
            this.dtpFecIng.Name = "dtpFecIng";
            this.dtpFecIng.Size = new System.Drawing.Size(120, 20);
            this.dtpFecIng.TabIndex = 11;
            // 
            // optSupervisor
            // 
            this.optSupervisor.Checked = true;
            this.optSupervisor.Location = new System.Drawing.Point(36, 197);
            this.optSupervisor.Name = "optSupervisor";
            this.optSupervisor.Size = new System.Drawing.Size(96, 24);
            this.optSupervisor.TabIndex = 12;
            this.optSupervisor.TabStop = true;
            this.optSupervisor.Text = "Supervisor";
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(89, 61);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(192, 20);
            this.txtnom.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(89, 238);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(192, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // txtape
            // 
            this.txtape.Location = new System.Drawing.Point(89, 93);
            this.txtape.Name = "txtape";
            this.txtape.Size = new System.Drawing.Size(192, 20);
            this.txtape.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Supervisor:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Email:";
            // 
            // optEjecutivo
            // 
            this.optEjecutivo.Location = new System.Drawing.Point(147, 199);
            this.optEjecutivo.Name = "optEjecutivo";
            this.optEjecutivo.Size = new System.Drawing.Size(96, 24);
            this.optEjecutivo.TabIndex = 13;
            this.optEjecutivo.Text = "Ejecutivo";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(213, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "DNI:";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(17, 93);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 16);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Apellido:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(17, 125);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 16);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Sueldo:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(17, 157);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 16);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "F. Ingreso:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(441, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 24);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // VendedorMan03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 424);
            this.Controls.Add(this.grpDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendedorMan03";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Vendedor";
            this.Load += new System.EventHandler(this.VendedorMan03_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cboSupervisor;
        private System.Windows.Forms.MaskedTextBox mskSueldo;
        internal System.Windows.Forms.Button btnGrabar;
        internal System.Windows.Forms.Label lblCodigo;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpFecIng;
        internal System.Windows.Forms.RadioButton optSupervisor;
        internal System.Windows.Forms.TextBox txtnom;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtape;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.RadioButton optEjecutivo;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label lblNumSupervisados;
        private System.Windows.Forms.MaskedTextBox mskDNI;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pcbFoto;
        internal System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Label lblRuta;
    }
}