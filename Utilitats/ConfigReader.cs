using CatVentari.Controlador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;


namespace CatVentari.Utilitats
{
    internal class ConfigReader
    {

        // Get password EMAIL
        /*
         * @retun password decrypted
         * @throws FileNotFoundException
         * @throws Exception
         * 
         */

        public static SecureString ReadPassword()
        {
            var securePassword = new SecureString();
            string filePath = "C:\\CatventariLogs\\Catventariconfig.txt";

            try
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        foreach (char c in line)
                        {
                            securePassword.AppendChar(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ControllerErrors.managementError($"Error al leer la contraseña: {ex.Message}");
            }

            return securePassword;
        }
    }








}
