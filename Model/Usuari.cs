using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVentari.Model
{
    public class Usuari
    {
        public string nom { get; set; }
        public string cognoms { get; set; }
        public string correu { get; set; }
        public string rol { get; set; }
        public string contrasenya { get; set; }
        public string repetirContrasenya { get; set; }

        public Usuari(string nom, string cognoms, string correu, string rol, string contrasenya)
        {
            this.nom = nom;
            this.cognoms = cognoms;
            this.correu = correu;
            this.rol = rol;
            this.contrasenya = contrasenya;
        }
        public Usuari(string nom, string cognoms, string correu, string rol, string contrasenya, string repetirContrasenya)
        {
            this.nom = nom;
            this.cognoms = cognoms;
            this.correu = correu;
            this.rol = rol;
            this.contrasenya = contrasenya;
            this.repetirContrasenya = repetirContrasenya;
        }
    }
}
