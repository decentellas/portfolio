using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace CatVentari.Controlador
{
    public static class ControllerFileLog
    {
        /*
        * Record file log 
        * @param message to record
        * @throws UnauthorizedAccessException
        * @throws DirectoryNotFoundException
        * @throws IOException
        * @throws ArgumentNullException
        * @throws Exception
        */
        public static void recordFileLog(string message)
        {
            String messageError = String.Empty;
            try
            {
                // Default route
                string directoriLog = "C:\\CatventariLogs\\";
                string path = Path.Combine(directoriLog, "Catventari.log");

                // Create if 
                Directory.CreateDirectory(directoriLog);

                // Open
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    // Format                    
                    string messageLog = $"{string.Empty};{string.Empty};{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")};{message}";
                    writer.WriteLine(messageLog);
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                ControllerErrors.managementError("ERROR: Accés no autoritzat: " + ex.Message);

            }
            catch (DirectoryNotFoundException ex)
            {
                ControllerErrors.managementError("ERROR: Directori no trobat: " + ex.Message);

            }
            catch (IOException ex)
            {
                ControllerErrors.managementError("ERROR: D´entrada / salida: " + ex.Message);

            }
            catch (ArgumentNullException ex)
            {
                ControllerErrors.managementError("ERROR: Argument nul: " + ex.Message);
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Inesperat: " + ex.Message);
            }
        }


        /*
        * Record File Log with idUser and rol
        * @param name
        * @param rol
        * @param message 
        * @throws Exception: UnauthorizedAccessException
        * @throws Exception: DirectoryNotFoundException
        * @throws Exception: IOException 
        * @throws Exception: ArgumentNullException
        * @throws Exception: Exception  
        */
        public static void recordFileLogStart(string idUser, string rol, string message)
        {
            String messageError = String.Empty;

            try
            {
                // Default route
                string directoriLog = "C:\\CatventariLogs\\";
                string path = Path.Combine(directoriLog, "Catventari.log");

                // Create if
                Directory.CreateDirectory(directoriLog);

                // Open
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    // Write
                    string messageLog = $"{idUser};{rol};{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")};{message}";
                    writer.WriteLine(messageLog);
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                ControllerErrors.managementError("ERROR: de acces no autoritzat: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                ControllerErrors.managementError("ERROR: Directori no trobat: " + ex.Message);
            }
            catch (IOException ex)
            {
                ControllerErrors.managementError("ERROR d´entrada / salida: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                ControllerErrors.managementError("ERROR: Argument null " + ex.Message);
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError("ERROR: Inesperat " + ex.Message);
            }
        }

        /*
        * Open File Log     
        * @return StreamReader
        * @throws Exception: FileNotFoundException
        * @throws Exception: DirectoryNotFoundException
        * @throws Exception: IOException 
        * @throws Exception: UnauthorizedAccessException
        */
        public static StreamReader openFileLog()
        {
            try
            {
                // Ruta arxiu del Log
                string path = @"c:\CatventariLogs\Catventari.log";

                // Obrim arxiu Log
                return new StreamReader(path);
            }
            catch (FileNotFoundException e)
            {
                ControllerErrors.managementError("ERROR: L´arxiu no ha trobat la ruta especificada: " + e.Message);
                return null;

            }
            catch (DirectoryNotFoundException e)
            {
                ControllerErrors.managementError("ERROR: La ruta especificada no s´ha trobat : " + e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                ControllerErrors.managementError("ERROR: Problema de permissos per accedir a l´arxiu: " + e.Message);
                return null;
            }
            catch (IOException e)
            {
                ControllerErrors.managementError("ERROR: Error de E/S a obrir l´arxiu: " + e.Message);
                return null;
            }
        }

        /*
        * Read all line to FileLog
        * @param StreamReader
        * @return List lines
        */
        public static List<string> linesFileLog(StreamReader sr)
        {
            List<string> lines = new List<string>();
            string lineaFile;
            while ((lineaFile = sr.ReadLine()) != null)
            {
                lines.Add(lineaFile);
            }
            return lines;
        }

        /*
        * Open FileLog invers       
        * @param List lines File Log
        * @param DataGrip for fill  
        */
        public static void dataGridShowInvers(List<string> lines, DataGridView dataGridViewLog)
        {
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                // Formatem
                string[] columns = lines[i].Split(';');

                // Agreguem nova fila al DataGridView 
                dataGridViewLog.Rows.Add(columns[0], columns[1], columns[2], columns[3]);
            }
        }

        /*
        * Fill dataGrio     
        * @param List klines
        * @param DataGrip to fill  
        */
        public static void dataGridShow(StreamReader sr, DataGridView dataGridViewLog)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] columns = line.Split(';');

                // Add file 
                dataGridViewLog.Rows.Add(columns[0], columns[1], columns[2], columns[3]);
            }
        }

        /*
        * Close Log 
        * @param StreamReader
        * @throws FileNotFoundException 
        * @throws ArgumentNullException 
        * @throws SecurityException  
        * @throws IoException
        */
        public static void closeFileLog(StreamReader sr)
        {
            try
            {
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                ControllerErrors.managementError("ERROR: L´arxiu no ha trobat la ruta especificada: " + e.Message);

            }
            catch (ArgumentNullException e)
            {
                ControllerErrors.managementError("ERROR: L´objecte es nul: " + e.Message);
            }
            catch (SecurityException e)
            {
                ControllerErrors.managementError("ERROR: Exepció de seguretat: " + e.Message);
            }
            catch (IOException e)
            {
                ControllerErrors.managementError("ERROR: Execpció de E/S al obrir l´arxiu: " + e.Message);
            }
        }

        /*
       * Management all methodes for DataGrip invers
       * @param DataGridView
       */
        public static void showFileLogDown(DataGridView dataGridViewLog)
        {

            dataGridViewLog.Rows.Clear();

            // Open
            StreamReader sr = ControllerFileLog.openFileLog();

            // Add to list
            List<string> lines = ControllerFileLog.linesFileLog(sr);

            // List invers
            ControllerFileLog.dataGridShowInvers(lines, dataGridViewLog);

            //sr.Close();
            ControllerFileLog.closeFileLog(sr);
        }


        /*
        * Management all methodes for DataGrip normal
        * @param DataGridView
        */
        public static void showFileLogUp(DataGridView dataGridViewLog)
        {
            dataGridViewLog.Rows.Clear();
            // Open
            StreamReader sr = ControllerFileLog.openFileLog();

            // how
            ControllerFileLog.dataGridShow(sr, dataGridViewLog);

            // Close
            ControllerFileLog.closeFileLog(sr);
        }

        /*
         * Management respponse server. Record file Log
         * @param response server
         */
        internal static void resultVersionAvaibility(List<string> responseServer)
        {
            if (responseServer[0].Equals("0"))
            {
                // Gravem registe
                ControllerFileLog.recordFileLog("Versió disponible més moderna: " + responseServer[1]);
            }
            else
            {
                // Gravem registre
                ControllerFileLog.recordFileLog("No hi ha disponible una versió més actualitzada: " + responseServer[1]);
            }
        }
        /*
        * Management respponse server. Record file Log
        * @param response server
        */

        internal static void recordOperationLog(string responseServer, string text)
        {
            if (responseServer.Equals("0"))
            {
                // Record log file
                ControllerFileLog.recordFileLog(text);
            }
            else
            {
                // Record log file
                ControllerFileLog.recordFileLog("ERROR: " + text);
            }
        }

    }
}
