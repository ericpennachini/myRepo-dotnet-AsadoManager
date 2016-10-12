using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadoManager.TestConsoleApp
{
    public class Calculator
    {
        public static List<Result> Calculate(List<User> _users)
        {
            List<User> promediada = new List<User>();
            List<User> mayores = new List<User>();
            User mayor = new User { Quantity = 0 };
            foreach (User u in promediada)
            {
                if (u.Quantity > mayor.Quantity)
                {
                    mayor.Name = u.Name;
                    mayor.Quantity = u.Quantity;
                }
            }


            return null;
        }

        public void validar() { }
    }

    public class User
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Result
    {
        public string UserFrom { get; set; }
        public string UserTo { get; set; }
        public decimal Quantiy { get; set; }
    }
}
