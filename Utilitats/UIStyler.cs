using APP_Catventari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Utilitats
{
    internal class UIStyler
    {
        /*
         * Draw button back color blue
         * @param Buttons   
         */
        internal static void changeButtonBackColorBlue(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.BackColor = Colors.colorLogoBlue;
            }
        }

        /*
        * Draw button back color gray
        * @param Buttons   
         */
        internal static void changeButtonBackColorGray(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.BackColor = Colors.colorButtonGray;
            }
        }
        /*
        * Draw button back color yellow
        * @param Buttons   
        */
        internal static void changeButtonBackColorYellow(Button button)
        {
            button.BackColor = Colors.colorLogoYellow;
        }
        /*
        * Draw button fore color Yellow
        * @param button
        */
        internal static void changeButtonForeColorYellow(Button button)
        {
            button.ForeColor = Colors.colorLogoYellow;
        }
        /*
        * Draw panel back color Yellow
        * @param panel
        */
        internal static void changePanelBackColorYellow(Panel panel)
        {
            panel.BackColor = Colors.colorLogoYellow;
        }

        /*
        * Draw form back color Gray
        * @param form        
        */
        internal static void changeFormBackColorGray(FormLogin formLogin)
        {
            formLogin.BackColor = Colors.colorLogoGray;

        }
        /*
        * Draw form back color Gray
        * @param Buttons      
        */
        internal static void changeButtonForeColorBlack(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.ForeColor = System.Drawing.Color.Black;
            }
        }
        /*
        * Configure label report
        * @param label encrypted
        * @param label decrypted
        */
        internal static void configureLabelReport(Label labelEncrypted, Label labelDecrypted)
        {
            labelEncrypted.Text = "Xifratge " + '\u2192';
            labelDecrypted.Text = "Xifratge " + '\u2190';
        }
    }
}
