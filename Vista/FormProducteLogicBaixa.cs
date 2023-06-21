using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Vista
{
    public partial class FormProducteLogicBaixa : Form
    {

        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteBaixa;
        public FormProducteLogicBaixa(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteBaixa)
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
            this.btnProducteBaixa = btnProducteBaixa;

        }

        private void bBaixaProducteLogicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProductesLogics, btnProducteBaixa);

        }
        private void FormProducteLogicBaixa_Load(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textBaixaProducteLogicReferencia,
                textBaixaProducteLogicNom,
                textBaixaProducteLogicTipus,
                textBaixaProducteLogicPreu,
                textBaixaProducteLogicQuantitat,
                textBaixaProducteLogicVersio,
                textBaixaProducteLogicDataCaducitat);

            // Disable TextBox   
            ToggleSwitch.disableTextBox(textBaixaProducteLogicNom,
                textBaixaProducteLogicTipus,
                textBaixaProducteLogicPreu,
                textBaixaProducteLogicQuantitat,
                textBaixaProducteLogicVersio,
                textBaixaProducteLogicDataCaducitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bBaixaProducteLogicCercar,
                bBaixaProducteLogicEsborrar,
                bBaixaProducteLogicSortir);

            // Activem
            this.ActiveControl = textBaixaProducteLogicReferencia;
        }

        private void bBaixaProducteLogicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPL";

            // Do query
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textBaixaProducteLogicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteLogic.showDataProductLogic(textBaixaProducteLogicReferencia,
                textBaixaProducteLogicNom,
                textBaixaProducteLogicTipus,
                textBaixaProducteLogicPreu,
                textBaixaProducteLogicQuantitat,
                textBaixaProducteLogicVersio,
                textBaixaProducteLogicDataCaducitat,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(bBaixaProducteLogicEsborrar, responseServer[0]);
        }

        private void bBaixaProducteLogicEsborrar_Click(object sender, EventArgs e)
        {
            String operation = "BAIXAPL";

            // Do query
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textBaixaProducteLogicReferencia,
                sessionCommunicationData,
                operation);

            // Default TextBox
            Initialize.waitingReponseServerTextBoxWithControl(responseServer[0], textBaixaProducteLogicReferencia,
                textBaixaProducteLogicNom,
                textBaixaProducteLogicTipus,
                textBaixaProducteLogicPreu,
                textBaixaProducteLogicQuantitat,
                textBaixaProducteLogicVersio,
                textBaixaProducteLogicDataCaducitat);

            // Disable if found
            ToggleSwitch.disableButtonWithControl(bBaixaProducteLogicEsborrar, responseServer[0]);

            this.ActiveControl = textBaixaProducteLogicReferencia;
        }
    }
}
