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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatVentari.Vista
{
    public partial class FormUsuariModificacio : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        public FormUsuariModificacio(object[] sessionCommunicationData)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBoxWithCombo(comboModificarUsuariRol, textModificarUsuariCorreuElectronic,
                textModificarUsuariNom,
                textModificarUsuariCognoms,
                textModificarUsuariContrasenya,
                textModificarUsuariContrasenyaRepetir);

            // Disable
            ToggleSwitch.disableTextBox(textModificarUsuariNom,
                textModificarUsuariCognoms,
                textModificarUsuariContrasenya,
                textModificarUsuariContrasenyaRepetir);

            ToggleSwitch.changeStateCombo(comboModificarUsuariRol);
            ToggleSwitch.changeStateButton(bModificarUsuariModifica);
            ;

            // Draw         
            UIStyler.changeButtonBackColorBlue(bModificarUsuariModifica,
               bModificarUsuariCercar,
               bModificarUsuariSortir);


            // setHidden Properties
            TextBoxManager.setTextBoxHiddenCharacters(textModificarUsuariContrasenya,
                textModificarUsuariContrasenyaRepetir);

            // Active
            this.ActiveControl = textModificarUsuariCorreuElectronic;

        }


        private void bModificarSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        private void bModificar_Click(object sender, EventArgs e)
        {
            String operation = "MODIFICACIOUS";

            // Create Object
            Usuari usuari = new Usuari(textModificarUsuariNom.Text,
                 textModificarUsuariCognoms.Text,
                 textModificarUsuariCorreuElectronic.Text,
                 comboModificarUsuariRol.Text,
                 textModificarUsuariContrasenya.Text,
                 textModificarUsuariContrasenyaRepetir.Text);

            // Management TextBox 
            List<string> responseServer = ControllerUser.managemenCreateOrUpdate(usuari,
                sessionCommunicationData,
                operation);

            // Default TextBox
            Initialize.waitingResponseServerTextBoxWithComboWithControl(comboModificarUsuariRol, responseServer[0], textModificarUsuariCorreuElectronic,
                textModificarUsuariNom,
                textModificarUsuariCognoms,
                textModificarUsuariContrasenya,
                textModificarUsuariContrasenyaRepetir);

            // Disaable if found
            ToggleSwitch.disableButtonWithControl(bModificarUsuariModifica, responseServer[0]);

            this.ActiveControl = textModificarUsuariNom;
        }


        private void bModificarCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAUS";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textModificarUsuariCorreuElectronic,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerUser.showDataUser(textModificarUsuariCorreuElectronic,
                textModificarUsuariNom,
                textModificarUsuariCognoms,
                textModificarUsuariContrasenya,
                textModificarUsuariContrasenyaRepetir,
                comboModificarUsuariRol,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(bModificarUsuariModifica, responseServer[0]);

            // Active
            this.ActiveControl = textModificarUsuariCorreuElectronic;

        }
    }
}
