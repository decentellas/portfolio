using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace CatVentari.Vista
{
    public partial class FormProducteLogicConsulta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteConsulta;

        public FormProducteLogicConsulta(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteConsulta)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];

            this.btnProductesLogics = btnProductesLogics;
            this.btnProducteConsulta = btnProducteConsulta;
            this.btnProductesFisics = btnProductesFisics;
        }

        private void bConsultaProducteLogicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProducteConsulta, btnProductesFisics);
        }

        private void bConsultaProducteLogicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPL";
            // Manage Search
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textConsultaProducteLogicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteLogic.showDataProductLogic(textConsultaProducteLogicReferencia,
                textConsultaProducteLogicNom,
                textConsultaProducteLogicTipus,
                textConsultaProducteLogicPreu,
                textConsultaProducteLogicQuantitat,
                textConsultaProducteLogicVersio,
                textConsultaProducteLogicDataCaducitat,
                responseServer);

            this.ActiveControl = textConsultaProducteLogicReferencia;
        }

        private void FormProducteLogicConsulta_Load(object sender, EventArgs e)
        {
            // Draw
            Initialize.waitingReponseServerTextBox(textConsultaProducteLogicReferencia,
                textConsultaProducteLogicNom,
                textConsultaProducteLogicTipus,
                textConsultaProducteLogicPreu,
                textConsultaProducteLogicQuantitat,
                textConsultaProducteLogicVersio,
                textConsultaProducteLogicDataCaducitat);

            // Disable
            ToggleSwitch.disableTextBox(textConsultaProducteLogicNom,
                textConsultaProducteLogicTipus,
                textConsultaProducteLogicPreu,
                textConsultaProducteLogicQuantitat,
                textConsultaProducteLogicVersio,
                textConsultaProducteLogicDataCaducitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bConsultaProducteLogicCercar,
                bConsultaProducteLogicBuidar,
                bConsultaProducteLogicSortir);

            // Active
            this.ActiveControl = textConsultaProducteLogicReferencia;
        }

        private void bConsultaProducteLogicBuidar_Click(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textConsultaProducteLogicReferencia,
                textConsultaProducteLogicNom,
                textConsultaProducteLogicTipus,
                textConsultaProducteLogicPreu,
                textConsultaProducteLogicQuantitat,
                textConsultaProducteLogicVersio,
                textConsultaProducteLogicDataCaducitat);

            this.ActiveControl = textConsultaProducteLogicReferencia;
        }
    }
}
