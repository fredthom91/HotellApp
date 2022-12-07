using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp
{
    public class App
    {
        public void Run()
        {
            Console.WriteLine("BOKNINGS MENY");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("1. Registrera ett rum");
            Console.WriteLine("2. Ändra/Hantera ett rum");
            Console.WriteLine("3. Registrera en kund");
            Console.WriteLine("4. Ändra en kund");
            Console.WriteLine("5. Lägg till en bokning");
            Console.WriteLine("6. Ändra en bokning");
            Console.WriteLine("7. Ta bort en bokning");
            Console.WriteLine("8. Avsluta");
            var select = Convert.ToInt32(Console.ReadLine());

            if (select = 1)
            {

            }
        }

    }
}
