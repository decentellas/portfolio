using CatVentari.Controlador;
using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatVentari.Vista
{

    public partial class FormUsuariAlta : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        public FormUsuariAlta(object[] sessionCommunicationData)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];

        }
        private void FormAltaUsuari_Load(object sender, EventArgs e)
        {
            // Default value
            comboAltaUsuariRol.SelectedIndex = 0;

            // Draw
            UIStyler.changeButtonBackColorBlue(bAltaUsuariBuidar,
                bAltaUsuariGravar,
                bAltaUsuariSortir);

            // setHidden Properties
            TextBoxManager.setTextBoxHiddenCharacters(textAltaUsuariContrasenya, textAltaUsuariContrasenyaRepetida);

            // Active
            this.ActiveControl = textAltaUsuariNom;

        }

        private void bAltaSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void bAltaBuidar_Click(object sender, EventArgs e)
        {

            // Empty TextBox
            Initialize.emptyTextBoxAndCombo(comboAltaUsuariRol, textAltaUsuariNom,
                textAltaUsuariCognoms,
                textAltaUsuariCorreuElectronic,
                textAltaUsuariContrasenya,
                textAltaUsuariContrasenyaRepetida);

            // Active
            this.ActiveControl = textAltaUsuariNom;
        }

        private void bAltaGravar_Click(object sender, EventArgs e)
        {
            String operation = "ALTAUS";

            // Create Object
            Usuari usuari = new Usuari(textAltaUsuariNom.Text,
                 textAltaUsuariCognoms.Text,
                 textAltaUsuariCorreuElectronic.Text,
                 comboAltaUsuariRol.Text,
                 textAltaUsuariContrasenya.Text,
                 textAltaUsuariContrasenyaRepetida.Text);

            // Management TextBox 
            List<string> responseServer = ControllerUser.managemenCreateOrUpdate(usuari,
                sessionCommunicationData,
                operation);

            // Empty TextBox
            Initialize.emptyTextBoxAndComboWithControl(comboAltaUsuariRol, responseServer[0], textAltaUsuariNom,
                textAltaUsuariCognoms,
                textAltaUsuariCorreuElectronic,
                textAltaUsuariContrasenya,
                textAltaUsuariContrasenyaRepetida);

            this.ActiveControl = textAltaUsuariNom;
        }
    }
}
