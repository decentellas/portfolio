using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Vista
{
    public partial class FormProducteFisicModificacio : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteModificacio;
        public FormProducteFisicModificacio(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteModificacio)
        {
            InitializeComponent();

            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            this.sessionCommunicationData[2] = sessionCommunicationData[2];

            this.btnProductesLogics = btnProductesLogics;
            this.btnProductesFisics = btnProductesFisics;
            this.btnProducteModificacio = btnProducteModificacio;
        }

        private void bModificaProducteFisicSortir_Click(object sender, EventArgs e)
        {
            // Hidden
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesLogics, btnProductesFisics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProductesFisics, btnProducteModificacio);
        }

        private void FormProducteFisicModificacio_Load(object sender, EventArgs e)
        {
            // Active
            this.ActiveControl = textModificaProducteFisicReferencia;

            // Default TextBox
            Initialize.waitingReponseServerTextBox(textModificaProducteFisicReferencia,
                textModificaProducteFisicNom,
                textModificaProducteFisicTipus,
                textModificaProducteFisicPreu,
                textModificaProducteFisicQuantitat);

            // Disable
            ToggleSwitch.disableTextBox(textModificaProducteFisicNom,
                textModificaProducteFisicTipus,
                textModificaProducteFisicPreu,
                textModificaProducteFisicQuantitat);

            // Draw
            UIStyler.changeButtonBackColorBlue(bModificaProducteFisicCercar,
                bModificaProducteFisicModificar,
                bModificaProducteFisicSortir);
        }

        private void bModificaProducteFisicCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAPF";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textModificaProducteFisicReferencia,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerProducteFisic.showDataProductFisic(textModificaProducteFisicReferencia,
                textModificaProducteFisicNom,
                textModificaProducteFisicTipus,
                textModificaProducteFisicPreu,
                textModificaProducteFisicQuantitat,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(bModificaProducteFisicModificar, responseServer[0]);

            // Active
            this.ActiveControl = textModificaProducteFisicNom;
        }

        private void bModificaProducteFisicModificar_Click(object sender, EventArgs e)
        {
            String operation = "MODIFICACIOPF";

            // Create Object
            ProducteFisic productFisic = new ProducteFisic(textModificaProducteFisicReferencia.Text,
                textModificaProducteFisicNom.Text,
                textModificaProducteFisicTipus.Text,
                textModificaProducteFisicPreu.Text,
                textModificaProducteFisicQuantitat.Text);

            // Management TextBox 
            List<string> responseServer = ControllerProducteFisic.managementCreateOrUpdate(productFisic,
                sessionCommunicationData,
                operation);

            // Default TextBox
            Utilitats.Initialize.waitingReponseServerTextBoxWithControl(responseServer[0], textModificaProducteFisicReferencia,
                textModificaProducteFisicNom,
                textModificaProducteFisicTipus,
                textModificaProducteFisicPreu,
                textModificaProducteFisicQuantitat);

            // Enable if found
            ToggleSwitch.disableButtonWithControl(bModificaProducteFisicModificar, responseServer[0]);

            this.ActiveControl = textModificaProducteFisicReferencia;
        }
    }
}
