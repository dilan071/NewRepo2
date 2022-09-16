using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Retiro
    {
        DateTime fecha;
        double valorRetirado;
        double retirosDiarios;

        public Retiro()////Creamos un metodo de Retiro() vacio ////
        {

        }

        public Retiro(DateTime fecha, double valorRetirado)
        {
            this.fecha = fecha;
            this.valorRetirado = valorRetirado;
        }////Inicializamos algunas propiedades ne el metodo Retiro////

        public bool topeMaximoRetiro(List<Retiro> retiros, double cantidad)
        {
            foreach (var retiro in retiros)
            {
                if (DateTime.Now.Date == retiro.Fecha.Date)
                {
                    retirosDiarios += retiro.ValorRetirado;
                }
            }
            retirosDiarios += cantidad;
            if (retirosDiarios > Banco.retiroDiario)
            {
                return false;
            }
            retirosDiarios -= cantidad;
            return true;
        }////Este foreach nos sirve para validar si la cuenta ya supero el tope maximo o no conforme a
        ////la fecha en la que el usuario haya retirado, para asi posteriormente//// 
        ////sumarcela al total(retiros diarios), siempre y cuando esta se haya realizado el mismo dia////
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double ValorRetirado { get => valorRetirado; set => valorRetirado = value; }
        public double RetirosDiarios { get => retirosDiarios; set => retirosDiarios = value; }
    }
}
