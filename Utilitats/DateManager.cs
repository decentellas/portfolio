using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Utilitats
{
    public class DateManager
    {

        /*
        * Convert Date
        * @param Date to convert
        * @param converted Date
        */
        internal static string converFormatDateBBDD(string dataToConvert)
        {
            DateTime dataFormat = DateTime.ParseExact(dataToConvert, "dd-MM-yyyy", null);
            return dataFormat.ToString("yyyy-MM-dd");
        }

        /*
        * Convert Date to show
        * @param Date to convert
        * @param Converted Data
        */
        internal static string convertDateForm(string dataToConvert)
        {
            DateTime dataConvert = DateTime.ParseExact(dataToConvert, "yyyy-MM-dd", null);
            return dataConvert.ToString("dd-MM-yyyy");
        }
    }
}
