namespace CatVentari.Vista
{
    partial class FormLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bLogSortir = new System.Windows.Forms.Button();
            this.lAltaUsuari = new System.Windows.Forms.Label();
            this.dataGridViewLog = new System.Windows.Forms.DataGridView();
            this.bLogInversa = new System.Windows.Forms.Button();
            this.bLogNormal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // bLogSortir
            // 
            this.bLogSortir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogSortir.Location = new System.Drawing.Point(371, 249);
            this.bLogSortir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bLogSortir.Name = "bLogSortir";
            this.bLogSortir.Size = new System.Drawing.Size(84, 36);
            this.bLogSortir.TabIndex = 2;
            this.bLogSortir.Text = "Sortir";
            this.bLogSortir.UseVisualStyleBackColor = true;
            this.bLogSortir.Click += new System.EventHandler(this.bLogSortir_Click);
            // 
            // lAltaUsuari
            // 
            this.lAltaUsuari.AutoSize = true;
            this.lAltaUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAltaUsuari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lAltaUsuari.Location = new System.Drawing.Point(76, 14);
            this.lAltaUsuari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAltaUsuari.Name = "lAltaUsuari";
            this.lAltaUsuari.Size = new System.Drawing.Size(287, 29);
            this.lAltaUsuari.TabIndex = 10;
            this.lAltaUsuari.Text = "REGISTRE ARXIU LOG";
            this.lAltaUsuari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewLog
            // 
            this.dataGridViewLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(187)))), ((int)(((byte)(195)))));
            this.dataGridViewLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(197)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(197)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(197)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLog.Location = new System.Drawing.Point(8, 54);
            this.dataGridViewLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewLog.Name = "dataGridViewLog";
            this.dataGridViewLog.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(187)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLog.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLog.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLog.RowTemplate.Height = 28;
            this.dataGridViewLog.Size = new System.Drawing.Size(511, 184);
            this.dataGridViewLog.TabIndex = 1;
            //this.dataGridViewLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLog_CellContentClick);
            // 
            // bLogInversa
            // 
            this.bLogInversa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogInversa.Location = new System.Drawing.Point(157, 248);
            this.bLogInversa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bLogInversa.Name = "bLogInversa";
            this.bLogInversa.Size = new System.Drawing.Size(84, 36);
            this.bLogInversa.TabIndex = 11;
            this.bLogInversa.Text = "ASC";
            this.bLogInversa.UseVisualStyleBackColor = true;
            this.bLogInversa.Click += new System.EventHandler(this.bLogInversa_Click);
            // 
            // bLogNormal
            // 
            this.bLogNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogNormal.Location = new System.Drawing.Point(57, 248);
            this.bLogNormal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bLogNormal.Name = "bLogNormal";
            this.bLogNormal.Size = new System.Drawing.Size(84, 36);
            this.bLogNormal.TabIndex = 12;
            this.bLogNormal.Text = "DESC";
            this.bLogNormal.UseVisualStyleBackColor = true;
            this.bLogNormal.Click += new System.EventHandler(this.bLogNormal_Click);
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(197)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.bLogNormal);
            this.Controls.Add(this.bLogInversa);
            this.Controls.Add(this.dataGridViewLog);
            this.Controls.Add(this.bLogSortir);
            this.Controls.Add(this.lAltaUsuari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLog";
            this.Load += new System.EventHandler(this.FormLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLogSortir;
        private System.Windows.Forms.Label lAltaUsuari;
        private System.Windows.Forms.DataGridView dataGridViewLog;
        private System.Windows.Forms.Button bLogInversa;
        private System.Windows.Forms.Button bLogNormal;
    }
}