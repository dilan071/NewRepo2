using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banco
    {
        public static List<Cuenta> cuentas = new List<Cuenta>();
        ////Aqui creamos una lista que se encargara de almacenar cada una de la cuentas creadas////

        public static double retiroDiario = 2000000;
        //// Esta variable nos sirve para establecer un tope maximo en el dinero que se podra retirar////

        public static void agregar(Cuenta cuenta)
        {
            cuentas.Add(cuenta);
        }
    }////Este metodo estatico nos ayudara a agregar cuentas a la lista de cuentas, pasandole como
                       ////paramentro la cuenta que se desea agregar////
}
