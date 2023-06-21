using CatVentari.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Model
{
    public class ModelSocket
    {
        /*
        * Communication socket
        * @param socket
        * @param text
        * @return respone server
        * @throws ArgumentNullException
        * @throws ArgumentException,
        * @throws SocketException 
        * @throws IOException,
        * @throws ObjectDisposedException
        * @throws TimeoutException
        * 
        */
        public static string socketCommunication(Socket socketActive, string text)
        {
            try
            {
                
                NetworkStream ns = new NetworkStream(socketActive);

                // Send
                byte[] textByte = Encoding.UTF8.GetBytes(text);
                ns.Write(textByte, 0, textByte.Length);

                // Receive data
                byte[] responseBuffer = new byte[1024];
                int bytesReadToken = socketActive.Receive(responseBuffer);
                string responseServerEncrypted= Encoding.UTF8.GetString(responseBuffer, 0, bytesReadToken);

                return responseServerEncrypted;
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Comunicació socket: " + ex.Message);
                return null;
            }
        }
    }
}
