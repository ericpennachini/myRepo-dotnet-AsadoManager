using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadoManager.TestConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<User> listaInicial = new List<User>
            {
                new User { Name = "ERIC", Quantity = 150 },
                new User { Name = "JESSY", Quantity = 178 },
                new User { Name = "MARCOS", Quantity = 200.50M }
            };

            List<User> listaResultado = Calculator.Calculate2(listaInicial);

            Console.WriteLine("Resultados:");
            foreach (User u in listaResultado)
            {
                if (u.Quantity < 0)
                {
                    Console.WriteLine($">> {u.Name} tiene que RECIBIR ${-(u.Quantity)}");
                }
                else
                {
                    Console.WriteLine($">> {u.Name} tiene que APORTAR ${u.Quantity}");
                }
            }
            Console.ReadKey();
        }
    }
}
