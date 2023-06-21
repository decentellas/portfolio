using CatVentari.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CatVentari.Utilitats
{
    internal class Validation
    {
        /* 
         * Check prodcut Fisic
         * @param product  
         * @return if validation i correct    
         * 
         */
        internal static bool validationProductFisic(ProducteFisic productFisic)
        {                    
                String messageError = string.Empty;

                Boolean isEmpty = (string.IsNullOrEmpty(productFisic.referencia) ||
                    string.IsNullOrEmpty(productFisic.nom) ||
                    string.IsNullOrEmpty(productFisic.tipus) ||
                    string.IsNullOrEmpty(productFisic.quantitat));

                if (isEmpty)
                {
                    Utilitats.MessageBox.errorMessageBox("ERROR: Hi ha almenys una casella per complimentar");
                    return false;
                }

                decimal price;
                if (!decimal.TryParse(productFisic.preu.ToString(), out price) || !Regex.IsMatch(price.ToString(), @"^\d+(\.\d{1,2})?$"))
                {
                    Utilitats.MessageBox.errorMessageBox("ERROR: La casella PREU no és un número vàlid");
                    return false;
                }

                int validNumber;
                if (!int.TryParse(productFisic.quantitat, out validNumber))
                {
                    Utilitats.MessageBox.errorMessageBox("ERROR: La casella Quantitat no té un número vàlid");
                    return false;
                }

                return true;       
         }

        /* 
        * Check TextBox is empty
        * @param TextBox
        * @return if validation is correct    
        * 
        */

        internal static bool isNotEmpty(string textBoxCheck)
        {

            if (string.IsNullOrEmpty(textBoxCheck))
            {
                MessageBox.errorMessageBox("ERROR: Has d´introduir una dada");
                return false;
            }

            return true;
        }
        /* 
        * Check product Logic
        * @param product  
        * @return if validation i correct    
        * 
        */
        internal static bool validationProductLogic(ProducteLogic producteLogic)
        {
            String messageError = string.Empty;

            Boolean isEmpty = (string.IsNullOrEmpty(producteLogic.referencia) || 
                string.IsNullOrEmpty(producteLogic.nom) || 
                string.IsNullOrEmpty(producteLogic.tipus) ||
                string.IsNullOrEmpty(producteLogic.versio) || 
                string.IsNullOrEmpty(producteLogic.quantitat) || 
                string.IsNullOrEmpty(producteLogic.dataCaducitat));

            if (isEmpty) 
            {
                MessageBox.errorMessageBox("ERROR: Hi ha almenys una casella per complimentar");
                return false;
            }

            decimal price;
            if (!decimal.TryParse(producteLogic.preu.ToString(), out price) || !Regex.IsMatch(price.ToString(), @"^\d+(\.\d{1,2})?$"))
             {
                MessageBox.errorMessageBox("ERROR: La casella PREU no és un número vàlid");
                return false;                    
            }

            DateTime validDate;
            if (!DateTime.TryParseExact(producteLogic.dataCaducitat, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out validDate))
            {
                MessageBox.errorMessageBox("ERROR: La casella Data de Caducitat no té una data correcte DD-MM-YYYY");    
                return false;                   
            }

            int validNumber;
            if (!int.TryParse(producteLogic.quantitat, out validNumber))
            {
                MessageBox.errorMessageBox("ERROR: La casella Quantitat no té un número vàlid");
                return false;
            }  

            return true;
        }

        public static bool validationUser(Usuari user)        {

            String messageError = string.Empty;

            Boolean isEmpty = (string.IsNullOrEmpty(user.nom) ||
                string.IsNullOrEmpty(user.contrasenya) ||
                string.IsNullOrEmpty(user.repetirContrasenya) ||
                string.IsNullOrEmpty(user.correu) ||
                string.IsNullOrEmpty(user.rol) ||
                string.IsNullOrEmpty(user.cognoms));               

            if (isEmpty)
            {                
                return false;
            }          

            // Validation Email
            if (string.IsNullOrEmpty(user.correu) || !Regex.IsMatch(user.correu, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: El correu electrònic no és vàlid");              
                return false;
            }

            // Validation Passwords 
            if (!string.Equals(user.contrasenya, user.repetirContrasenya))
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: Les contrasenyes no coincideixen");
                return false;
            }

            // Validation Rol
            if (!string.Equals(user.rol, "Usuari", StringComparison.OrdinalIgnoreCase) && !string.Equals(user.rol, "Administrador", StringComparison.OrdinalIgnoreCase))
            {
                Utilitats.MessageBox.errorMessageBox("ERROR: El rol ha de ser 'Usuari' o 'Administrador'"); 
                return false;
            }

            // Validation format password
            if (user.contrasenya.Length < 8 || !Regex.IsMatch(user.contrasenya, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$"))
            {
                Utilitats.MessageBox.errorMessageBox("La contrasenya hauria de tenir almenys 8 caràcters, una majúscula, una minúscula, un número y un caràcter especial");              
                return false;
            }
            return true;
        }
    }

}
