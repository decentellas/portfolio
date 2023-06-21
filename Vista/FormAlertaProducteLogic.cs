using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatVentari.Vista
{

    public partial class FormAlertaProducteLogic : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];

        public FormAlertaProducteLogic(object[] sessionCommunicationData)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];
        }

        private void bAlertProducteLogicEnviamentEmail_Click(object sender, EventArgs e)
        {
            // Seria un cop validat, agafa l´usuari i després fer una cerca per aconseguir email, i passar-ho com a parametre.
            ControllerAlert.sendAlertToEmail(textAlertaReferencia,
                textAlertaProducteLogicNom,
                textAlertaProducteLogicVersioInstalada,
                textAlertaProducteLogicVersioDisponible,
                "decentellas@gmail.com");
        }

        private void bAlertaProducteLogicSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void bAlertaProducteLogicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPL";

            // Manage Search
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textAlertaReferencia,
                sessionCommunicationData,
                operation);

            if (responseServer != null)
            {
                operation = "CONSULTAVERSIO";

                // Show Information
                ControllerAlert.showDataAlert(textAlertaProducteLogicNom,
                    textAlertaProducteLogicVersioInstalada,
                    responseServer);

                // Query version
                List<string> versionAvailable = ControllerAlert.searchVersionAvaibility(textAlertaReferencia,
                    sessionCommunicationData,
                    operation);

                // iF version avaibility
                if (versionAvailable[0].Equals("0"))
                {
                    textAlertaProducteLogicVersioDisponible.Text = versionAvailable[1];
                    ToggleSwitch.enableButton(bAlertProducteLogicEnviamentEmail);
                }

                this.ActiveControl = textAlertaReferencia;
            }
        }

        private void FormAlertaProducteLogic_Load(object sender, EventArgs e)
        {
            // Draw
            UIStyler.changeButtonBackColorBlue(bAlertaProducteLogicBuidar,
                bAlertaProducteLogicCercar,
                bAlertaProducteLogicSortir,
                bAlertProducteLogicEnviamentEmail);

            // Disable
            ToggleSwitch.disableTextBox(textAlertaProducteLogicNom,
                textAlertaProducteLogicVersioDisponible,
                textAlertaProducteLogicVersioInstalada);

            ToggleSwitch.disableButton(bAlertProducteLogicEnviamentEmail);

            // Default
            Initialize.waitingReponseServerTextBox(textAlertaReferencia,
                textAlertaProducteLogicNom,
                textAlertaProducteLogicVersioInstalada,
                textAlertaProducteLogicVersioDisponible);
        }

        private void bAlertaProducteLogicBuidar_Click(object sender, EventArgs e)
        {
            // Default
            Initialize.waitingReponseServerTextBox(textAlertaReferencia,
                textAlertaProducteLogicNom,
                textAlertaProducteLogicVersioInstalada,
                textAlertaProducteLogicVersioDisponible);

            this.ActiveControl = textAlertaReferencia;
        }
    }
}
