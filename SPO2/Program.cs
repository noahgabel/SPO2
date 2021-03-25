using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace SPO2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast dit navn ->");
            string userName = Console.ReadLine();

            Console.Write("Indtast dit CPR nummner ->");
            string personNummer = Console.ReadLine();

            switch (userName)
            {
                case "Hans":
                    Console.WriteLine("Goddag {0}", userName);
                    break;
                case "hans":
                    Console.WriteLine("Goddag {0}", userName);
                    break;
                case "Grete":
                    Console.WriteLine("Hej {0}", userName);
                    break;
                case "grete":
                    Console.WriteLine("Hej {0}", userName);
                    break;
                default:
                    Console.WriteLine("Dig kender jeg ikke, {0}. Er du en heks?", userName);
                    break;
            }

            Thread.Sleep(1000);

            personNummerBeregning(personNummer);

            Thread.Sleep(1000);

            menuChooser();

            Console.ReadKey();
        }

        public static void personNummerBeregning(string personNummer)
        {
            try
            {

                string getLastInt = personNummer.Substring(9);

                int genderResult = Convert.ToInt32(getLastInt) % 2;

                string birth_day = personNummer.Substring(0, 6);


                DateTime birth_result;
                CultureInfo provider = CultureInfo.InvariantCulture;

                provider = new CultureInfo("da-DK");

                birth_result = DateTime.ParseExact(birth_day, "ddMMyy", provider);

                DateTime now = DateTime.Now;

                TimeSpan lifeLength = now - birth_result;

                int age = lifeLength.Days / 365;

                Console.WriteLine("Du er {0} år gammel", age);   

            if (genderResult == 0)
            {
                Console.WriteLine("Du er en kvinde");


            }
            else
            {
                Console.WriteLine("Du er en mand");
            }

            }
            catch
            {
                Console.WriteLine("Der skete en fejl, du har indtast et CPR nummer der enten er for langt eller kort!");
                Console.WriteLine("Prøv at starte programmet op igen.");
            }
        }

        public static void menuChooser()
        {
            string userChoosen;
            int runned;

            do
            {

                Console.WriteLine("Vælg venligst vil du køre (a)realberegning, (o)rdoptælling, (exit)");

                userChoosen = Console.ReadLine();

                switch (userChoosen)
                {
                    case "a":
                        Console.WriteLine("Arealet er: {0}", arealberegning());
                        break;
                    case "o":
                        string text = "Jan og Jokum var jordens bedste hjertevenner. Jannie var også med i kliken men fik jod i øjet. Jokum og Jessie var med på vejen til Jerusalum. De havde jordbæris på hjernen og jord i hovedet.";
                        Console.WriteLine("Alle ord der starter med J og er ikke duplikeret: {0}", ordoptælling(text));
                        break;
                    default:
                        Console.WriteLine("Bye!, tryk en knap for at afslutte programmet...");
                        break;
                }
                

            } while (userChoosen != "exit");
        }

        public static string ordoptælling(string text)
        {

            var filter_character = new List<string> { "J", "j" };

            string[] words_splittet_character = text.Split(' ');

            int word_looped = 0;

            List<string> check_exists_list = new List<string>();

            do
            {

                string word_selected = words_splittet_character[word_looped];

                bool contains_value = filter_character.Contains(word_selected.Substring(0, 1), StringComparer.OrdinalIgnoreCase);

                if (contains_value)
                {

                    if (!check_exists_list.Contains(word_selected))
                    {
                        check_exists_list.Add(word_selected);
                        Console.WriteLine(word_selected);
                    }
                }

                word_looped++;

            } while (words_splittet_character.Count() > word_looped);


            return "";
        }
        public static double arealberegning()
        {
            Console.Write("Indtast højde -> ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast grundlinje -> ");
            double grundlinje = Convert.ToDouble(Console.ReadLine());

            double areal = 0.5 * height * grundlinje;

            return areal;
        }
    }
}
