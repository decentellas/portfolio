using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatVentari.Vista
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {

            // Configure columns
            dataGridViewLog.Columns.Add("Columna1", "Usuari");
            dataGridViewLog.Columns.Add("Columna2", "Rol");
            dataGridViewLog.Columns.Add("Columna3", "Dia i Hora");
            dataGridViewLog.Columns.Add("Columna4", "Detall");

            // Draw
            dataGridViewLog.Columns[0].HeaderCell.Style.BackColor = Color.FromArgb(188, 187, 195);
            dataGridViewLog.Columns[1].HeaderCell.Style.BackColor = Color.FromArgb(188, 187, 195);
            dataGridViewLog.Columns[2].HeaderCell.Style.BackColor = Color.FromArgb(188, 187, 195);
            dataGridViewLog.Columns[3].HeaderCell.Style.BackColor = Color.FromArgb(188, 187, 195);
            UIStyler.changeButtonBackColorBlue(bLogSortir, bLogInversa, bLogNormal);

            // Configure witdth
            dataGridViewLog.Columns[0].Width = 80;
            dataGridViewLog.Columns[1].Width = 70;
            dataGridViewLog.Columns[2].Width = 120;
            dataGridViewLog.Columns[3].Width = 300;

            // Configure scrollbar
            dataGridViewLog.ScrollBars = ScrollBars.Both;

            // Desactive styles
            dataGridViewLog.EnableHeadersVisualStyles = false;

            // Active
            this.ActiveControl = dataGridViewLog;

        }

        private void bLogSortir_Click(object sender, EventArgs e)
        {
            // Hiden
            this.Visible = false;
        }

        private void bLogInversa_Click(object sender, EventArgs e)
        {
            ControllerFileLog.showFileLogDown(dataGridViewLog);
        }

        private void bLogNormal_Click(object sender, EventArgs e)
        {
            ControllerFileLog.showFileLogUp(dataGridViewLog);
        }
    }
}
