using System;

namespace Quiz2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Crazy input!");
                return;
            }
            string[] parts = input.Split(" ");
            int n = int.Parse(parts[0]);
            int cijfer = int.Parse(parts[1]);

            int result = TelCijfer(n, cijfer);
            Console.WriteLine(result);
        }

        public static int TelCijfer(int n, int cijfer)
        {
            if(n == 0)
            {
                return 0;
            }
            return TelCijfer(n-1,cijfer)+KomtAantalKeerVoor(n,cijfer);
        }

        public static int KomtAantalKeerVoor(int number, int cijfer)
        {
            if(number == 0)
            {
                return 0;
            }

            if (number % 10 == cijfer)
            {
                return 1+KomtAantalKeerVoor(number/10,cijfer);
            }
            else
            {
                return KomtAantalKeerVoor(number / 10, cijfer);
            }
        }
    }
}
