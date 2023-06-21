using APP_Catventari;
using CatVentari.Controlador;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Vista
{
    public partial class FormUser : Form
    {

        private readonly Object[] sessionCommunicationData = new Object[3];
        public FormUser(List<string> responseLoginUser, Socket socketActiu)
        {
            InitializeComponent();

            // Socket
            this.sessionCommunicationData[0] = sessionCommunicationData[0];
            // Token
            this.sessionCommunicationData[1] = sessionCommunicationData[1];
            // Rol
            this.sessionCommunicationData[2] = sessionCommunicationData[2];

            // Configure Form for rol
            ControllerSession.menuRol(labMenuAdmin,
                (string)sessionCommunicationData[2],
                bAreaUsuaris,
                bLog,
                bAlertes);
        }

        private void bAreaUsuaris_Click(object sender, EventArgs e)
        {
            // Hide
            PanelManager.formClosetoPanel(panelActiu);
            PanelManager.hidePanelSubMenu(panelSubMenuInici,
                panelSubMenuTaules,
                panelSubMenuAlertes,
                panelSubMenuCRUD);

            // Show
            PanelManager.ShowSubMenu(panelSubMenuAreaUsuaris);
        }

        private void bInici_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.formClosetoPanel(panelActiu);
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris,
                panelSubMenuTaules,
                panelSubMenuAlertes,
                panelSubMenuCRUD);

            // Show
            PanelManager.ShowSubMenu(panelSubMenuInici);
        }

        private void bTancarSessio_Click(object sender, EventArgs e)
        {
            // Close
            ControllerSession.closeSessionUser(this,
                sessionCommunicationData);

            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuInici);
        }

        private void bAltaUsuari_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris);

            // Load
            Form formAltaUsuari = new FormUsuariAlta(sessionCommunicationData);
            ControllerForm.loadFormIntoPanel(formAltaUsuari, panelActiu);
        }

        private void bBaixaUsuari_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris);

            // Load
            Form formBaixaUsuari = new FormUsuariBaixa(sessionCommunicationData);
            ControllerForm.loadFormIntoPanel(formBaixaUsuari, panelActiu);
        }

        private void bModificarUsuari_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris);

            // Load
            Form formModificarUsuari = new FormUsuariModificacio(sessionCommunicationData);
            ControllerForm.loadFormIntoPanel(formModificarUsuari, panelActiu);
        }

        private void bConsultaUsuari_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris);

            // Load
            Form formConsultaUsuari = new FormUsuariConsulta(sessionCommunicationData);
            ControllerForm.loadFormIntoPanel(formConsultaUsuari, panelActiu);
        }

        private void bLog_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuInici);

            // Load
            Form formLog = new FormLog();
            ControllerForm.loadFormIntoPanel(formLog, panelActiu);
        }

        private void btnProducteAlta_Click(object sender, EventArgs e)
        {

            // Mark select 
            UIStyler.changeButtonBackColorYellow(btnProducteAlta);
            ToggleSwitch.disableButton(btnProducteBaixa,
                btnProducteModificacio,
                btnProducteConsulta);

            if (btnProductesFisics.Enabled)
            {
                Form formProducteFisicAlta = new FormProducteFisicAlta(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteAlta);
                ControllerForm.loadFormIntoPanel(formProducteFisicAlta, panelActiu);
            }
            else
            {
                Form formProducteLogicAlta = new FormProducteLogicAlta(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteAlta);
                ControllerForm.loadFormIntoPanel(formProducteLogicAlta, panelActiu);
            }

            ToggleSwitch.disableButton(btnProductesLogics, btnProductesFisics);
        }

        private void btnProductesLogics_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris,
                panelSubMenuCRUD,
                panelSubMenuTaules);

            // Enable / Diable options
            ToggleSwitch.disableButton(btnProductesFisics);
            ToggleSwitch.enableButton(btnProducteAlta,
                btnProducteBaixa,
                btnProducteModificacio,
                btnProducteConsulta);

            // Draw
            UIStyler.changeButtonForeColorYellow(btnProductesLogics);
        }

        private void btnProductesFisics_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.hidePanelSubMenu(panelSubMenuAreaUsuaris,
                panelSubMenuCRUD,
                panelSubMenuTaules);

            // Show
            ToggleSwitch.disableButton(btnProductesLogics);
            ToggleSwitch.enableButton(btnProducteAlta,
                btnProducteBaixa,
                btnProducteModificacio,
                btnProducteConsulta);

            // Draw
            UIStyler.changeButtonForeColorYellow(btnProductesFisics);
        }

        private void btnProducteBaixa_Click(object sender, EventArgs e)

        {
            UIStyler.changeButtonBackColorYellow(btnProducteBaixa);
            ToggleSwitch.disableButton(btnProducteAlta,
                btnProducteModificacio,
                btnProducteConsulta);

            if (btnProductesFisics.Enabled)
            {

                Form formProducteFisicBaixa = new FormProducteFisicBaixa(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteBaixa);
                ControllerForm.loadFormIntoPanel(formProducteFisicBaixa, panelActiu);
            }
            else
            {
                Form formProducteLogicBaixa = new FormProducteLogicBaixa(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteBaixa);
                ControllerForm.loadFormIntoPanel(formProducteLogicBaixa, panelActiu);
            }

            ToggleSwitch.disableButton(btnProductesLogics,
                btnProductesFisics);
        }

        private void btnProducteConsulta_Click(object sender, EventArgs e)
        {
            UIStyler.changeButtonBackColorYellow(btnProducteConsulta);
            ToggleSwitch.disableButton(btnProducteAlta,
                btnProducteModificacio,
                btnProducteBaixa);

            if (btnProductesFisics.Enabled)
            {
                Form formProducteFisicConsulta = new FormProducteFisicConsulta(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteConsulta);
                ControllerForm.loadFormIntoPanel(formProducteFisicConsulta, panelActiu);
            }
            else
            {
                Form formProducteLogicConsulta = new FormProducteLogicConsulta(sessionCommunicationData, btnProductesFisics, btnProductesLogics, btnProducteConsulta);
                ControllerForm.loadFormIntoPanel(formProducteLogicConsulta, panelActiu);
            }

            ToggleSwitch.disableButton(btnProductesLogics,
                 btnProductesFisics);
        }

        private void btnProducteModificacio_Click(object sender, EventArgs e)
        {
            UIStyler.changeButtonBackColorYellow(btnProducteModificacio);
            ToggleSwitch.disableButton(btnProducteBaixa,
                btnProducteAlta,
                btnProducteConsulta);

            if (btnProductesFisics.Enabled)
            {
                Form formProducteFisicModificacio = new FormProducteFisicModificacio(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteModificacio);
                ControllerForm.loadFormIntoPanel(formProducteFisicModificacio, panelActiu);
            }
            else
            {
                Form formProducteLogicModificacio = new FormProducteLogicModificacio(sessionCommunicationData, btnProductesLogics, btnProductesFisics, btnProducteModificacio);
                ControllerForm.loadFormIntoPanel(formProducteLogicModificacio, panelActiu);
            }

            ToggleSwitch.disableButton(btnProductesLogics, btnProductesFisics);
        }

        private void bTaules_Click(object sender, EventArgs e)
        {
            // Hide
            PanelManager.formClosetoPanel(panelActiu);

            PanelManager.hidePanelSubMenu(panelSubMenuInici,
                panelSubMenuAreaUsuaris,
                panelSubMenuAlertes,
                panelSubMenuCRUD);

            // Show
            PanelManager.ShowSubMenu(panelSubMenuTaules);
        }

        private void bTaulaBens_Click(object sender, EventArgs e)
        {
            Utilitats.MessageBox.informationMessageBox("NO IMPLEMENTAT ENCARA , BÉNS");
        }

        private void bTaulaProveidors_Click(object sender, EventArgs e)
        {
            // Show
            PanelManager.showPanelSubMenus(panelSubMenuCRUD);

            // Assign
            bSubMenuTaulaOperacio.Text = "Proveïdors";

            // Draw
            UIStyler.changeButtonForeColorBlack(bSubMenuTaulaOperacio, bTaulaProveidors);

            // show
            ControllerTaula.showPanelSubMenuTaula(panelSubMenuCRUD,
                bSubMenuTaulaOperacio,
                bSubMenuTaulaAlta,
                bSubMenuTaulaModificacio,
                bSubMenuTaulaConsulta,
                bSubMenuTaulaBaixa);
        }

        private void bTaulaIngressos_Click(object sender, EventArgs e)
        {
            Utilitats.MessageBox.informationMessageBox("NO IMPLEMENTAT ENCARA, INGRESSOS");
        }

        private void bTaulaDespesses_Click(object sender, EventArgs e)
        {
            Utilitats.MessageBox.informationMessageBox("NO IMPLEMENTAT ENCARA, DESPESES ");
        }

        private void bSubMenuTaulaAlta_Click(object sender, EventArgs e)
        {
            if (bSubMenuTaulaOperacio.Text == "Proveïdors")
            {
                // Hide
                PanelManager.hidePanelSubMenu(panelSubMenuTaules,
                    panelSubMenuCRUD);

                // Draw
                UIStyler.changeButtonForeColorYellow(bTaulaProveidors);

                // Load
                Form formProveidorAlta = new FormProveidorAlta();
                ControllerForm.loadFormIntoPanel(formProveidorAlta, panelActiu);
            }
        }

        private void bSubMenuTaulaModificacio_Click(object sender, EventArgs e)
        {
            if (bSubMenuTaulaOperacio.Text == "Proveïdors")
            {
                // Hide
                PanelManager.hidePanelSubMenu(panelSubMenuTaules,
                    panelSubMenuCRUD);

                // Draw
                UIStyler.changeButtonForeColorYellow(bTaulaProveidors);

                // Load
                Form formProveidorModificacio = new FormProveidorModificacio();
                ControllerForm.loadFormIntoPanel(formProveidorModificacio, panelActiu);
            }
        }

        private void bSubMenuTaulaConsulta_Click(object sender, EventArgs e)
        {
            if (bSubMenuTaulaOperacio.Text == "Proveïdors")
            {
                // Hide
                PanelManager.hidePanelSubMenu(panelSubMenuTaules,
                    panelSubMenuCRUD);

                // Draw
                UIStyler.changeButtonForeColorYellow(bTaulaProveidors);

                // Load
                Form formProveidorConsulta = new FormProveidorConsulta();
                ControllerForm.loadFormIntoPanel(formProveidorConsulta, panelActiu);
            }
        }

        private void bSubMenuTaulaBaixa_Click(object sender, EventArgs e)
        {
            if (bSubMenuTaulaOperacio.Text == "Proveïdors")
            {
                // Hide
                PanelManager.hidePanelSubMenu(panelSubMenuTaules,
                    panelSubMenuCRUD);

                // Draw
                UIStyler.changeButtonForeColorYellow(bTaulaProveidors);

                // Load
                Form formProveidorBaixa = new FormProveidorBaixa();
                ControllerForm.loadFormIntoPanel(formProveidorBaixa, panelActiu);
            }
        }

        private void bInformes_Click(object sender, EventArgs e)
        {
            // Hide
            PanelManager.hidePanelSubMenu(panelSubMenuInici);

            // Load
            Form formInformes = new FormInformes();
            ControllerForm.loadFormIntoPanel(formInformes, panelActiu);
        }

        private void bAlertaProducteLogic_Click(object sender, EventArgs e)
        {
            // Hide
            PanelManager.hidePanelSubMenu(panelSubMenuAlertes);

            // Load
            Form formAlertaProducteLogic = new FormAlertaProducteLogic(sessionCommunicationData);
            ControllerForm.loadFormIntoPanel(formAlertaProducteLogic, panelActiu);
        }

        private void bAlertes_Click(object sender, EventArgs e)
        {
            // Hiden
            PanelManager.formClosetoPanel(panelActiu);
            PanelManager.hidePanelSubMenu(panelSubMenuInici,
                panelSubMenuAreaUsuaris,
                panelSubMenuTaules,
                panelSubMenuCRUD);

            // Show
            PanelManager.showPanelSubMenus(panelSubMenuAlertes);
        }


        private void FormUser_Load_1(object sender, EventArgs e)
        {
            // Draw
            this.BackColor = Colors.colorLogoGray;

            UIStyler.changePanelBackColorYellow(panelActiu);

            // Add controls
            panelSubMenuTaules.Controls.AddRange(new Control[] { bTaulaIngressos,
                bTaulaBens,
                bTaulaDespeses,
                bTaulaProveidors });
            panelSubMenuCRUD.Controls.AddRange(new Control[] { bSubMenuTaulaOperacio,
                bSubMenuTaulaAlta,
                bSubMenuTaulaModificacio,
                bSubMenuTaulaConsulta,
                bSubMenuTaulaBaixa });
            panelSubMenuAlertes.Controls.Add(bAlertaProducteLogic);

            // Hide
            PanelManager.hidePanelSubMenu(panelSubMenuTaules,
                panelSubMenuCRUD,
                panelSubMenuAlertes);
            bTaulaDespeses.Visible = false;
        }

        private void panelActiu_Paint(object sender, PaintEventArgs e)
        {
            // Hiden
            Utilitats.PanelManager.hidePanelSubMenu(panelSubMenuAlertes,
                panelSubMenuAreaUsuaris,
                panelSubMenuCRUD,
                panelSubMenuInici,
                panelSubMenuTaules);
        }
    }
}

