using System;

namespace IBAN_Validierung
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        public void Start()
        {
            Console.WriteLine("IBAN-Validierung\n");
            Console.Title = "IBAN-Validierung";

            var helper = new ConsoleHelper();
            helper.IBAN_Check();
        }
    }
}
