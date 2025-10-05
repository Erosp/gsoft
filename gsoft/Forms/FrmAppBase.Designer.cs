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
            this.panelContent = new System.Windows.Forms.Panel();
            this.imgRestaurar = new System.Windows.Forms.PictureBox();
            this.imgMinimizar = new System.Windows.Forms.PictureBox();
            this.imgMaximizar = new System.Windows.Forms.PictureBox();
            this.imgCerrar = new System.Windows.Forms.PictureBox();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnMenuProyecto = new System.Windows.Forms.Button();
            this.btnMenuUsuarios = new System.Windows.Forms.Button();
            this.btnMenuRoles = new System.Windows.Forms.Button();
            this.btnMenuCerrar = new System.Windows.Forms.Button();
            this.labelMenu = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.imgRestaurar);
            this.panelTop.Controls.Add(this.imgMinimizar);
            this.panelTop.Controls.Add(this.imgMaximizar);
            this.panelTop.Controls.Add(this.imgCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 40);
            this.panelTop.TabIndex = 0;
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(77)))));
            this.panelSide.Controls.Add(this.labelMenu);
            this.panelSide.Controls.Add(this.btnMenuCerrar);
            this.panelSide.Controls.Add(this.btnMenuRoles);
            this.panelSide.Controls.Add(this.btnMenuUsuarios);
            this.panelSide.Controls.Add(this.btnMenuProyecto);
            this.panelSide.Controls.Add(this.imgLogo);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 40);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(216, 760);
            this.panelSide.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Gainsboro;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(216, 40);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(984, 760);
            this.panelContent.TabIndex = 2;
            // 
            // imgRestaurar
            // 
            this.imgRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgRestaurar.Image = global::gsoft.Properties.Resources.restaurar;
            this.imgRestaurar.Location = new System.Drawing.Point(1112, 3);
            this.imgRestaurar.Name = "imgRestaurar";
            this.imgRestaurar.Size = new System.Drawing.Size(35, 35);
            this.imgRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgRestaurar.TabIndex = 3;
            this.imgRestaurar.TabStop = false;
            this.imgRestaurar.Visible = false;
            this.imgRestaurar.Click += new System.EventHandler(this.imgRestaurar_Click);
            // 
            // imgMinimizar
            // 
            this.imgMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgMinimizar.Image = global::gsoft.Properties.Resources.minimizar;
            this.imgMinimizar.Location = new System.Drawing.Point(1071, 3);
            this.imgMinimizar.Name = "imgMinimizar";
            this.imgMinimizar.Size = new System.Drawing.Size(35, 35);
            this.imgMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMinimizar.TabIndex = 2;
            this.imgMinimizar.TabStop = false;
            this.imgMinimizar.Click += new System.EventHandler(this.imgMinimizar_Click);
            // 
            // imgMaximizar
            // 
            this.imgMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgMaximizar.Image = global::gsoft.Properties.Resources.maximizar;
            this.imgMaximizar.Location = new System.Drawing.Point(1112, 3);
            this.imgMaximizar.Name = "imgMaximizar";
            this.imgMaximizar.Size = new System.Drawing.Size(35, 35);
            this.imgMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMaximizar.TabIndex = 1;
            this.imgMaximizar.TabStop = false;
            this.imgMaximizar.Click += new System.EventHandler(this.imgMaximizar_Click);
            // 
            // imgCerrar
            // 
            this.imgCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCerrar.Image = global::gsoft.Properties.Resources.cerrar;
            this.imgCerrar.Location = new System.Drawing.Point(1153, 3);
            this.imgCerrar.Name = "imgCerrar";
            this.imgCerrar.Size = new System.Drawing.Size(35, 35);
            this.imgCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCerrar.TabIndex = 0;
            this.imgCerrar.TabStop = false;
            this.imgCerrar.Click += new System.EventHandler(this.imgCerrar_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::gsoft.Properties.Resources.logogs;
            this.imgLogo.Location = new System.Drawing.Point(0, -9);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(214, 166);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // btnMenuProyecto
            // 
            this.btnMenuProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuProyecto.FlatAppearance.BorderSize = 0;
            this.btnMenuProyecto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.btnMenuProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuProyecto.ForeColor = System.Drawing.Color.White;
            this.btnMenuProyecto.Location = new System.Drawing.Point(15, 207);
            this.btnMenuProyecto.Name = "btnMenuProyecto";
            this.btnMenuProyecto.Size = new System.Drawing.Size(186, 37);
            this.btnMenuProyecto.TabIndex = 1;
            this.btnMenuProyecto.Text = "Proyectos";
            this.btnMenuProyecto.UseVisualStyleBackColor = true;
            this.btnMenuProyecto.Click += new System.EventHandler(this.btnMenuProyecto_Click);
            // 
            // btnMenuUsuarios
            // 
            this.btnMenuUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuUsuarios.FlatAppearance.BorderSize = 0;
            this.btnMenuUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.btnMenuUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnMenuUsuarios.Location = new System.Drawing.Point(15, 250);
            this.btnMenuUsuarios.Name = "btnMenuUsuarios";
            this.btnMenuUsuarios.Size = new System.Drawing.Size(186, 37);
            this.btnMenuUsuarios.TabIndex = 2;
            this.btnMenuUsuarios.Text = "Usuarios";
            this.btnMenuUsuarios.UseVisualStyleBackColor = true;
            this.btnMenuUsuarios.Click += new System.EventHandler(this.btnMenuUsuarios_Click);
            // 
            // btnMenuRoles
            // 
            this.btnMenuRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuRoles.FlatAppearance.BorderSize = 0;
            this.btnMenuRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.btnMenuRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuRoles.ForeColor = System.Drawing.Color.White;
            this.btnMenuRoles.Location = new System.Drawing.Point(15, 293);
            this.btnMenuRoles.Name = "btnMenuRoles";
            this.btnMenuRoles.Size = new System.Drawing.Size(186, 37);
            this.btnMenuRoles.TabIndex = 3;
            this.btnMenuRoles.Text = "Roles";
            this.btnMenuRoles.UseVisualStyleBackColor = true;
            this.btnMenuRoles.Click += new System.EventHandler(this.btnMenuRoles_Click);
            // 
            // btnMenuCerrar
            // 
            this.btnMenuCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuCerrar.FlatAppearance.BorderSize = 0;
            this.btnMenuCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(204)))));
            this.btnMenuCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCerrar.ForeColor = System.Drawing.Color.White;
            this.btnMenuCerrar.Location = new System.Drawing.Point(15, 336);
            this.btnMenuCerrar.Name = "btnMenuCerrar";
            this.btnMenuCerrar.Size = new System.Drawing.Size(186, 37);
            this.btnMenuCerrar.TabIndex = 4;
            this.btnMenuCerrar.Text = "Cerrar Sesión";
            this.btnMenuCerrar.UseVisualStyleBackColor = true;
            this.btnMenuCerrar.Click += new System.EventHandler(this.btnMenuCerrar_Click);
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenu.ForeColor = System.Drawing.Color.White;
            this.labelMenu.Location = new System.Drawing.Point(66, 160);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(85, 31);
            this.labelMenu.TabIndex = 5;
            this.labelMenu.Text = "Menú";
            // 
            // FrmAppBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAppBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAppBase";
            this.panelTop.ResumeLayout(false);
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox imgCerrar;
        private System.Windows.Forms.PictureBox imgMaximizar;
        private System.Windows.Forms.PictureBox imgMinimizar;
        private System.Windows.Forms.PictureBox imgRestaurar;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Button btnMenuProyecto;
        private System.Windows.Forms.Button btnMenuRoles;
        private System.Windows.Forms.Button btnMenuUsuarios;
        private System.Windows.Forms.Button btnMenuCerrar;
        private System.Windows.Forms.Label labelMenu;
    }
}