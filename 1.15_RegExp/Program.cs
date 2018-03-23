using System;
using System.Text.RegularExpressions;
using System.IO;

namespace _1._15_RegExp
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "";
            String[] ma1 = new String[10];
            String[] ma2 = new String[10];
            
            using (StreamReader sr = new StreamReader("Text.txt")) 
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    s += line + "\n";
                }
            }

            String[] words = s.Split(' ');

            Regex r = new Regex("[+]375(29|33|25|44|24)[0-9]{7}");
            MatchCollection matches = r.Matches(s);

            Regex r2 = new Regex("[+]375[-](29|33|25|44|24)[-][0-9]{7}");
            MatchCollection mtch = r2.Matches(s);

            int count = 0;
            foreach (Match m in matches)
            {
                ma1[count++] = m.ToString();
            }   

            count = 0;
            foreach (Match m in mtch)
            {
                ma2[count++] = m.ToString();
            }

            foreach (var str in words)
            {
                if (Array.IndexOf(ma1, str) > -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(str + " ");
                    Console.ResetColor();
                } 
                else if (Array.IndexOf(ma2, str) > -1){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str + " ");
                    Console.ResetColor();
                } else {
                    Console.Write(str + " ");
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}