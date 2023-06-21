
namespace CatVentari.Controlador
{
    internal class ControllerErrors
    {
        // Operation to Record file and show messageBox
        // @param message
        internal static void managementError(string message)
        {
            Utilitats.MessageBox.errorMessageBox(message);
            ControllerFileLog.recordFileLog(message);
        }
    }
}
