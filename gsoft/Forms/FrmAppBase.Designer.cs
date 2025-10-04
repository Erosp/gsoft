namespace gsoft.Forms
{
    partial class FrmAppBase
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelSide = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgRestaurar = new System.Windows.Forms.PictureBox();
            this.imgMinimizar = new System.Windows.Forms.PictureBox();
            this.imgMaximizar = new System.Windows.Forms.PictureBox();
            this.imgCerrar = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelTop.Controls.Add(this.imgRestaurar);
            this.panelTop.Controls.Add(this.imgMinimizar);
            this.panelTop.Controls.Add(this.imgMaximizar);
            this.panelTop.Controls.Add(this.imgCerrar);
            this.panelTop.Location = new System.Drawing.Point(0, -1);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 40);
            this.panelTop.TabIndex = 0;
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.Teal;
            this.panelSide.Location = new System.Drawing.Point(0, 39);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(216, 761);
            this.panelSide.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(216, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 761);
            this.panel1.TabIndex = 2;
            // 
            // imgRestaurar
            // 
            this.imgRestaurar.Image = global::gsoft.Properties.Resources.restaurar;
            this.imgRestaurar.Location = new System.Drawing.Point(1030, 3);
            this.imgRestaurar.Name = "imgRestaurar";
            this.imgRestaurar.Size = new System.Drawing.Size(35, 35);
            this.imgRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgRestaurar.TabIndex = 3;
            this.imgRestaurar.TabStop = false;
            // 
            // imgMinimizar
            // 
            this.imgMinimizar.Image = global::gsoft.Properties.Resources.minimizar;
            this.imgMinimizar.Location = new System.Drawing.Point(1071, 3);
            this.imgMinimizar.Name = "imgMinimizar";
            this.imgMinimizar.Size = new System.Drawing.Size(35, 35);
            this.imgMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMinimizar.TabIndex = 2;
            this.imgMinimizar.TabStop = false;
            // 
            // imgMaximizar
            // 
            this.imgMaximizar.Image = global::gsoft.Properties.Resources.maximizar;
            this.imgMaximizar.Location = new System.Drawing.Point(1112, 3);
            this.imgMaximizar.Name = "imgMaximizar";
            this.imgMaximizar.Size = new System.Drawing.Size(35, 35);
            this.imgMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMaximizar.TabIndex = 1;
            this.imgMaximizar.TabStop = false;
            // 
            // imgCerrar
            // 
            this.imgCerrar.Image = global::gsoft.Properties.Resources.cerrar;
            this.imgCerrar.Location = new System.Drawing.Point(1153, 3);
            this.imgCerrar.Name = "imgCerrar";
            this.imgCerrar.Size = new System.Drawing.Size(35, 35);
            this.imgCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCerrar.TabIndex = 0;
            this.imgCerrar.TabStop = false;
            // 
            // FrmAppBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAppBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAppBase";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgCerrar;
        private System.Windows.Forms.PictureBox imgMaximizar;
        private System.Windows.Forms.PictureBox imgMinimizar;
        private System.Windows.Forms.PictureBox imgRestaurar;
    }
}