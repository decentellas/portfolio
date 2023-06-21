using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Model
{
    public class ProducteLogic : Producte
    {  
        public string versio { get; set; }
        public string dataCaducitat { get; set; }

        public ProducteLogic(string referencia, string nom, string tipus, string preu, string quantitat, string versio, string dataCaducitat)
            : base(referencia,nom,tipus,preu,quantitat)        {
            
            this.versio = versio;
            this.dataCaducitat = dataCaducitat;
        }

       
    }
}
