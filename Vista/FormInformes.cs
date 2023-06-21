using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CatVentari.Vista
{
    public partial class FormInformes : Form
    {
        public FormInformes()
        {
            InitializeComponent();
        }

        private void bInformeSortir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormInformes_Load(object sender, EventArgs e)
        {
            // Configure label
            UIStyler.configureLabelReport(lInformeGeneralXifratge,
                lInformesGeneralDesxifrades);

            // Draw
            UIStyler.changeButtonBackColorBlue(bInformesCercar,
                 bInformeSortir);

            // Disable TextBox
            ToggleSwitch.disableTextBox(
                textInformeProducteLogicError,
                textInformesProductesFisicsError,
                textInformeProduceLogicAlta,
                textInformeProducteFisicAlta,
                textInformeProducteLogicBaixa,
                textInformesProductesFisicsBaixa,
                textInformeProducteLogicConsulta,
                textInformesProductesFisicConsulta,
                textInformeProducteLogicModificacio,
                textInformeProducteFisicModificacio,
                textInformeGeneralRespostesXifrades,
                textInformesGeneralEnviamentXifrat,
                textInformeProducteFisicsTotal,
                textInformeNumeroConnexionsCorrectes,
                textInformeProductesLogics);
        }

        private void bInformesCercar_Click(object sender, EventArgs e)
        {
            String operation = String.Empty;

            if (!string.IsNullOrEmpty(textInformeNomUsuariCercar.Text) && !string.IsNullOrWhiteSpace(textInformeNomUsuariCercar.Text))
            {
                int counterConnectionsUsers = ControllerReport.reportConnectionsUser(textInformeNomUsuariCercar);

                int[] counterEncryptedTransmission = ControllerReport.reportEncryptedTransmission(textInformeNomUsuariCercar);

                operation = "PRODUCTE_LOGIC";
                int[] counterAcitionsProducteLogic = ControllerReport.reportProducts(textInformeNomUsuariCercar, operation);

                operation = "PRODUCTE_FISIC";
                int[] counterAcitionsProducteFisic = ControllerReport.reportProducts(textInformeNomUsuariCercar, operation);

                // Show results
                ControllerReport.showConnectionsUser(counterConnectionsUsers, textInformeNumeroConnexionsCorrectes);

                ControllerReport.showEncryptedTransmission(counterEncryptedTransmission, textInformesGeneralEnviamentXifrat,
                    textInformeGeneralRespostesXifrades);

                ControllerReport.showActionsProducts(counterAcitionsProducteFisic, textInformeProduceLogicAlta,
                    textInformeProducteLogicBaixa,
                    textInformeProducteLogicConsulta,
                    textInformeProducteLogicModificacio,
                    textInformeProducteLogicError,
                    textInformeProductesLogics);

                ControllerReport.showActionsProducts(counterAcitionsProducteLogic, textInformeProduceLogicAlta,
                    textInformeProducteLogicBaixa,
                    textInformeProducteLogicConsulta,
                    textInformeProducteLogicModificacio,
                    textInformeProducteLogicError,
                    textInformeProductesLogics);
            }
            else
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: Falta un nom correcte per cercar");
            }
        }
    }
}
