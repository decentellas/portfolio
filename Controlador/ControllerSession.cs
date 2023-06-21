using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using CatVentari.Model;
using System.Windows.Forms;
using CatVentari.Vista;

namespace CatVentari.Controlador
{
    public class ControllerSession
    {

        /* 
         * 
         * Management Login User
         * @param socket
         * @param user
         * @param pasword
         * @return response Server
         * 
        */
        public static List<String> loginUser(Socket socketActive, string user, string password)
        {                     
            // Prepare
            String dataFormatDecrypted = FormatDBString.formatChainLogin(user, password);

            // Send chain response server decrypted
            return ControllerSocket.sendDencryptedOperationGetDecryptedServerResponse(socketActive,
                dataFormatDecrypted);         
        }
   
        // Exit App
        public static void exitApplication()
        {
            Application.Exit();
        }

        /*
         * Management response server Login
         * @param socket
         * @param user
         * @param Form
         */  
        internal static void responseServerLogin(List<string> responseServer, Socket socketActive, string textUser, Form formLogin)
        {
            String rolUser = responseServer[1];

            // Check rol
            if (rolUser.Equals("ADMINISTRADOR") || rolUser.Equals("USUARI"))
            {
                // Record Log
                ControllerFileLog.recordFileLogStart(textUser, rolUser, "Inici sessió: " + responseServer[0]);

                // Open 
                OpenFormUser(responseServer, socketActive);
            
                // Hide
                formLogin.Hide();
            }     
            else
            {
                // Record Log
                ControllerFileLog.recordFileLogStart(textUser, rolUser, "ERROR: Inici sessió");

                // Message
                Utilitats.MessageBox.informationMessageBox("Credencials no vàlides. Tornar-ho a provar!");     
                                   
                // Close
                ControllerSocket.closeSocket(socketActive);
            }
        }

        /*
         * Open Form User
         * @param response Server
         * @param socekt
         */
        private static void OpenFormUser(List<string> responseServerLogin, Socket socketActive)
        {
            FormUser formUser = new FormUser(responseServerLogin, socketActive);
            formUser.Show();
        }

        /* Assign label Administrador or Usuari
         * @param label
         * @param rol
         * @param button acces Users
         * @param button acces Log
         * @param button acces alert
         */

        internal static void menuRol(Label labMenuAdmin, string rol, Button bAccesUsers, Button bAccesLog, Button bAccesAlerts)
        {
            labMenuAdmin.Text = "MENU " + rol;

            if (rol.Equals("USUARI"))
            {
                bAccesUsers.Visible = false;
                bAccesLog.Enabled = false;
                bAccesAlerts.Visible = false;
            }
        }

        /*
       * Management close session 
       * @param form 
       * @param data communication 
       * @param socket obert        
       *  
       */
        public static void closeSessionUser(Form form, object[] sessionCommunicationData)
        {            
          
            if (Utilitats.MessageBox.questioncloseSession(form))
            {
                // Prepare   
                string logoutFormat = FormatDBString.formatChainLogout((string)sessionCommunicationData[1]);

                // Send 
                ModelSocket.socketCommunication((Socket)sessionCommunicationData[0], logoutFormat);

                // Closet
                ControllerSocket.closeSocket((Socket)sessionCommunicationData[0]);

                // Record
                ControllerFileLog.recordFileLog("Finalització sessió: " + (string)sessionCommunicationData[1]);
            }
        }
    }
}
