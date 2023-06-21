using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CatVentari.Controlador
{
    public class ControllerReport
    {

        /*
        * 
        * Report Connections Right by User
        * @param Search Name       
        * @return number connections
        * 
        */
        public static int reportConnectionsUser(TextBox textSearchUsername)
        {
            int correctConnectionsCounter = 0;
            string line = null;

            StreamReader sr = ControllerFileLog.openFileLog();

            while ((line = sr.ReadLine()) != null)
            {
                string[] columns = line.Split(';');

                if (columns[0] == textSearchUsername.Text)
                {
                    correctConnectionsCounter++;
                }
            }

            return correctConnectionsCounter;
        }

        /*
        * 
        * Report number transmission encrypted / decrypted
        * @param Search name
        * @return number transmission
        */
        public static int[] reportEncryptedTransmission(TextBox textSearchUsername)
        {
            int[] encryptedTransmissionCount = null;
            int encryptedSendingCount = 0;
            int encryptedResponseCount = 0;
            string activeUser = null;
            string line = null;

            StreamReader sr = ControllerFileLog.openFileLog();

            while ((line = sr.ReadLine()) != null)
            {
                string[] columns = line.Split(';');

                if (!string.IsNullOrWhiteSpace(columns[0]))
                {
                    activeUser = columns[0];
                }

                if ((columns[3].Contains("Cadena xifrada")) && (activeUser == textSearchUsername.Text))
                {
                    encryptedSendingCount++;
                }

                if ((columns[3].Contains("Resposta xifrada")) && (activeUser == textSearchUsername.Text))
                {
                    encryptedResponseCount++;
                }
            }

            // Prepare for return
            encryptedTransmissionCount[0] = encryptedSendingCount;
            encryptedTransmissionCount[1] = encryptedResponseCount;

            return encryptedTransmissionCount;
        }

        /*
        * 
        * Report products
        * @param Search name
        * @param operation (PRODUCTES LOGICS or PRODUCTES FISICS)
        * @return number actions (error,query,creation,delete,modification)
        */

        public static int[] reportProducts(TextBox textSearchUsername, string operation)
        {
            int actionsCounter = 0;
            int errorCounter = 0;
            int queryCounter = 0;
            int creationCounter = 0;
            int deletionCounter = 0;
            int modificationCounter = 0;
            string activeUser = null;
            string line = null;

            int[] actionsProducts = null;


            // Open
            StreamReader sr = ControllerFileLog.openFileLog();

            while ((line = sr.ReadLine()) != null)
            {
                string[] columns = line.Split(';');

                if (!string.IsNullOrWhiteSpace(columns[0]))
                {
                    activeUser = columns[0];
                }

                // Case PRODUCTE_LOGIC
                if (operation.Equals("PRODUCTE_LOGIC"))
                {
                    if ((columns[3].Contains("producte logic")) && (activeUser == textSearchUsername.Text))
                    {
                        actionsCounter++;

                        if (columns[3].Contains("ERROR"))
                        {
                            errorCounter++;
                        }
                        else if (columns[3].Contains("Consulta producte logic"))
                        {
                            queryCounter++;
                        }
                        else if (columns[3].Contains("Alta producte logic"))
                        {
                            creationCounter++;
                        }
                        else if (columns[3].Contains("Baixa producte logic"))
                        {
                            deletionCounter++;
                        }
                        else if (columns[3].Contains("Modificacio del producte logic"))
                        {
                            modificationCounter++;
                        }
                    }

                    // CASE PRODUCTE_FISIC
                    if (operation.Equals("PRODUCTE_FISIC"))
                    {

                        if ((columns[3].Contains("producte fisic")) && (activeUser == textSearchUsername.Text))
                        {

                            actionsCounter++;

                            if (columns[3].Contains("ERROR"))
                            {
                                errorCounter++;
                            }
                            else if (columns[3].Contains("Consulta producte fisic"))
                            {
                                queryCounter++;
                            }
                            else if (columns[3].Contains("Alta producte fisic"))
                            {
                                creationCounter++;
                            }
                            else if (columns[3].Contains("Baixa producte fisic"))
                            {
                                deletionCounter++;
                            }
                            else if (columns[3].Contains("Modificacio producte fisic"))
                            {
                                modificationCounter++;
                            }
                        }

                    }

                }


            }

            // Assign
            actionsProducts[0] = actionsCounter;
            actionsProducts[1] = creationCounter;
            actionsProducts[2] = deletionCounter;
            actionsProducts[3] = modificationCounter;
            actionsProducts[4] = queryCounter;
            actionsProducts[5] = errorCounter;

            return actionsProducts;
        }

        // Show Connections User Right
        /*
         * @param counter connections
         * @param TextBox connections right
         */
        internal static void showConnectionsUser(int counterReportConnectionsUser, TextBox textReportConnectionsUser)
        {
            textReportConnectionsUser.Text = counterReportConnectionsUser.ToString();
        }
   
         // Show Data Transmission
         /*
         * @param number Transmission
         * @param encryptedSendind
         * @param encrytedResponse
         */
        internal static void showEncryptedTransmission(int[] encryptedTransmissionCount, TextBox encryptedSending, TextBox encryptedResponse)
        {
            // Show
            encryptedResponse.Text = encryptedTransmissionCount[1].ToString();
            encryptedSending.Text = encryptedTransmissionCount[0].ToString();
        }

        // Show Actions Productsparam 
        /*
         * @param actionsProducts
         * @param TextBox create
         * @param TextBox Delete
         * @param TextBox Query
         * @param TextBox Update
         * @param Textbox Error
         * @param TextBox Total Actions
         */

        internal static void showActionsProducts(int[] actionsProducts, TextBox textCreate, TextBox textDelete, TextBox textQuery, TextBox textUpdate, TextBox textError, TextBox textAction)
        {


            // Assign
            textAction.Text = actionsProducts[0].ToString();
            textCreate.Text = actionsProducts[1].ToString();
            textDelete.Text = actionsProducts[2].ToString();
            textUpdate.Text = actionsProducts[3].ToString();
            textQuery.Text = actionsProducts[4].ToString();
            textError.Text = actionsProducts[5].ToString();
        }
    }
}
