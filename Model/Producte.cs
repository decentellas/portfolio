using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Model
{
  public class Producte
        {
            public string referencia { get; set; }
            public string nom { get; set; }
            public string tipus { get; set; }
            public string preu { get; set; }
            public string quantitat{ get; set; }

           

            public Producte(string referencia, string nom, string tipus, string preu, string quantitat)
            {
                this.referencia = referencia;
                this.nom = nom;
                this.tipus = tipus;
                this.preu = preu;
                this.quantitat = quantitat;
            }

            public Producte(string referencia, string nom, string tipus, string preu)
            { 
                this.referencia = referencia;
                this.nom = nom;
                this.tipus = tipus;
                this.preu = preu;           
            }
        }
    }

