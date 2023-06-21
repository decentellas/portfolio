using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace CatVentari.Controlador
{
    internal class ControllerProducteFisic
    {
        /*
        * Management to Create and Update
        * @param text to search
        * @param data communication socket token, rol
        * @param operation CRUD
        * @return response server
        */
        internal static List<string> managementCreateOrUpdate(ProducteFisic productFisic, object[] sessionCommunicationData, string operation)
        {
            const string ERROR_CODE = "-1";
            List<string> responseServer = new List<string> { ERROR_CODE };

            // Check
            if (Validation.validationProductFisic(productFisic))
            {
                // Send data
                responseServer = actionCreateOrUpdate(productFisic,
                    sessionCommunicationData,
                    operation);

                if (operation.Equals("ALTAPF"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Alta producte fisic: " + productFisic.referencia);
                }

                if (operation.Equals("MODIFICACIOPF"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Modificacio del producte fisic amb referencia: " + productFisic.referencia);
                }
                // Show 
                Utilitats.MessageBox.showResultOperation(responseServer);

            }
            return responseServer;
        }

        /*
         * Show data
         * @param reference
         * @param name
         * @param type
         * @param price
         * @param amount
         * @param response server
         */

        internal static void showDataProductFisic(TextBox textReferencia, TextBox textNom, TextBox textTipus, TextBox textPreu, TextBox textQuantitat, List<string> responseServer)
        {
            if (responseServer.Equals("0"))
            {
                textReferencia.Text = responseServer[1];
                textNom.Text = responseServer[2];
                textTipus.Text = responseServer[3];
                textPreu.Text = responseServer[4];
                textQuantitat.Text = responseServer[5];
            }

        }

        /*
         * Action Create param or Update
         * @param productFisic object
         * @param sesionCommunication socket,token,rol
         * @param operation CRUD
         * 
         */
        private static List<String> actionCreateOrUpdate(ProducteFisic productFisic, object[] sessionCommunicationData, string operation)
        {
            String dataFormatDecrypted = String.Empty;
            // Prepare chain
            if (operation.Equals("ALTAPF"))
            {
                dataFormatDecrypted = FormatDBString.formatChainProductFisicNew((string)sessionCommunicationData[1],
                    operation,
                    productFisic);
            }

            if (operation.Equals("MODIFICACIOPF"))
            {
                dataFormatDecrypted = FormatDBString.formatChainProductFisicUpdate((string)sessionCommunicationData[1],
                    operation,
                    productFisic);
            }

            // Send chain response server decrypted
            return ControllerSocket.sendDencryptedOperationGetDecryptedServerResponse((Socket)sessionCommunicationData[0],
                dataFormatDecrypted);
        }
    }
}
