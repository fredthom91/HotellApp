using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Data
{
    public class ErrorHandling
    {
        public void CatchMessage()
        {
            Console.WriteLine("Felaktig inmatning. Var god försök igen");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
        }

        public void NoActiveBookings()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Det finns inga bokningar aktiva, var god skapa en.");
            Console.WriteLine(" ");
            Console.WriteLine("-------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("tryck på valfri tangent för att fortsätta");
            Console.ReadKey();
        }
    }
}
