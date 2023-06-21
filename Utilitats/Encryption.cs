using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Utilitats
{
    public class Encryption
    {
        /*
         * Encrypted 
         * @param message to decrypted
         * @return message decrypted
         * */

        public static string messageDecrypted(string message)
        {
            char[] textEncrypted = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                char codiCharacter = message[i];
                if (codiCharacter >= 33 && codiCharacter <= 126)
                {
                    codiCharacter = (char)(((int)codiCharacter - 33 + 47) % 94 + 33);
                }
                textEncrypted[i] = codiCharacter;
            }
            return new string(textEncrypted);
        }

        /*
         * Decrypted
         * @param message to encrypted
         * @return mesage encrypted
         * 
         */
        public static string messageEncrypted(string message)
        {
            char[] textEncrypted = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                char codiCharacter = message[i];
                if (codiCharacter >= 33 && codiCharacter <= 126)
                {
                    codiCharacter = (char)(((int)codiCharacter - 33 + 47) % 94 + 33);
                }
                textEncrypted[i] = codiCharacter;
            }
            return new string(textEncrypted);

        }
    }
}
