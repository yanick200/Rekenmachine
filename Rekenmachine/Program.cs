using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekenmachine
{
    class Program

    {

        static void Main(string[] args)
        {
            String invoer;
            double[] mSave = new double[10];

            //start menu
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*                          Rekenmachine                                 *");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("* => Om een berekening te maken, geef een bewerking in als 1+2          *");
            Console.WriteLine("* => Om te rekenen met variabelen, geef een bewerking in als 1+m1       *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("* => Om de lokale variabelen met hun waarden te tonen, type 'locals'    *");
            Console.WriteLine("* => Om een variabele in te stellen, geef een opdracht als m1=1         *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("* => Voor een lijst van alle ondersteunde bewerkingen, type 'listcalc   *");
            Console.WriteLine("* => Voor informatie van de schrijver weer te geven, type 'author'      *");
            Console.WriteLine("* => Om de rekenmachine af te sluiten, type 'exit'                      *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*************************************************************************");
           
            //loop 
        start:;
            Console.Write(">");
            invoer = Console.ReadLine();

            //controleren van de invoer
            if (invoer.ToLower() == "listcalc")
            {
                listcalc(); //tonen van lijst van mogelijke bewerkingen 

            }
            else if (invoer.ToLower() == "author")
            {
                author();//tonen van de author 
            }
            else if (invoer.ToLower() == "exit")
            {
                Environment.Exit(0); //programmma sluiten 
            }
            else if (invoer.Contains("m") && invoer.Contains("="))
            {
                oplsaan(mSave, invoer); //variabelen opslaan 
            }
            else if (invoer == "locals")
            {
                showlocals(mSave);//lijst tonen van de opgeslagen variabelen 
            }
            else if (invoer.Contains("m"))
            {
                berekenOpgeslagen(mSave, invoer); //bereking met variabelen uitvoeren 
            }
            else if (invoer.Contains("+") || invoer.Contains("-") || invoer.Contains("*") || invoer.Contains("/") || invoer.Contains("%"))
            {

                Bereken(invoer);//gewone berekeningen zonder variabelen 

            }
            
          
            goto start;//terug keren naar het begin van de loop 


        }

        //functie om de lijst van mogelijke berwerkingen te tonen
        private static void listcalc()
        {
            Console.WriteLine(">");
            Console.WriteLine("> COMMAND         VOORBEELD       UITLEG");
            Console.WriteLine("> +               1+2             //Geeft de som van de getallen weer");
            Console.WriteLine("> -               1-2             //Geeft het verschil van de getallen weer");
            Console.WriteLine("> *               1*2             //Geeft het product van de getallen weer");
            Console.WriteLine("> /               1/2             //Geeft het quotiënt van de getallen weer");
            Console.WriteLine("> %               1%2             //Geeft de delingsrest van de getallen weer");
            Console.WriteLine(">");

        }

        //functie die ascii art en author toont 
        private static void author()
        {
            Console.WriteLine("> Insert ascii art here");
            Console.WriteLine("> Dit rekenmachine is gemaakt door Yanick Hauwelaert 2021");

        }

        //functie om gewonen berekeningen maken 
        private static void Bereken(string invoer)
        {
            String s1 = "", s2 = "", teken = "";
            int plaats = 0;
            double totaal;

            //de string overlopen  kijken waar het teken staat 
            for (int i = 0; i < invoer.Length; i++)
            {
                if (invoer.Substring(i, 1) == "+")
                {

                    teken = "+";
                    plaats = i;
                    i = invoer.Length;
                }

                else if (invoer.Substring(i, 1) == "-")
                {
                    teken = "-";
                    plaats = i;
                    i = invoer.Length;
                }
                else if (invoer.Substring(i, 1) == "*")
                {
                    teken = "*";
                    plaats = i;
                    i = invoer.Length;
                }

                else if (invoer.Substring(i, 1) == "/")
                {

                    teken = "/";
                    plaats = i;
                    i = invoer.Length;
                }
                else if (invoer.Substring(i, 1) == "%")
                {
                    teken = "%";
                    plaats = i;
                    i = invoer.Length;
                }

                else
                {//eerste deel van de bewerking oplsaan 
                    s1 = s1 + invoer.Substring(i, 1);
                }
            }
            //overlopen van de rest van de  string 
            for (int i = plaats + 1; i < invoer.Length; i++)
            {
                //alles na het teken opslaan 
                s2 = s2 + invoer.Substring(i, 1);
            }

            //zien welk teken het is en berekenen

            if (teken == "+")
            {
                totaal = Convert.ToDouble(s1) + Convert.ToDouble(s2);
                Console.WriteLine(totaal);
            }
            else if (teken == "-")
            {
                totaal = Convert.ToDouble(s1) - Convert.ToDouble(s2);
                Console.WriteLine(totaal);
            }
            else if (teken == "*")
            {
                totaal = Convert.ToDouble(s1) * Convert.ToDouble(s2);
                Console.WriteLine(totaal);
            }
            else if (teken == "/")
            {
                totaal = Convert.ToDouble(s1) / Convert.ToDouble(s2);
                Console.WriteLine(totaal);
            }

            else if (teken == "%")
            {
                totaal = Convert.ToDouble(s1) % Convert.ToDouble(s2);
                Console.WriteLine(totaal);
            }



        }

        //lijst met de opgeslagen veriabelen tonen 
        private static void showlocals(double[] _mSave)
        {
            for (int i = 0; i < _mSave.Length; i++)
            {
                Console.WriteLine($">m{i} - {_mSave.GetValue(i)}");
            }
        }

        //opslaan van variabelen waarde 
        private static void oplsaan(double[] _mSave , string _invoer)
        {
            //bepalen wat de index is voor de array 
            int index =Convert.ToInt32(_invoer.Substring(1, 1));
            //bepalen wat de waarde is die moet worden opgeslagen 
            string waarde = _invoer.Substring(3, _invoer.Length-3);
            //opslaan van de waarde in de array 
            _mSave[index] = Convert.ToDouble(waarde);

             Console.WriteLine($"Het getal {waarde} werd opgeslagen op geheugenplaats m{index}");

        }

        //functie om berekening uit te voeren met variabelen 
        private static void berekenOpgeslagen(double[] _msave, string _invoer)
        {
           
            int index = 0;
            double waarde = 0;
            string berekening;

            //doorlopen van de de string om te zien waar de variablen staat
            for (int i = 0; i < _invoer.Length; i++)
            {
                //controleren waar de ma staat
                if (_invoer.Substring(i, 1) == "m")
                {
                    index = Convert.ToInt32(_invoer.Substring(i + 1, 1));// I verhogen om zo het indexnummer te krijgen 
                    i = _invoer.Length;//Loop breken door I = aan de lengte van de string te doen 
                }

            }

            waarde = _msave[index]; //waarde van de variabele ophalen 

            berekening = _invoer.Replace($"m{index}", $"{waarde}");//nieuwe string waar de variabelen wordt vervangen met overeenkomende waarde 

            Bereken(berekening);//de berkening doen door eerder aangemaakte functie 
        }

    }
}

