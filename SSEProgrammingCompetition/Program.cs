using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void Main(string[] args)
    {
        string line1 = Console.ReadLine();
        string line2 = Console.ReadLine();
        int output = 0;
        output += Math.Abs(line1.Length - line2.Length);
        output += line2.Where(x => !line1.Contains(x)).Count();
        Console.WriteLine(output);
        Console.ReadKey();
    }
}
