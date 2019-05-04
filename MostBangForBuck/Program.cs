using System;
using System.Linq;

namespace MostBangForBuck
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var numCoins = int.Parse(input[0]);
            // if there's only one coin then there's no way to make change
            if(numCoins == 1)
            {
                Console.WriteLine("0");
                return;
            }
            var coins = Array.ConvertAll(input.Skip(1).Take(input.Length - 1).ToArray(), long.Parse);
            var buck = LCM(coins);
            var change = 0.0;
            long[] changeCoins = new long[numCoins];
            // start with highest denomination
            coins = coins.OrderByDescending(l => l).ToArray();
            for(var i = 0; i < numCoins; i++)
            {
                while ((change + coins[i]) % buck != 0 && (((changeCoins[i] + coins[i]) % buck) != 0 || changeCoins[i] == 0) && changeCoins.Where((x, j) => j != i).ToList().All(x => (x + (changeCoins[i] + coins[i])) != buck))
                {
                    changeCoins[i] += coins[i];
                    change += coins[i];
                }

            }
            Console.WriteLine(change.ToString());
        }
        static long LCM(long[] numbers)
        {
            return numbers.Aggregate(lcm);
        }
        static long lcm(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
