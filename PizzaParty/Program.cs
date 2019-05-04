using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            int[] emails = new int[lines];
            int[] posters = new int[lines];
            for(var i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                posters[i] = int.Parse(line[0]);
                emails[i] = int.Parse(line[1]);
            }
            for (var i = 0; i < lines; i++)
            {
                var food = CalculateFood(0, 2, posters[i]);
                var attend = CalculateAttendance(1, 2, emails[i]);
                var jabba = food % attend;
                Console.WriteLine(jabba);
            }
        }
        static ulong CalculateFood(ulong a, ulong b, int posters)
        {
            if(posters == 0)
            {
                return a + b;
            }
            else
            {
                posters--;
                return CalculateFood(b, a + b, posters);
            }
        }
        static ulong CalculateAttendance(ulong a, ulong b,int emails)
        {
            if(emails == 0)
            {
                return a + b;
            }
            else
            {
                emails--;
                return CalculateAttendance(b, a + b, emails);
            }
        }
    }
}
