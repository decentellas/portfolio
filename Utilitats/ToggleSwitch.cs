using APP_Catventari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Utilitats
{
    internal class ToggleSwitch
    {
        /*
         * Change state Button
         * @param button to change
         */
        internal static void changeStateButton(Button btnStatusChange)
        {
            if (btnStatusChange.Enabled)
            {
                btnStatusChange.Enabled = false;
            }
            else
            {
                btnStatusChange.Enabled = true;
            }
        }
        /*
        * Button disable
        * @param buttons to disable
        */
        internal static void disableButton(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }
        /*
        * Button disable with control
        * @param button to disable
        * @param response Server
        */
        internal static void disableButtonWithControl(Button buttonDisabled, string isFound)
        {
            if (isFound.Equals("0"))
            {
                buttonDisabled.Enabled = false;
            }
        }
        /*
        * Button enable
        * @param buttons to enable
        */
        internal static void enableButton(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
        }
        /*
        * Button enable with control
        * @param button to enable
        * @param response server
        */
        internal static void enableButtonWithControl(Button buttonEnabled, string isFound)
        {
            if (isFound.Equals("0"))
            {
                buttonEnabled.Enabled = true;
            }
        }
        /*
        * Textbox disable
        * @param TextBox to disable
        */
        internal static void disableTextBox(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = false;
            }
        }

        /*
        * Change state combo
        * @param Combo to state
        */
        internal static void changeStateCombo(ComboBox comboStatusChange)
        {
            if (comboStatusChange.Enabled)
            {
                comboStatusChange.Enabled = false;
            }
            else
            {
                comboStatusChange.Enabled = true;
            }
        }
    }
}
