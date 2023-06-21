using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Model
{
    public class ProducteFisic : Producte
    {
        public ProducteFisic(string referencia, string nom, string tipus, string preu, string quantitat)
      : base(referencia, nom, tipus, preu,quantitat)
        {

        }
    }
}
