using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;
using Microsoft.SqlServer.Server;
using System.Runtime.ConstrainedExecution;
using System.Collections;
using System.Security.Cryptography;

namespace Models
{
    public class Cuenta
    {
        List<Retiro> retiros = new List<Retiro>();
        Cliente cliente;
        double saldo;
        BigInteger numCuenta;//// El BigInteger nos ayudara a generar un numero entero inmutable ////
        int clave;
        int puntos;
                                  
        public Cuenta(Cliente cliente, double saldo, BigInteger numCuenta, int clave, int puntos)
        {
            this.cliente = cliente;
            this.saldo = saldo;
            this.numCuenta = numCuenta;
            this.clave = clave;
            this.puntos = puntos;
        }
       
        public string retirarSaldo(double cantidad)
        {
            if (cantidad  > 0)
                              //// Aqui validamos que la cantidad a retirar sea////
            ///mayor a cero en caso contrario nos mostrara un mjs de que no estan permitidos valores negativos////
            {
                if (cantidad > this.saldo)
                    return "Fondos insuficientes";
                               //// Aqui se valida si la cantidad es mayor a cero y au vez es////
                ///mayor al saldo del que dispongamos nos retornara un msj de que no poseemos fondos suficientes////
                else
                {
                    if (cantidad > 600000)
                        return "Atención. La cantidad maxima por retiro son $600.000";
                    ////Aqui establecemos otra validacion en la cual la cuenta podra retirar un tope maximo permitido y en caso de que////
                            ////la cantidad que se desea retira sea mayor al tope nos lanzara un msj indicandonos cuanto es////
                                           ////la cantidad maxima que se puede retirar////
                    else
                    {
                        Retiro retiroAux = new Retiro();
                        if (retiroAux.topeMaximoRetiro(retiros, cantidad))
                        {
                            this.saldo -= cantidad;
                            Retiro retiro = new Retiro(DateTime.Now, cantidad);
                            retiros.Add(retiro);
                            return $"Retiro existoso de $ {darFormato(cantidad)} pesos.";
                        }
                        else
                            return $"Atención. Ya superaste el tope diario de retiros. ({darFormato(Banco.retiroDiario)})";
                    }               ////si lo que se desea retirar esta dentro de lo permitido y se poseen fondos suficientes creamos un////
                              ////objeto auxiliar con un constructor vacio para asi poder acceder al metodo topeMaximoRetiro y teniendo como////
                             ////parametros la lista de retiros y la cantidad para asi posteriormente realizar el metodo de topeMaximoRetiro////
                                ////y asi mismo validando dentro del metodo topeMaximoRetiro hasta llegar al maximo de retiro permitido para
                     //// luego lanzar un msj de que se supero el topo diario de retiros e caso de que se llegace a retirar mas del permitido diario////
                }
            }
            else
                return "No se permiten valores negativos.";
        }                         
        public string consultarSaldo()
        {
            return $"$ {darFormato(this.saldo)}";
        }////Metodo para consultar saldo y un return que nos devolvera ese saldo en un formato String////

        public string canjearPuntos(int puntos)
        
        {
            if (puntos <= this.puntos)
            {
                if (puntos % 10 == 0)
                {
                    this.puntos -= puntos;
                    this.saldo += puntos / 10;
                    return $"Se descontaron {puntos}pts. Por lo tanto se canjearón {puntos / 10} pesos.";                    
                }
                else
                    return "No se canjearon los puntos. Fijese que la cantidad sea multiplo de 10.";
                  ////Aqui validamos si los puntos a retirar son menores o iguales que los puntos disponibles si se cumple se////
                 ////valida que el modulo de los puntos ingresados sea == 0 para asi poder redimir solo con multiplos del 10 y////
                                   ////encaso de que no sea == 0 lanzaara un msj diciendo No se canjearon los////
                                            ////puntos. Fijese que la cantidad sea multiplo de 10////
            }
            else
                return "Puntos insuficientes.";
            
        }

        public bool transferir(BigInteger numCuenta, double cantidad)
            
        {
            bool valid = false; 
            foreach (var cuenta in Banco.cuentas)
            {
                if (cuenta.numCuenta == numCuenta)
                {
                    this.saldo -= cantidad;
                    cuenta.Saldo += cantidad;
                    valid = true;
                }         ////Este foreach recorre todas las cuentas que tenemos en la lista, para posteriormente validar si se////
                 ////encontro la cuenta a la que se deasea mandar el dinero para posteriormente restarle el saldo indicado y pasarcela a////
                                ////la cuenta encontrada para luego confirmar mediante un True la transaccion realizada////
            }
            return valid;
        }

        public string darFormato(double precio)
        {
            return precio.ToString("N", CultureInfo.CreateSpecificCulture("es-ES"));
        }

        public Cliente Cliente { get => cliente; set => cliente = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public BigInteger NumCuenta { get => numCuenta; set => numCuenta = value; }
        public int Clave { get => clave; set => clave = value; }
        public int Puntos { get => puntos; set => puntos = value; }

    }
}
