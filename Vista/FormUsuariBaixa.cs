using APP_Catventari;
using CatVentari.Controlador;
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
    public partial class FormUsuariBaixa : Form
    {
        private readonly Object[] sessionCommunicationData = new Object[3];
        public FormUsuariBaixa(object[] sessionCommunicationData)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];
        }

        private void FormBaixaUsuari_Load(object sender, EventArgs e)
        {
            // Default TextBox
            Initialize.waitingReponseServerTextBox(textBaixaUsuariCorreuElectronic,
                textBaixaUsuariNom,
                textBaixaUsuariCognoms,
                textBaixaUsuariRol);

            // Disable
            ToggleSwitch.changeStateButton(bBaixaUsuariEsborrar);

            // Disable
            ToggleSwitch.disableTextBox(textBaixaUsuariNom,
                 textBaixaUsuariCognoms,
                textBaixaUsuariRol);

            // Draw            
            UIStyler.changeButtonBackColorBlue(bBaixaUsuariSortir,
                bBaixaUsuariCercar,
                bBaixaUsuariEsborrar);

            // Active
            this.ActiveControl = textBaixaUsuariCorreuElectronic;
        }

        // Acció boto Sortir del formulari
        private void bBaixaSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        // Acció boto Esborrar 
        private void bBaixaEsborrar_Click(object sender, EventArgs e)
        {
            String operation = "BAIXAUS";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textBaixaUsuariCorreuElectronic,
                sessionCommunicationData,
                operation);

            // Default TextBox
            Initialize.waitingReponseServerTextBoxWithControl(responseServer[0], textBaixaUsuariCorreuElectronic,
                textBaixaUsuariNom,
                textBaixaUsuariCognoms,
                textBaixaUsuariRol);

            // Enable if found
            ToggleSwitch.disableButtonWithControl(bBaixaUsuariEsborrar, responseServer[0]);

            // Active
            this.ActiveControl = textBaixaUsuariCorreuElectronic;
        }



        private void bBaixaCercar_Click(object sender, EventArgs e)
        {
            String operation = "CONSULTAUS";

            // Manage Search
            List<string> responseServer = ControllerForm.managementSearchOrDelete(textBaixaUsuariCorreuElectronic,
                sessionCommunicationData,
                operation);

            // Show Information
            ControllerUser.showDataUser(textBaixaUsuariCorreuElectronic,
                textBaixaUsuariNom,
                textBaixaUsuariCognoms,
                textBaixaUsuariRol,
                responseServer);

            // Enable if found
            ToggleSwitch.enableButtonWithControl(bBaixaUsuariEsborrar, responseServer[0]);

            // Active
            this.ActiveControl = textBaixaUsuariCorreuElectronic;
        }
    }
}
