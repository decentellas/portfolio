using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Vista
{
    public partial class FormProducteFisicBaixa : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteBaixa;
        public FormProducteFisicBaixa(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteBaixa)
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

        private void bBaixaProducteFisicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProductesFisics, btnProducteBaixa);
        }

        private void bBaixaProducteFisicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPF";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textBaixaProducteFisicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteFisic.showDataProductFisic(textBaixaProducteFisicReferencia,
                textBaixaProducteFisicNom,
                textBaixaProducteFisicTipus,
                textBaixaProducteFisicPreu,
                textBaixaProducteFisicQuantitat,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(bBaixaProducteFisicBaixa, responseServer[0]);

            this.ActiveControl = textBaixaProducteFisicReferencia;

        }

        private void bBaixaProducteFisicBaixa_Click(object sender, EventArgs e)
        {
            //   ControllerProduct.gestioBaixaProducteFisic(textBaixaProducteFisicReferencia, textBaixaProducteFisicNom, textBaixaProducteFisicTipus, textBaixaProducteFisicPreu, textBaixaProducteFisicQuantitat, bBaixaProducteFisicBaixa, socketActiu, token, "BAIXAPF");
            String operation = "BAIXAPF";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textBaixaProducteFisicReferencia,
                sessionCommunicationData,
                operation);

            // Default TextBox
            Initialize.waitingReponseServerTextBoxWithControl(responseServer[0], textBaixaProducteFisicReferencia,
               textBaixaProducteFisicNom,
               textBaixaProducteFisicTipus,
               textBaixaProducteFisicPreu,
               textBaixaProducteFisicQuantitat);

            // Disable if found
            ToggleSwitch.disableButtonWithControl(bBaixaProducteFisicBaixa, responseServer[0]);

            this.ActiveControl = textBaixaProducteFisicReferencia;
        }

        private void FormProducteFisicBaixa_Load(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textBaixaProducteFisicReferencia,
                textBaixaProducteFisicNom,
                textBaixaProducteFisicTipus,
                textBaixaProducteFisicPreu,
                textBaixaProducteFisicQuantitat);

            // Disable
            ToggleSwitch.disableTextBox(textBaixaProducteFisicNom,
                textBaixaProducteFisicTipus,
                textBaixaProducteFisicPreu,
                textBaixaProducteFisicQuantitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bBaixaProducteFisicCercar,
                bBaixaProducteFisicBaixa,
                bBaixaProducteFisicSortir);

            // Active
            this.ActiveControl = textBaixaProducteFisicReferencia;
        }
    }
}
