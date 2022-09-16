using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Numerics;

namespace AppCajero
{
    public partial class FormLogin : FormCajero
    {
        static int sesiones = 0;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            sesiones++;
            if (sesiones == 1)
            {
                Cliente cliente = new Cliente("Diego", 1000999999, "123");
                Cuenta cuenta = new Cuenta(cliente, 7000000, 1234567890, 0425, 200);
                Banco.agregar(cuenta);

                Cliente cliente2 = new Cliente("Henry", 1000999998, "123");
                Cuenta cuenta2 = new Cuenta(cliente2, 7000000, 1234567891, 0425, 300);
                Banco.agregar(cuenta2);

                Cliente cliente3 = new Cliente("Dilan", 1000999997, "123");
                Cuenta cuenta3 = new Cuenta(cliente3, 7000000, 1234567891, 0425, 350);
                Banco.agregar(cuenta3);
            }
        }

       
    }
}
