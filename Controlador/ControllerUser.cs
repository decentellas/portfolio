using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace CatVentari.Controlador
{
    internal class ControllerUser
    {
        /*
         * Management Create or Update UER
         * @param user
         * @param data ssesion
         * oparam operation CRUD
         */     
        internal static List<string> managemenCreateOrUpdate(Usuari user, object[] sessionCommunicationData, string operation)
        {
            const string ERROR_CODE = "-1";
            List<string> responseServer = new List<string> { ERROR_CODE };          

            // Check
            if (Validation.validationUser(user))
            {

                Usuari usuariBBDD = new Usuari (user.nom, user.cognoms, user.correu, user.contrasenya, user.rol);
                // Send data
                responseServer = actionCreateOrUpdate(usuariBBDD,
                    sessionCommunicationData,
                    operation);

                if (operation.Equals("ALTAUS"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Alta usuari/a: " + user.correu);
                }

                if (operation.Equals("MODIFICACIOUS"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Modificacio usuari/a: " + user.correu);
                }

                // Show 
                Utilitats.MessageBox.showResultOperation(responseServer);

            }
            return responseServer;
        }

        /*
         * Action Create or Update user
         * @param  user 
         * @param data communication 
         * @param operation CRUD
         */
        private static List<string> actionCreateOrUpdate(Usuari userBBDD, object[] sessionCommunicationData, string operation)
        {
            String dataFormatDecrypted = String.Empty;
            // Prepare chain
            if (operation.Equals("ALTAUS"))
            {
                dataFormatDecrypted = FormatDBString.formatChainUserNew((string)sessionCommunicationData[1],
                    operation,
                    userBBDD);
            }

            if (operation.Equals("MODIFICACIOUS"))
            {
              dataFormatDecrypted = FormatDBString.formatChainUserUpdate((string)sessionCommunicationData[1],
                 operation,
                 userBBDD);
            }

            // Send chain response server decrypted
            return ControllerSocket.sendDencryptedOperationGetDecryptedServerResponse((Socket)sessionCommunicationData[0],
                dataFormatDecrypted);
        }

        /* 
        * show data
        * param email
        * @param Name
        * @param Surname
        * @param Rol
        * @param resposta
        */
        internal static void showDataUser(TextBox textEmail, TextBox textName, TextBox textSurname, TextBox textPassword, TextBox textRol, List<string> responseServer)
        {
            // Show        
            textEmail.Text = responseServer[1];
            textPassword.Text = responseServer[2];
            textRol.Text = responseServer[3];
            textName.Text = responseServer[4];
            textSurname.Text = responseServer[5];          
        }

        /* 
        * show data
        * param email
        * @param Name
        * @param Surname
        * @param Rol
        * @param response
        */
        internal static void showDataUser(TextBox textEmail, TextBox textName, TextBox textSurname, TextBox textRol, List<string> responseServer)
        {
            textEmail.Text = responseServer[1];         
            textRol.Text = responseServer[3];
            textName.Text = responseServer[4];
            textSurname.Text = responseServer[5];
        }

        /* 
        * show data if exit
        * param email
        * @param Name
        * @param Surname
        * @param Rol
        * @param response
        */
        internal static void showDataUser(TextBox textEmail, TextBox textName, TextBox textSurname, TextBox textPassword, TextBox textPassordRepit, System.Windows.Forms.ComboBox comboRol, List<string> responseServer)
        {
            // Show
            if (responseServer.Equals("0"))
            {
                textEmail.Text = responseServer[1];
                textPassword.Text = responseServer[2];
                textPassordRepit.Text = responseServer[2];
                comboRol.Text = responseServer[3];
                textName.Text = responseServer[4];
                textSurname.Text = responseServer[5];
            }
        }
    }    
}
