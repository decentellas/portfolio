using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Controlador
{
    internal class ControllerTaula
    {
        /*
        * Management operation CRUD 
        * @param panel
        * @param Button for name it
        * @param Button create
        * @param Button update
        * @param Button query
        * @param Button delete
        * 
        */
        internal static void showPanelSubMenuTaula(Panel panelSubMenuCRUD, Button bSubMenuTaulaOperacio, Button bSubMenuTaulaAlta, Button bSubMenuTaulaModificacio, Button bSubMenuTaulaConsulta, Button bSubMenuTaulaBaixa)
        {
            // Show
            PanelManager.showPanelSubMenus(panelSubMenuCRUD);
     
            // Enable
            ToggleSwitch.enableButton(bSubMenuTaulaAlta,
                 bSubMenuTaulaModificacio,
                 bSubMenuTaulaConsulta,
                 bSubMenuTaulaBaixa);
        }
    }
}
