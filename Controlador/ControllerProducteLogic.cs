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
    internal class ControllerProducteLogic
    {
        /*
        * Management to earch or Delete
        * @param text to search
        * @param data communication socket token, rol
        * @param operation CRUD
        * @return response server
        */
        internal static List<string> managementSearchOrDelete(System.Windows.Forms.TextBox textConsultaProducteLogicReferencia, object[] sessionCommunicationData, string operation)
        {
            const string ERROR_CODE = "-1";
            List<string> responseServer = new List<string> { ERROR_CODE };

            if (Validation.isNotEmpty(textConsultaProducteLogicReferencia.Text))
            {
                // Action search
                responseServer = ControllerForm.actionSearchOrDelete(textConsultaProducteLogicReferencia.Text,
                    sessionCommunicationData,
                    operation);

                if (operation.Equals("CONSULTAPL"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Consulta producte logic amb referencia: " + textConsultaProducteLogicReferencia.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultNotFound(responseServer);
                }

                if (operation.Equals("BAIXAPL"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Baixa producte logic amb referencia: " + textConsultaProducteLogicReferencia.Text);

                    // Show Result
                    Utilitats.MessageBox.showResultOperation(responseServer);
                }

            }
            return responseServer;
        }

        /*
       * Management to Create or Update
       * @param text to search
       * @param data communication socket token, rol
       * @param operation CRUD
       * @return response server
       */
        internal static List<String> managementCreateOrUpdate(ProducteLogic producteLogic, object[] sessionCommunicationData, String operation)
        {
            const string ERROR_CODE = "-1";
            List<string> responseServer = new List<string> { ERROR_CODE };

            // Check
            if (Validation.validationProductLogic(producteLogic))
            {
                // Convertim Data
                String formatDateBBDD = DateManager.converFormatDateBBDD(producteLogic.dataCaducitat);

                // Create Product Logic format BBDD
                ProducteLogic producteLogicBBDD = new ProducteLogic(producteLogic.referencia,
                    producteLogic.nom,
                    producteLogic.tipus,
                    producteLogic.preu,
                    producteLogic.quantitat,
                    producteLogic.versio,
                    formatDateBBDD);

                // Send data
                responseServer = actionCreateOrUpdate(producteLogicBBDD,
                    sessionCommunicationData,
                    operation);

                if (operation.Equals("ALTAPL"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Alta producte logic: " + producteLogic.referencia);
                }

                if (operation.Equals("MODIFICACIOPL"))
                {
                    // Record Log
                    ControllerFileLog.recordOperationLog(responseServer[0],
                        "Modificacio del producte logic amb referencia: " + producteLogic.referencia);
                }
                // Show 
                Utilitats.MessageBox.showResultOperation(responseServer);

            }
            return responseServer;
        }
        /*
        * Action Create param or Update
        * @param productFisic object
        * @param sesionCommunication socket,token,rol
        * @param operation CRUD
        * 
        */
        private static List<String> actionCreateOrUpdate(ProducteLogic producteLogicBBDD, object[] sessionCommunicationData, string operation)
        {
            String dataFormatDecrypted = String.Empty; ;

            // Prepare chain
            if (operation.Equals("ALTAPL"))
            {
                dataFormatDecrypted = FormatDBString.formatChainProductLogicNew((string)sessionCommunicationData[1],
                    operation,
                    producteLogicBBDD);
            }

            if (operation.Equals("MODIFICACIOPL"))
            {
                dataFormatDecrypted = FormatDBString.formatChainProductLogicUpdate((string)sessionCommunicationData[1],
                    operation,
                    producteLogicBBDD);
            }

            // Send chain response server decrypted
            return ControllerSocket.sendDencryptedOperationGetDecryptedServerResponse((Socket)sessionCommunicationData[0],
                dataFormatDecrypted);
        }
        /*
        * Show data
        * @param reference
        * @param name
        * @param type
        * @param price
        * @param amount
        * @param version
        * @param date
        * @param response server
        */
        internal static void showDataProductLogic(TextBox textReference, TextBox textName, TextBox textType, TextBox textPrice, TextBox textAmount, TextBox textVersion, TextBox textDate, List<string> responseServer)
        {
            if (responseServer[0].Equals("0"))
            {
                textReference.Text = responseServer[1];
                textName.Text = responseServer[2];
                textType.Text = responseServer[3];
                textPrice.Text = responseServer[4];
                textVersion.Text = responseServer[5];
                textDate.Text = DateManager.convertDateForm(responseServer[6]);
                textAmount.Text = responseServer[7];
            }
            else
            {
                textReference.Text = string.Empty;
            }
        }

    }
}
