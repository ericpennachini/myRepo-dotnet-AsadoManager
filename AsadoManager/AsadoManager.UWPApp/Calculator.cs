using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadoManager.UWPApp
{
    public class Calculator
    {
        public static List<User> Calculate2(List<User> _users)
        {
            List<User> diferencias = new List<User>();
            decimal prom = 0;
            int cantidad = _users.Count;
            foreach (User u in _users)
            {
                prom += u.Quantity;
            }
            prom = Math.Round(prom / cantidad, 2);

            // lista con las diferencias individuales con respecto al promedio de gasto
            for (int i = 0; i < cantidad; i++)
            {
                diferencias.Add(new User
                {
                    Name = _users[i].Name,
                    Quantity = prom - _users[i].Quantity
                });
            }

            return diferencias;
        }

        public static List<Result> Calculate(List<User> _users)
        {
            List<User> diferencias = new List<User>();
            decimal prom = 0;
            int cantidad = _users.Count;
            foreach (User u in _users)
            {
                prom += u.Quantity;
            }
            prom = Math.Round(prom / cantidad, 2);
            
            // lista con las diferencias individuales con respecto al promedio de gasto
            for (int i = 0; i < cantidad; i++)
            {
                diferencias.Add(new User
                {
                    Name = _users[i].Name,
                    Quantity = prom - _users[i].Quantity
                });
            }

            
            /*
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
            */


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
        public decimal Quantity { get; set; }
    }
}
