namespace ProyVentas_GUI
{
    partial class FrmListadosExcel
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
            this.btnListarProveedores = new System.Windows.Forms.Button();
            this.btnListarFacturas = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.bkgDatos = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListarProveedores
            // 
            this.btnListarProveedores.Location = new System.Drawing.Point(133, 12);
            this.btnListarProveedores.Name = "btnListarProveedores";
            this.btnListarProveedores.Size = new System.Drawing.Size(130, 38);
            this.btnListarProveedores.TabIndex = 0;
            this.btnListarProveedores.Text = "Listar Proveedores";
            this.btnListarProveedores.UseVisualStyleBackColor = true;
            this.btnListarProveedores.Click += new System.EventHandler(this.btnListarProveedores_Click);
            // 
            // btnListarFacturas
            // 
            this.btnListarFacturas.Location = new System.Drawing.Point(133, 66);
            this.btnListarFacturas.Name = "btnListarFacturas";
            this.btnListarFacturas.Size = new System.Drawing.Size(130, 43);
            this.btnListarFacturas.TabIndex = 0;
            this.btnListarFacturas.Text = "Listar Facturas";
            this.btnListarFacturas.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(179, 129);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(84, 13);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Cargando Datos";
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(133, 155);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(130, 23);
            this.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBar.TabIndex = 3;
            // 
            // pcbImagen
            // 
            //this.pcbImagen.Image = global::ProyVentas_GUI.Properties.Resources.indicator;
            //this.pcbImagen.Location = new System.Drawing.Point(133, 129);
            //this.pcbImagen.Name = "pcbImagen";
            //this.pcbImagen.Size = new System.Drawing.Size(23, 20);
            //this.pcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //this.pcbImagen.TabIndex = 4;
            //this.pcbImagen.TabStop = false;
            // 
            // bkgDatos
            // 
            this.bkgDatos.WorkerReportsProgress = true;
            // 
            // FrmListadosExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 186);
            this.Controls.Add(this.pcbImagen);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnListarFacturas);
            this.Controls.Add(this.btnListarProveedores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadosExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados Excel (EPPLUS)";
            this.Load += new System.EventHandler(this.FrmListadosExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListarProveedores;
        private System.Windows.Forms.Button btnListarFacturas;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.PictureBox pcbImagen;
        private System.ComponentModel.BackgroundWorker bkgDatos;
    }
}