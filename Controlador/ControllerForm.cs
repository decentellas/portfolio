using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CatVentari.Controlador
{
    internal class ControllerForm
    {

        /*
        * Management to Search and Delete 
        * @param text to search
        * @param data communication socket token, rol
        * @param operation CRUD
        * @return response server
        */

        internal static List<string> managementSearchOrDelete(System.Windows.Forms.TextBox textReferenceOrEmail, object[] sessionCommunicationData, string operation)
        {
            const string ERROR_CODE = "-1";
            List<string> responseServer = new List<string> { ERROR_CODE };

            // Validation
            if (Validation.isNotEmpty(textReferenceOrEmail.Text))
            {
                // Action search
                responseServer = actionSearchOrDelete(textReferenceOrEmail.Text,
                    sessionCommunicationData,
                    operation);

                if (operation.Equals("CONSULTAPF"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Consulta producte fisic amb referencia: " + textReferenceOrEmail.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultNotFound(responseServer);
                }

                if (operation.Equals("CONSULTAUS"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Consulta usuari amb referencia: " + textReferenceOrEmail.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultNotFound(responseServer);
                }

                if (operation.Equals("BAIXAPF"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Baixa producte fisic amb referencia: " + textReferenceOrEmail.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultOperation(responseServer);
                }

                if (operation.Equals("BAIXAUS"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Baixa usuari amb referencia: " + textReferenceOrEmail.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultOperation(responseServer);
                }
            }
            return responseServer;
        }

        /* Prepare chain and send to server
        * @param word search
        * @param data comunication socket,token, rol
        * @param operation CRUD
        * @return response server
        */
        internal static List<string> actionSearchOrDelete(string wordSearch, object[] sessionCommunicationData, string operation)
        {
            // Prepare chain           
            String dataFormatDecrypted = FormatDBString.formatChainSearchDelete((string)sessionCommunicationData[1],
                operation,
                wordSearch);

            // Send chain
            return ControllerSocket.sendDencryptedOperationGetDecryptedServerResponse((Socket)sessionCommunicationData[0],
                dataFormatDecrypted);
        }

        /*
        * Load form to panel
        * @param form
        * @param panel
        * 
        */
        public static void loadFormIntoPanel(Form formLoad, Panel panelActive)
        {
            formLoad.TopLevel = false;
            formLoad.Dock = DockStyle.Fill;
            panelActive.Controls.Add(formLoad);
            formLoad.Show();
            formLoad.Focus();
        }
    }
}
