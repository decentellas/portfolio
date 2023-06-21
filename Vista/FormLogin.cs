using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Model;
using CatVentari.Utilitats;
using CatVentari.Vista;
using static System.Net.Mime.MediaTypeNames;

namespace CatVentari
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Draw
            UIStyler.changeButtonBackColorBlue(btnLoginValidar,
                btnLoginBuidar,
                btnLoginSortir);
            UIStyler.changePanelBackColorYellow(panelLogin);
            UIStyler.changeFormBackColorGray(this);

            // Hidden
            TextBoxManager.setTextBoxHiddenCharacters(textLoginContrasenya);

            // Active
            this.ActiveControl = textLoginUsuari;
        }

        private void btnBuidar_Click(object sender, EventArgs e)
        {
            // Empty
            Initialize.emptyTextBox(textLoginUsuari, textLoginContrasenya);
        }

        private void btnSortir_Click(object sender, EventArgs e)
        {
            Utilitats.MessageBox.questionMessageBox("Estàs segur de sortir? Confírmeu");
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            // Check socket
            Socket socketActive = ControllerSocket.openSocket();

            if (socketActive != null)
            {
                // Check Login
                List<String> responseServerLogin = ControllerSession.loginUser(socketActive, textLoginUsuari.Text, textLoginContrasenya.Text);

                // Assign
                String token = responseServerLogin[0];
                String rol = responseServerLogin[1].ToUpper();

                ControllerSession.responseServerLogin(responseServerLogin, socketActive, textLoginUsuari.Text, this);
            }
        }
    }
}
