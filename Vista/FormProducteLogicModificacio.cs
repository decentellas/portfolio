using CatVentari.Controlador;
using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace CatVentari.Vista
{
    public partial class FormProducteLogicModificacio : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteModificacio;
        public FormProducteLogicModificacio(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteModificacio)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];

            this.btnProductesLogics = btnProductesLogics;
            this.btnProductesFisics = btnProductesFisics;
            this.btnProducteModificacio = btnProducteModificacio;
        }

        private void bModificaProducteLogicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics, btnProducteModificacio);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProductesLogics, btnProducteModificacio);
        }

        private void bModificaProducteLogicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPL";

            // Do query
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textModificaProducteLogicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteLogic.showDataProductLogic(textModificaProducteLogicReferencia,
                textModificaProducteLogicNom,
                textModificaProducteLogicTipus,
                textModificaProducteLogicPreu,
                textModificaProducteLogicQuantitat,
                textModificaProducteLogicVersio,
                textModificaProducteLogicDataCaducitat,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(btnProducteModificacio, responseServer[0]);

            // Activem 
            this.ActiveControl = textModificaProducteLogicNom;
        }

        private void FormProducteLogicModificacio_Load(object sender, EventArgs e)
        {
            // Draw
            Utilitats.Initialize.waitingReponseServerTextBox(textModificaProducteLogicReferencia,
                textModificaProducteLogicNom,
                textModificaProducteLogicTipus,
                textModificaProducteLogicPreu,
                textModificaProducteLogicQuantitat,
                textModificaProducteLogicVersio,
                textModificaProducteLogicDataCaducitat);

            // Disable
            Utilitats.ToggleSwitch.disableTextBox(textModificaProducteLogicNom,
                textModificaProducteLogicTipus, textModificaProducteLogicPreu,
                textModificaProducteLogicQuantitat,
                textModificaProducteLogicVersio,
                textModificaProducteLogicDataCaducitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bModificaProducteLogicCercar,
                bModificaProducteLogicModificar,
                bModificaProducteLogicSortir);

            // Activem 
            this.ActiveControl = textModificaProducteLogicReferencia;
        }

        private void bModificaProducteLogicModificar_Click(object sender, EventArgs e)
        {
            string operation = "MODIFICACIOPL";

            // Create Object
            ProducteLogic productLogic = new ProducteLogic(textModificaProducteLogicReferencia.Text,
                textModificaProducteLogicNom.Text,
                textModificaProducteLogicTipus.Text,
                textModificaProducteLogicPreu.Text,
                textModificaProducteLogicQuantitat.Text,
                textModificaProducteLogicVersio.Text,
                textModificaProducteLogicDataCaducitat.Text);

            // Management TextBox 
            List<string> responseServer = ControllerProducteLogic.managementCreateOrUpdate(productLogic,
                sessionCommunicationData,
                operation);

            // Empty TexBox
            Utilitats.Initialize.waitingReponseServerTextBoxWithControl(responseServer[0], textModificaProducteLogicReferencia,
                textModificaProducteLogicNom,
                textModificaProducteLogicTipus,
                textModificaProducteLogicPreu,
                textModificaProducteLogicQuantitat,
                textModificaProducteLogicVersio,
                textModificaProducteLogicDataCaducitat);

            // Disable if found
            ToggleSwitch.disableButtonWithControl(btnProducteModificacio, responseServer[0]);

            this.ActiveControl = textModificaProducteLogicReferencia;
        }

    }
}
