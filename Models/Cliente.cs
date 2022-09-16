using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        string nombre;
        int nroDocumento;
        string contrasenia;

        public Cliente(string nombre, int nroDocumento, string contrasenia)
        {
            this.nombre = nombre;
            this.nroDocumento = nroDocumento;
            this.contrasenia = contrasenia;
        }
        //// Datos en la clase Cliente con el cual se inicia sesion para posteriormente inicializarlos////
        public static Cuenta login(int nroDocumento, string contrasenia)
        {
            foreach (var cuenta in Banco.cuentas)
            {
                if (cuenta.Cliente.NroDocumento == nroDocumento && cuenta.Cliente.Contrasenia == contrasenia)
                {
                    return cuenta;
                }
            }
            return null;
        }        ////Este foreach se encarga de recorrer todas las cuentas que estan en la lista del banco////
            ////y asi empezar a comparar si el NroDocumento == nroDocumento y asi mismo con la contraseña para////
                          ////luego retornar esta misma y en caso de que no este, retornar null////

        public string Nombre { get => nombre; set => nombre = value; }   
        public int NroDocumento { get => nroDocumento; set => nroDocumento = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
} //// Metodos get y set para las diferentes propiedades ////
