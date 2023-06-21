namespace CatVentari
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textLoginContrasenya = new System.Windows.Forms.TextBox();
            this.textLoginUsuari = new System.Windows.Forms.TextBox();
            this.btnLoginValidar = new System.Windows.Forms.Button();
            this.lLoginTitol = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lLoginContrasenya = new System.Windows.Forms.Label();
            this.lLoginNomUsuari = new System.Windows.Forms.Label();
            this.btnLoginBuidar = new System.Windows.Forms.Button();
            this.btnLoginSortir = new System.Windows.Forms.Button();
            this.pictureLoginLogo = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoginLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textLoginContrasenya
            // 
            this.textLoginContrasenya.Location = new System.Drawing.Point(99, 45);
            this.textLoginContrasenya.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textLoginContrasenya.Name = "textLoginContrasenya";
            this.textLoginContrasenya.Size = new System.Drawing.Size(96, 20);
            this.textLoginContrasenya.TabIndex = 2;
            // 
            // textLoginUsuari
            // 
            this.textLoginUsuari.Location = new System.Drawing.Point(99, 22);
            this.textLoginUsuari.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textLoginUsuari.Name = "textLoginUsuari";
            this.textLoginUsuari.Size = new System.Drawing.Size(96, 20);
            this.textLoginUsuari.TabIndex = 1;
            // 
            // btnLoginValidar
            // 
            this.btnLoginValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginValidar.Location = new System.Drawing.Point(173, 202);
            this.btnLoginValidar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoginValidar.Name = "btnLoginValidar";
            this.btnLoginValidar.Size = new System.Drawing.Size(63, 36);
            this.btnLoginValidar.TabIndex = 3;
            this.btnLoginValidar.Text = "Validar";
            this.btnLoginValidar.UseVisualStyleBackColor = true;
            this.btnLoginValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lLoginTitol
            // 
            this.lLoginTitol.AutoSize = true;
            this.lLoginTitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLoginTitol.Location = new System.Drawing.Point(121, 18);
            this.lLoginTitol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLoginTitol.Name = "lLoginTitol";
            this.lLoginTitol.Size = new System.Drawing.Size(329, 31);
            this.lLoginTitol.TabIndex = 3;
            this.lLoginTitol.Text = "ACCÉS AL CATVENTARI";
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.textLoginContrasenya);
            this.panelLogin.Controls.Add(this.lLoginContrasenya);
            this.panelLogin.Controls.Add(this.lLoginNomUsuari);
            this.panelLogin.Controls.Add(this.textLoginUsuari);
            this.panelLogin.Location = new System.Drawing.Point(191, 82);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(207, 96);
            this.panelLogin.TabIndex = 4;
            // 
            // lLoginContrasenya
            // 
            this.lLoginContrasenya.AutoSize = true;
            this.lLoginContrasenya.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLoginContrasenya.Location = new System.Drawing.Point(14, 49);
            this.lLoginContrasenya.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLoginContrasenya.Name = "lLoginContrasenya";
            this.lLoginContrasenya.Size = new System.Drawing.Size(77, 13);
            this.lLoginContrasenya.TabIndex = 2;
            this.lLoginContrasenya.Text = "Contrasenya";
            // 
            // lLoginNomUsuari
            // 
            this.lLoginNomUsuari.AutoSize = true;
            this.lLoginNomUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLoginNomUsuari.Location = new System.Drawing.Point(14, 26);
            this.lLoginNomUsuari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLoginNomUsuari.Name = "lLoginNomUsuari";
            this.lLoginNomUsuari.Size = new System.Drawing.Size(74, 13);
            this.lLoginNomUsuari.TabIndex = 0;
            this.lLoginNomUsuari.Text = "Nom usuari:";
            // 
            // btnLoginBuidar
            // 
            this.btnLoginBuidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginBuidar.Location = new System.Drawing.Point(327, 202);
            this.btnLoginBuidar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoginBuidar.Name = "btnLoginBuidar";
            this.btnLoginBuidar.Size = new System.Drawing.Size(63, 36);
            this.btnLoginBuidar.TabIndex = 4;
            this.btnLoginBuidar.Text = "Buidar";
            this.btnLoginBuidar.UseVisualStyleBackColor = true;
            this.btnLoginBuidar.Click += new System.EventHandler(this.btnBuidar_Click);
            // 
            // btnLoginSortir
            // 
            this.btnLoginSortir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginSortir.Location = new System.Drawing.Point(409, 202);
            this.btnLoginSortir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoginSortir.Name = "btnLoginSortir";
            this.btnLoginSortir.Size = new System.Drawing.Size(63, 36);
            this.btnLoginSortir.TabIndex = 5;
            this.btnLoginSortir.Text = "Sortir";
            this.btnLoginSortir.UseVisualStyleBackColor = true;
            this.btnLoginSortir.Click += new System.EventHandler(this.btnSortir_Click);
            // 
            // pictureLoginLogo
            // 
            this.pictureLoginLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLoginLogo.Image")));
            this.pictureLoginLogo.Location = new System.Drawing.Point(7, 68);
            this.pictureLoginLogo.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureLoginLogo.Name = "pictureLoginLogo";
            this.pictureLoginLogo.Size = new System.Drawing.Size(143, 129);
            this.pictureLoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLoginLogo.TabIndex = 7;
            this.pictureLoginLogo.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.pictureLoginLogo);
            this.Controls.Add(this.btnLoginSortir);
            this.Controls.Add(this.btnLoginBuidar);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.lLoginTitol);
            this.Controls.Add(this.btnLoginValidar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLogin";
            this.Text = "CatVentari";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.btnSortir_Click);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoginLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textLoginContrasenya;
        private System.Windows.Forms.TextBox textLoginUsuari;
        private System.Windows.Forms.Button btnLoginValidar;
        private System.Windows.Forms.Label lLoginTitol;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lLoginNomUsuari;
        private System.Windows.Forms.Label lLoginContrasenya;
        private System.Windows.Forms.Button btnLoginBuidar;
        private System.Windows.Forms.Button btnLoginSortir;
        private System.Windows.Forms.PictureBox pictureLoginLogo;
    }
}

