using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Vista
{


    public partial class FormProducteFisicAlta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteAlta;
        public FormProducteFisicAlta(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteAlta)
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
            this.btnProducteAlta = btnProducteAlta;
        }

        private void bAltaProducteLogicBuidar_Click(object sender, EventArgs e)
        {
            // Empty Textbox
            Utilitats.Initialize.emptyTextBox(textAltaProducteFisicReferencia,
                textAltaProducteFisicNom,
                textAltaProducteFisicTipus,
                textAltaProducteFisicPreu,
                textAltaProducteFisicQuantitat);

            this.ActiveControl = textAltaProducteFisicReferencia;
        }

        private void bAltaProducteFisicSortir_Click(object sender, EventArgs e)
        {
            // Hide
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesFisics,
                btnProductesLogics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProducteAlta, btnProductesFisics);
        }

        private void bAltaProducteFisicGravar_Click(object sender, EventArgs e)
        {
            String operation = "ALTAPF";

            // Create Object
            ProducteFisic productFisic = new ProducteFisic(textAltaProducteFisicReferencia.Text,
                textAltaProducteFisicNom.Text,
                textAltaProducteFisicTipus.Text,
                textAltaProducteFisicPreu.Text,
                textAltaProducteFisicQuantitat.Text);

            // Management TextBox 
            List<string> responseServer = ControllerProducteFisic.managementCreateOrUpdate(productFisic,
                sessionCommunicationData,
                operation);

            // Empty TexBox
            Utilitats.Initialize.emptyTextBoxWithControl(responseServer[0], textAltaProducteFisicReferencia,
                textAltaProducteFisicNom,
                textAltaProducteFisicTipus,
                textAltaProducteFisicPreu,
                textAltaProducteFisicQuantitat);

            this.ActiveControl = textAltaProducteFisicReferencia;
        }

        private void FormProducteFisicAlta_Load(object sender, EventArgs e)
        {
            // Draw
            UIStyler.changeButtonBackColorBlue(bAltaProducteFisicBuidar,
                bAltaProducteFisicGravar,
                bAltaProducteFisicSortir);
        }
    }
}

