using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Solucion_Lab_21_abril
{


    class User
    {
        public delegate void OnEmailVerified(object sender, EventArgs e);
        public event OnEmailVerified EmailVerified;

        public void onEmailSent(object sender, EventArgs e)
        {

            bool run = true;
            while (run)
            {
                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() {"Test", "Verificar", "Salir" });
                switch (chosen)
                {
                    case "Test":
                        Console.Clear();
                        Console.WriteLine("PRUEBA");
                        Thread.Sleep(5000);
                        break;

                    case "Verificar":
                        Console.Clear();
                        Console.WriteLine("Correo verificado.");
                        if (EmailVerified != null)
                            EmailVerified(this, null);
                            Console.WriteLine("Mensaje solicitado: Se dispara evento EmailVerified.");
                        Thread.Sleep(5000);
                        break;
                    case "Salir":
                        run = false;
                        break;
                }
                Console.Clear();
            }

        }

        // Metodo para mostrar las opciones posibles
        public static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];
        }
    }
}
