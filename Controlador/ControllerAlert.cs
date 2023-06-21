using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using CatVentari.Utilitats;
using System.Security;

namespace CatVentari.Controlador
{
    internal class ControllerAlert
    {
        /*
        * Send email to user
        * @param reference
        * @param name
        * @param version install
        * @param version avaibability
        * @param email  
        */
        internal static void sendAlertToEmail(TextBox textAlertaReferencia, TextBox textAlertaProducteLogicNom, TextBox textAlertaProducteLogicVersioInstalada, TextBox textAlertaProducteLogicVersioDisponible, string correuElectronicClient)
        {
            // Data Email Catventari
            string emailCatventari = "holacatventari@gmail.com";

            // SecureString String in memory
            SecureString password = ConfigReader.ReadPassword();

            // Ejemplo de uso: convertir la contraseña a un string seguro para mostrarla
            String passwordEmailCatventari = new NetworkCredential(string.Empty, password).Password;

            // Delete password in memory
            password.Dispose();

            try
            {
                // Configure SMTP
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(emailCatventari, passwordEmailCatventari);

                // Create message
                MailMessage message = createAlertMessage(emailCatventari,
                    correuElectronicClient,
                    textAlertaProducteLogicNom.Text,
                    textAlertaReferencia.Text,
                    textAlertaProducteLogicVersioInstalada.Text,
                    textAlertaProducteLogicVersioDisponible.Text);

                // Send
                client.Send(message);

                // Record
                ControllerFileLog.recordFileLog("Enviat correu electrónic a " + correuElectronicClient);

                // Show
                Utilitats.MessageBox.informationMessageBox("Correu electronic enviat!");
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Al enviar el correu electrònic a:  " + correuElectronicClient + " amb error " + ex.Message);
            }
        }
        /* Create Email message
         * @param fromEamil
         * @param toEmail
         * @param name product
         * @param version install
         * @param version avaibability
         */
        private static MailMessage createAlertMessage(string fromEmail, string toEmail, string productName, string reference, string versionInstall, string versionAvaibability)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(toEmail);
            message.Subject = "Versió pendent d'actualització";
            message.Body = $"NOTIFICACIÓ: El producte {productName} amb referencia {reference} té la versió {versionInstall} i teniu disponible la versió {versionAvaibability}";

            return message;
        }

        /* Load data
         * @param name
         * @param version
         * @param 
        */
        internal static void showDataAlert(TextBox textName, TextBox textVersion, List<string> responseServer)
        {
            textName.Text = responseServer[2];
            textVersion.Text = responseServer[5];
        }

        /*  
        * search if verion avaibability
        * @param Reference
        * @param Object sessionComunicationData  
        * @param operation
        * @return responseServer 
        */
        internal static List<string> searchVersionAvaibility(TextBox textReferencia, object[] sessionCommunicationData, string operation)
        {
            // Manage Search
            List<string> responseServer = ControllerProducteLogic.managementSearchOrDelete(textReferencia,
                sessionCommunicationData,
                operation);

            ControllerFileLog.resultVersionAvaibility(responseServer);

            return responseServer;
        }
    }
}
