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
    public partial class FormProducteLogicAlta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        private Button btnProductesLogics;
        private Button btnProductesFisics;
        private Button btnProducteAlta;

        public FormProducteLogicAlta(object[] sessionCommunicationData, Button btnProductesLogics, Button btnProductesFisics, Button btnProducteAlta)
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

        private void bAltaProducteLogicGravar_Click(object sender, EventArgs e)
        {

            String operation = "ALTAPL";

            // Create Object
            ProducteLogic productLogic = new ProducteLogic(textAltaProducteLogicReferencia.Text,
                textAltaProducteLogicNom.Text,
                textAltaProducteLogicTipus.Text,
                textAltaProducteLogicPreu.Text,
                textAltaProducteLogicQuantitat.Text,
                textAltaProducteLogicVersio.Text,
                textAltaProducteLogicData.Text);

            // Management TextBox 
            List<string> responseServer = ControllerProducteLogic.managementCreateOrUpdate(productLogic,
                sessionCommunicationData,
                operation);

            // Empty TexBox
            Initialize.emptyTextBoxWithControl(responseServer[0], textAltaProducteLogicReferencia,
                textAltaProducteLogicNom,
                textAltaProducteLogicTipus,
                textAltaProducteLogicPreu,
                textAltaProducteLogicQuantitat,
                textAltaProducteLogicVersio,
                textAltaProducteLogicData);

            this.ActiveControl = textAltaProducteLogicReferencia;
        }

        private void bAltaProducteLogicBuidar_Click(object sender, EventArgs e)
        {
            // Empty TextBox
            Initialize.emptyTextBox(textAltaProducteLogicReferencia,
                textAltaProducteLogicNom,
                textAltaProducteLogicTipus,
                textAltaProducteLogicPreu,
                textAltaProducteLogicQuantitat,
                textAltaProducteLogicVersio,
                textAltaProducteLogicData);

            this.ActiveControl = textAltaProducteLogicReferencia;
        }

        private void bAltaProducteLogicSortir_Click(object sender, EventArgs e)
        {
            // Hide
            this.Visible = false;

            // Enable
            ToggleSwitch.enableButton(btnProductesFisics, btnProductesLogics);

            // Draw
            UIStyler.changeButtonBackColorGray(btnProducteAlta, btnProductesLogics, btnProductesFisics);
        }

        private void FormProducteLogicAlta_Load(object sender, EventArgs e)
        {
            // Draw
            UIStyler.changeButtonBackColorBlue(bAltaProducteLogicBuidar,
                bAltaProducteLogicGravar,
                bAltaProducteLogicSortir);
        }
    }
}
