namespace gsoft.Forms.Modulos
{
    partial class FrmDetallesUsuario
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tablaDetalles = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalProyectos = new System.Windows.Forms.Label();
            this.labelTotalHoras = new System.Windows.Forms.Label();
            this.labelTotalIngresos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetalles)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(5, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(196, 37);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Detalles de:";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(77)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(762, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 36);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // tablaDetalles
            // 
            this.tablaDetalles.AllowUserToAddRows = false;
            this.tablaDetalles.AllowUserToDeleteRows = false;
            this.tablaDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDetalles.Location = new System.Drawing.Point(12, 177);
            this.tablaDetalles.Name = "tablaDetalles";
            this.tablaDetalles.ReadOnly = true;
            this.tablaDetalles.Size = new System.Drawing.Size(876, 511);
            this.tablaDetalles.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTotalProyectos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTotalHoras, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTotalIngresos, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Proyectos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Horas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(587, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Ingresos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTotalProyectos
            // 
            this.labelTotalProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalProyectos.AutoSize = true;
            this.labelTotalProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProyectos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.labelTotalProyectos.Location = new System.Drawing.Point(3, 49);
            this.labelTotalProyectos.Name = "labelTotalProyectos";
            this.labelTotalProyectos.Size = new System.Drawing.Size(286, 29);
            this.labelTotalProyectos.TabIndex = 3;
            this.labelTotalProyectos.Text = "0";
            this.labelTotalProyectos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTotalHoras
            // 
            this.labelTotalHoras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalHoras.AutoSize = true;
            this.labelTotalHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalHoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(77)))));
            this.labelTotalHoras.Location = new System.Drawing.Point(295, 49);
            this.labelTotalHoras.Name = "labelTotalHoras";
            this.labelTotalHoras.Size = new System.Drawing.Size(286, 29);
            this.labelTotalHoras.TabIndex = 4;
            this.labelTotalHoras.Text = "0";
            this.labelTotalHoras.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTotalIngresos
            // 
            this.labelTotalIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalIngresos.AutoSize = true;
            this.labelTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalIngresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.labelTotalIngresos.Location = new System.Drawing.Point(587, 49);
            this.labelTotalIngresos.Name = "labelTotalIngresos";
            this.labelTotalIngresos.Size = new System.Drawing.Size(286, 29);
            this.labelTotalIngresos.TabIndex = 5;
            this.labelTotalIngresos.Text = "0";
            this.labelTotalIngresos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmDetallesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tablaDetalles);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesUsuario";
            this.Text = "FrmDetallesUsuario";
            this.Load += new System.EventHandler(this.FrmDetallesUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetalles)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView tablaDetalles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalProyectos;
        private System.Windows.Forms.Label labelTotalHoras;
        private System.Windows.Forms.Label labelTotalIngresos;
    }
}