using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Vista
{
    public partial class FormProducteFisicConsulta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];

        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteConsulta;
        public FormProducteFisicConsulta(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteConsulta)
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
            this.btnProducteConsulta = btnProducteConsulta;
        }

        private void bConsultaProducteFisicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProductesFisics, btnProducteConsulta);
        }

        private void bConsultaProducteFisicBuidar_Click(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textConsultaProducteFisicReferencia,
                textConsultaProducteFisicNom,
                textConsultaProducteFisicTipus,
                textConsultaProducteFisicPreu,
                textConsultaProducteFisicQuantitat);

            this.ActiveControl = textConsultaProducteFisicReferencia;
        }

        private void bConsultaProducteFisicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPF";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textConsultaProducteFisicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteFisic.showDataProductFisic(textConsultaProducteFisicReferencia,
                textConsultaProducteFisicNom,
                textConsultaProducteFisicTipus,
                textConsultaProducteFisicPreu,
                textConsultaProducteFisicQuantitat,
                responseServer);

            this.ActiveControl = textConsultaProducteFisicReferencia;
        }

        private void FormProducteFisicConsulta_Load(object sender, EventArgs e)
        {
            // Activem 
            this.ActiveControl = textConsultaProducteFisicReferencia;

            // Default TextBox
            Utilitats.Initialize.waitingReponseServerTextBox(textConsultaProducteFisicReferencia,
                textConsultaProducteFisicNom,
                textConsultaProducteFisicTipus,
                textConsultaProducteFisicPreu,
                textConsultaProducteFisicQuantitat);

            // Disable
            Utilitats.ToggleSwitch.disableTextBox(textConsultaProducteFisicNom,
                textConsultaProducteFisicTipus,
                textConsultaProducteFisicPreu,
                textConsultaProducteFisicQuantitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bConsultaProducteFisicCercar,
                bConsultaProducteFisicBuidar,
                bConsultaProducteFisicSortir);

            // Active
            this.ActiveControl = textConsultaProducteFisicReferencia;
        }
    }
}

