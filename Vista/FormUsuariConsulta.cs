using APP_Catventari;
using CatVentari.Controlador;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CatVentari.Utilitats;

namespace CatVentari.Vista
{
    public partial class FormUsuariConsulta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        public FormUsuariConsulta(object[] sessionCommunicationData)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textConsultaUsuariCorreuElectronic,
                textConsultaUsuariNom,
                textConsultaUsuariCognoms,
                textConsultaUsuariContrasenya,
                textConsultaUsuariRol);

            // Disable
            ToggleSwitch.disableTextBox(textConsultaUsuariNom,
                textConsultaUsuariCognoms,
                textConsultaUsuariContrasenya,
                textConsultaUsuariRol);

            // Draw         
            UIStyler.changeButtonBackColorBlue(bConsultaUsuariCercar,
               bConsultaUsuariSortir,
               bConsultaUsuariBuidar);

            // Active
            this.ActiveControl = textConsultaUsuariCorreuElectronic;
        }

        private void bConsultaSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void bConsultaCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAUS";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textConsultaUsuariCorreuElectronic,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerUser.showDataUser(textConsultaUsuariCorreuElectronic,
                textConsultaUsuariNom,
                textConsultaUsuariCognoms,
                textConsultaUsuariContrasenya,
                textConsultaUsuariRol,
                responseServer);

            // Active
            this.ActiveControl = textConsultaUsuariCorreuElectronic;
        }
        private void bConsultaBuidar_Click(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textConsultaUsuariCorreuElectronic,
                textConsultaUsuariNom,
                textConsultaUsuariCognoms,
                textConsultaUsuariContrasenya,
                textConsultaUsuariRol);
        }
    }
}
