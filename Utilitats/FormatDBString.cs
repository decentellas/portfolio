using CatVentari.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Utilitats
{
    internal class FormatDBString
    {

        const string CONTROL_START_SESSION = "LOGIN";
        const string CONTROL_CLOSE_SESSION = "LOGOUT";

        /*
        * Create format chain to Product Logic new
        * @param token
        * @param operation CRUD
        * @param producte
        * @return chain format  
        * 
        */
        internal static string formatChainProductLogicNew(string token, string operation, ProducteLogic producteLogic)
        {
            return token + ";" + operation + ";" + producteLogic.referencia + ";" + producteLogic.nom +
              ";" + producteLogic.tipus + ";" + producteLogic.preu + ";" + producteLogic.versio + ";" + producteLogic.quantitat + ";" + producteLogic.dataCaducitat;
            ;
        }

        /*
        * Create format chain to Search or Delete
        * @param token
        * @param operation CRUD
        * @param producte
        * @return chain format  
        * 
        */
        internal static string formatChainSearchDelete(string token, string operation, string wordSearch)
        {
            return token + ";" + operation + ";" + wordSearch;
        }

        /*
        * Create format chain to Login user
        * @param user
        * @param password
        * @return chain format  
        * 
        */
        public static string formatChainLogin(string user, string password)
        {
            return CONTROL_START_SESSION + ";" + user + ";" + password;
        }


        /*
        * Create format chain to Product Logic update
        * @param token
        * @param operation CRUD
        * @param product
        * @return chain format         
        */
        internal static string formatChainProductLogicUpdate(string token, string operation, ProducteLogic producteLogic)
        {

            return token + ";" + operation + ";" + producteLogic.nom + ";" + producteLogic.tipus +
                ";" + producteLogic.preu + ";" + producteLogic.versio + ";" + producteLogic.quantitat + ";" + producteLogic.dataCaducitat + ";" + producteLogic.referencia;
        }

        /*
        * Create format chain to Product Fisic new
        * @param token
        * @param operation CRUD
        * @param product
        * @return chain format  
        * 
        */
        internal static string formatChainProductFisicNew(string token, string operation, ProducteFisic productFisic)
        {
            return token + ";" + operation + ";" + productFisic.referencia + ";" + productFisic.nom +
                ";" + productFisic.tipus + ";" + productFisic.preu + ";" + productFisic.quantitat;
        }

        /*
        * Create format chain to User new
        * @param token
        * @param operation CRUD
        * @param user
        * @return chain format              
        */
        public static string formatChainUserNew(string token, string operation, Usuari user)
        {
            return token + ";" + operation + ";" + user.correu + ";" + user.contrasenya +
                ";" + user.rol + ";" + user.nom + ";" + user.cognoms;
        }

        /*
        * Create format chain to Product Fisic update
        * @param token
        * @param operation CRUD
        * @param product
        * @return chain format            
        */
        internal static string formatChainProductFisicUpdate(string token, string operation, ProducteFisic productFisic)
        {

            return token + ";" + operation + ";" + productFisic.nom + ";" + productFisic.tipus +
                ";" + productFisic.preu + ";" + productFisic.quantitat + ";" + productFisic.referencia;
        }

        public static List<String> responseFormatServer(string responseServerToConvert)
        {
            return responseServerToConvert.Split(';').ToList();
        }

        /*
        * Create format chain to Product Logic new
        * @param token
        * @param operation CRUD
        * @param producte
        * @return chain format  
        * 
        */
        public static string formatChainUserUpdate(string token, string operation, Usuari user)
        {
            return token + ";" + operation + ";" + user.contrasenya + ";" + user.rol +
                ";" + user.nom + ";" + user.cognoms + ";" + user.correu;
        }

        /*
        * Create format chain to Logout session
        * @param token
        * @return chain format    
        */
        public static string formatChainLogout(String token)
        {
            return token + ";" + CONTROL_CLOSE_SESSION;
        }
    }
}
