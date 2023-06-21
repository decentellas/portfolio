using APP_Catventari;
using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using System.IO;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CatVentari.Utilitats
{
    internal class Initialize
    {
        /*
        * Empty TextBox
        * @param TextBoxes  
        */
        public static void emptyTextBox(params TextBox[] textBoxes)
        {
            string firstTextBoxValue = string.Empty;

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = firstTextBoxValue;
            }
        }

        /*
          * Empty TextBox
          * @param response Server
          * @param TextBoxes  
          */
        public static void emptyTextBoxWithControl(String responseServer, params TextBox[] textBoxes)
        {
            string firstTextBoxValue = string.Empty;

            if (responseServer.Equals("0"))
            {
                foreach (TextBox textBox in textBoxes)
                {
                    textBox.Text = firstTextBoxValue;
                }
            }
        }
        /*
        * Empty TextBox and Init Combo
        * @param TextBoxes
        * @param Combo Rol           
        */
        public static void emptyTextBoxAndCombo(ComboBox comboRol, params TextBox[] textBoxes)
        {
            string firstTextBoxValue = string.Empty;
            comboRol.SelectedIndex = 0;

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = firstTextBoxValue;
            }
        }

        /*
        * Empty TextBox and Init Combo
        * @param Combo Rol  
        * @param responseServer
        * @param TextBoxes            
        */
        public static void emptyTextBoxAndComboWithControl(ComboBox comboRol, String responseServer, params TextBox[] textBoxes)
        {
            string firstTextBoxValue = string.Empty;

            if (responseServer.Equals("0"))
            {
                comboRol.SelectedIndex = 0;

                foreach (TextBox textBox in textBoxes)
                {
                    textBox.Text = firstTextBoxValue;
                }
            }
        }

        /*
         * TextBox Init
         * @param TextBox Name      
         */
        public static void waitingReponseServerTextBox(params TextBox[] textBoxes)
        {
            const string WAITING_SERVER = "ESPERANT...";
            string firstTextBoxValue = string.Empty;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                TextBox textBox = textBoxes[i];

                if (i == 0)
                {
                    textBox.Text = firstTextBoxValue;
                }
                else
                {
                    textBox.Text = WAITING_SERVER;
                }
            }
        }

        /*
        * TextBox Init
        * @param response Server
        * @param TextBox Name      
        */
        public static void waitingReponseServerTextBoxWithControl(String responseServer, params TextBox[] textBoxes)
        {
            const string WAITING_SERVER = "ESPERANT...";
            string firstTextBoxValue = string.Empty;

            if (responseServer.Equals("0"))
            {
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    TextBox textBox = textBoxes[i];

                    if (i == 0)
                    {
                        textBox.Text = firstTextBoxValue;
                    }
                    else
                    {
                        textBox.Text = WAITING_SERVER;
                    }
                }
            }
        }

        /*
        * TextBox Initparam Combo
        * @param Combo
        * @param TextBoxes      
        */
        public static void waitingReponseServerTextBoxWithCombo(ComboBox comboRol, params TextBox[] textBoxes)
        {
            const string WAITING_SERVER = "ESPERANT...";
            string firstTextBoxValue = string.Empty;

            comboRol.SelectedIndex = 0;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                TextBox textBox = textBoxes[i];

                if (i == 0)
                {
                    textBox.Text = firstTextBoxValue;
                }
                else
                {
                    textBox.Text = WAITING_SERVER;
                }
            }
        }

        /*
         * TextBox Initparam Combo
         * @param Combo
         * @param response Server
         * @param TextBoxes      
        */
        public static void waitingResponseServerTextBoxWithComboWithControl(ComboBox comboRol, String responseServer, params TextBox[] textBoxes)
        {
            const string WAITING_SERVER = "ESPERANT...";
            string firstTextBoxValue = string.Empty;

            if (responseServer.Equals("0"))
            {
                comboRol.SelectedIndex = 0;

                for (int i = 0; i < textBoxes.Length; i++)
                {
                    TextBox textBox = textBoxes[i];

                    if (i == 0)
                    {
                        textBox.Text = firstTextBoxValue;
                    }
                    else
                    {
                        textBox.Text = WAITING_SERVER;
                    }
                }
            }
        }
    }
}
