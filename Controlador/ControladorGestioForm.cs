using CatVentari.Model;
using CatVentari.Utilitats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatVentari.Controlador
{
    public class ControladorGestioForm
    {
       
        public static void gestioAlta(string nom, string cognoms, string correuElectronic, string contrasenya, string contrasenyaRepetida, string rol, Socket socketActiu)
        {
            bool resultatComprovacio = Validacio.campsFormAlta(nom, cognoms, correuElectronic, contrasenya, contrasenyaRepetida, rol);

            if (resultatComprovacio)
            {
                // Creem el usuari
                Usuari usuari = ControladorUsuari.creacioObjUsuari(nom, cognoms, correuElectronic, contrasenya, rol);

                // Creem la cadena per enviar al socket
                string cadenaFormatadaAlta = GestioFormatUsuari.formatAltaUsuari(usuari);

                // Enviem cadena al socket. Esperem resposta
                String respostaServidor = ModelSocket.ComunicacioSocket(socketActiu, cadenaFormatadaAlta);

                string[] formatadaRecepcio = GestioFormat.formatarRecepcio(respostaServidor);

                // Imprimir el resultat de la operacio
                // Entenem que posicio 0 es resultat 
                ControladorSocket.resultatOperacio(formatadaRecepcio[0]);

                if (formatadaRecepcio[0].Equals("0"))
                {
                    // Gravem Registre
                    ControladorLog.gravacioLog(" ", " ", "Alta usuari/a:" + correuElectronic);

                    // Buidem camps
                    ControladorFormulariAltaUsuari.AccioBuidar(nom, cognoms, correuElectronic, contrasenya, contrasenyaRepetida, rol);
                }
            }

        }

       

        public static void gestioBaixaCercar(string nom, string cognoms, string correuElectronic, string rol, Button bBaixaEsborrar, Socket socketActiu)
        {
            bool resultatComprovacioBaixa = Validacio.campsFormBaixa(correuElectronic);
            //MessageBox.Show(resultatComprovacioBaixa);
            if (resultatComprovacioBaixa)
            {
                // Creem la cadena per enviar al socket
                string cadenaFormatadaConsulta = GestioFormatUsuari.formatBaixaCercar(correuElectronic);

                // Enviem cadena per consultaal socket
                String respostaServidor = ModelSocket.ComunicacioSocket(socketActiu, cadenaFormatadaConsulta);

                // Passem la cadena rebuda a un array
                string[] formatadaRecepcio = GestioFormat.formatarRecepcio(respostaServidor);

                // Imprimir el resultat de la operacio
                // Entenem que posicio 0 es resultat 
                ControladorSocket.resultatOperacio(formatadaRecepcio[0]);

                if (formatadaRecepcio[0].Equals("0"))
                {
                    // Pintem
                    controladorFormulariBaixa.omplirCampsConsulta(nom, cognoms, rol, formatadaRecepcio);

                    //Habilitem el boto.
                    bBaixaEsborrar.Enabled = true;
                }

            }
        }

        public static void gestioBaixaEsborrar(string nom, string cognoms, string correuElectronic, string rol, Button bBaixaEsborrar, Socket socketActiu)
        {
            bool resultatComprovacioBaixa = Validacio.campsFormBaixa(correuElectronic);
            if (resultatComprovacioBaixa)
            {
                // Creem la cadena per enviar al socket
                string cadenaFormatadaEsborrar = GestioFormatUsuari.formatBaixaEsborrar(correuElectronic);


                // Enviem cadena per consultaal socket
                String respostaServidor = ModelSocket.ComunicacioSocket(socketActiu, cadenaFormatadaEsborrar);


                // Passem la cadena rebuda a un array
                string[] formatadaRecepcio = GestioFormat.formatarRecepcio(respostaServidor);


                // Imprimir el resultat de la operacio. Entenem que posicio 0 es resultat 
                ControladorSocket.resultatOperacio(formatadaRecepcio[0]);

                if (formatadaRecepcio[0].Equals("0"))
                {
                    // Pintem
                    controladorFormulariBaixa.omplirBaixaCampsBuits(nom, cognoms, correuElectronic, rol);

                    //Habilitem el boto.
                    bBaixaEsborrar.Enabled = false;
                }

            }
        }
    }
}
