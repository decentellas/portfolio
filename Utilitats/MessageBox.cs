using CatVentari.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Utilitats
{
    public class MessageBox
    {
        /*
        * MessageBox error
        * @param message        
        */
        public static void errorMessageBox(string messageError)
        {
            System.Windows.Forms.MessageBox.Show(messageError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*
        * MessageBox information
        * @param message        
        */
        internal static void informationMessageBox(string messageInformation)
        {
            System.Windows.Forms.MessageBox.Show(messageInformation, "INFORMACIÓ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
        * MessageBox result operation
        * @param response Server      
        */
        internal static void showResultOperation(List<String> responseServer)
        {

            if (responseServer.Equals("0"))
            {
                Utilitats.MessageBox.informationMessageBox("INFORMACIÓ: Operació realitzada correctament");
            }
            else
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: Durant la transmissió/gravació en la BBDD " + responseServer[1]);
            }
        }
        /*
        * MessageBox show if Error
        * @param response Server        
        */
        internal static void showResultNotFound(List<String> responseServer)
        {
            if (responseServer[0].Equals("-1"))
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: " + responseServer[1]);
            }
        }

        /*
        * MessageBox question
        * @param message      
        */
        internal static void questionMessageBox(String message)
        {
            if (System.Windows.Forms.MessageBox.Show(message, "Opció Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ControllerSession.exitApplication();
            }
        }

        /*
         * MessageBox question close sesion
         * @param Form active
         * @return confirm close session
         */
        public static Boolean questioncloseSession(Form formulariActiu)
        {
            if (System.Windows.Forms.MessageBox.Show("Estàs segur que vols tancar la sessió? Confírmeu ", "Opció Tancar la sessió", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                formulariActiu.Close();
                FormLogin menuLogin = new FormLogin();
                menuLogin.Show();

                return true;
            }
            return false;
        }
    }
}
