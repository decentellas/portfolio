using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatVentari.Model;
using CatVentari.Utilitats;

namespace CatVentari.Controlador
{
    public class ControllerSocket
    {
    /* 
    * Open
    * @throws SocketException
    * @throws Exception,
    */
        public static Socket openSocket()
        {
            try
            {
                // Configure
                int port = 9090;
                string ipServidor = "10.0.14.109";

                IPAddress iPAddress = IPAddress.Parse(ipServidor);

                IPEndPoint server= new IPEndPoint(iPAddress, port);

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(server);             

                return clientSocket;
            }
            catch (SocketException ex)
            {
                ControllerErrors.managementError("ERROR: Durant la comunicació amb el socket: " + ex.Message);                         
                return null;
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Excepcio " + ex.Message);
                return null;
            }
        }
              
        /*
        * Close
        * @param socket
        * @throws SocketException
        * @throws Exception
        * 
        */
        public static Boolean closeSocket(Socket socketActive)
        {
            try
            {
                // Close
                socketActive.Shutdown(SocketShutdown.Both);
                socketActive.Close();
                return true;

            }
            catch (SocketException ex)
            {
                ControllerErrors.managementError("ERROR: Socket Exception " + ex.Message);
                return false;
                
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Excepcio " + ex.Message);
                return false;
            }
        }
      
         /* Send Operation Encrypted get decrypted response server
         * @param socket
         * @param operation
         * @return response server
         */

        public static List<String> sendDencryptedOperationGetDecryptedServerResponse(Socket socket, string dataFormatDecryted)
        {
            // Encrypted
            String dataFormatEncrypt = Encryption.messageEncrypted(dataFormatDecryted);

            // Record log file
            ControllerFileLog.recordFileLog("Cadena xifrada: " + dataFormatEncrypt);

            // Send chain to socket. Wait response
            String responseServerEncrypted = ModelSocket.socketCommunication(socket, dataFormatEncrypt);

            // Record log file
            ControllerFileLog.recordFileLog("Resposta xifrada: " + responseServerEncrypted);

            // Decrypted
            String responseServerDecrypted = Encryption.messageDecrypted(responseServerEncrypted);

            // Divide return
            return FormatDBString.responseFormatServer(responseServerDecrypted);
        }
    }
}
