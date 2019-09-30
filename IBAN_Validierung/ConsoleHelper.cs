using System;
using System.Collections.Generic;
using System.Text;

namespace IBAN_Validierung
{
    class ConsoleHelper
    {
        public void IBAN_Check()
        {
            while (true) {
                Console.WriteLine("Geben Sie den schweizer IBAN-Code ein:");
                var iban = Console.ReadLine();

                if (iban.Length == 21)
                {
                    if (!Char.IsDigit(iban[0]) && !Char.IsDigit(iban[1]))
                    {
                        var ziffer1 = Convert.ToInt32(iban[0]);
                        var ziffer2 = Convert.ToInt32(iban[1]);
                        bool allGood = true;

                        ziffer1 -= 55;
                        ziffer2 -= 55;

                        var ziffernfolge = Convert.ToString(ziffer1) + "" + Convert.ToString(ziffer2) + "00";

                        for (int i = 2; i < 21; i++) {
                            if (Char.IsDigit(iban[i]))
                            {

                            }
                            else
                            {
                                allGood = false;
                                break;
                            }
                        }

                        if (allGood)
                        {
                            var bban = iban.Substring(4);
                            var bbanZiffern = bban + "" + ziffernfolge;

                            var pSumme = BBAN_Rechnung(bbanZiffern);
                            var pSummeStr = Convert.ToString(pSumme);

                            //Prüfziffercheck
                            if (iban.Substring(2, 2).Equals(pSummeStr))
                            {
                                //Modulo Check
                                var bbanSummeStr = bbanZiffern.Substring(0, bbanZiffern.Length - 2) + "" + pSumme;

                                var bbanSumme = Convert.ToDecimal(bbanSummeStr);
                                var check = bbanSumme % 97;

                                if (check == 1)
                                {
                                    Console.WriteLine("IBAN Korrekt. Eingabe erfolgreich!\n");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Falsche Eingabe!\n");
                            }                            
                        }
                        else
                        {
                            Console.WriteLine("Falsche Eingabe!\n");
                        }                        
                    }
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe!\n");
                }
            }
        }

        public int BBAN_Rechnung(String bbanZiffern)
        {
            var bbanDecimal = Convert.ToDecimal(bbanZiffern);

            var prePSumme = bbanDecimal % 97;

            var pSumme = 98 - prePSumme;

            var pSummeStr = Convert.ToString(pSumme);

            if (pSummeStr.Length == 1)
            {
                pSummeStr = 0 + "" + pSummeStr;
            }

            pSumme = Convert.ToInt32(pSummeStr);

            return (int)pSumme;
        } 
    }
}
