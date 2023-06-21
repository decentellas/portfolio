using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Utilitats
{
    internal class PanelManager
    {
        /* Hide all panels
         * @param panel
        */
        internal static void hidePanelSubMenu(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
        }
        /* Show panel
        * @param panel
        */
        internal static void showPanelSubMenus(Panel panel)
        {
            panel.Visible = true;
            panel.BringToFront();
        }
        /*
        * Close all control to panl
        * @param panel
        * 
        */
        internal static void formClosetoPanel(Panel panelActive)
        {
            foreach (Control control in panelActive.Controls)
            {
                control.Visible = false;
            }
        }

        /*
        * Active panel 
        * @param panel
        * 
        */
        public static void ShowSubMenu(Panel panelSubMenu)
        {
            if (!panelSubMenu.Visible)
            {
                panelSubMenu.BringToFront();
                panelSubMenu.Visible = true;
            }
            else
                panelSubMenu.Visible = false;
        }
    }
}
