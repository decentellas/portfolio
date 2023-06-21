using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace CatVentari.Utilitats
{
    internal class TextBoxManager
    {
        /*
         * Characters hiden
         * @param TextBox to hiden
         * 
         */
        internal static void setTextBoxHiddenCharacters(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.PasswordChar = '*';
            }
        }
    }
}
