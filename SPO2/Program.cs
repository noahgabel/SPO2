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
            //Tells thwe user to write their name
            Console.Write("Indtast dit navn ->");
            //Read the input
            string userName = Console.ReadLine();

            //Tells the user to write their CPR
            Console.Write("Indtast dit CPR nummner ->");
            //Reads the input
            string personNummer = Console.ReadLine();

            //Make a switch
            switch (userName)
            {
                //If the users name is Hans with uppercase do this
                case "Hans":
                    Console.WriteLine("Goddag {0}", userName);
                    break;
                //If the users name is hans with uppercase do this
                case "hans":
                    Console.WriteLine("Goddag {0}", userName);
                    break;
                //If the users name is Grete with uppercase do this
                case "Grete":
                    Console.WriteLine("Hej {0}", userName);
                    break;
                //If the users name is grete with uppercase do this
                case "grete":
                    Console.WriteLine("Hej {0}", userName);
                    break;
                //If it is none of them, then run the default.
                default:
                    Console.WriteLine("Dig kender jeg ikke, {0}. Er du en heks?", userName);
                    break;
            }

            //Wait so it looks legit.
            Thread.Sleep(1000);

            //Here it calls the method and passes in the parameters which helps calcutelate details of the CPR
            personNummerBeregning(personNummer);

            //Wait so it looks legit.
            Thread.Sleep(1000);

            //Now let the user Choose which feature they want to use.
            menuChooser();

            //Please don't close the terminal
            Console.ReadKey();
        }

        //Make this method
        public static void personNummerBeregning(string personNummer)
        {
            //try this and see if the code works before outputting.
            try
            {
                //Get the last int of the CPR
                string getLastInt = personNummer.Substring(9);

                //Use modulus to see which gender they are.
                int genderResult = Convert.ToInt32(getLastInt) % 2;

                //Get the 6 first numbers of CPR.
                string birth_day = personNummer.Substring(0, 6);

                
                DateTime birth_result;
                CultureInfo country = CultureInfo.InvariantCulture;

                //Set the provider to Danish
                country = new CultureInfo("da-DK");

                //Parse exact the result of the 6 first numbers of the CPR, format ddmmyy
                birth_result = DateTime.ParseExact(birth_day, "ddMMyy", country);

                //Set the variable now to the time now
                DateTime now = DateTime.Now;

                //Calculate the life length
                TimeSpan lifeLength = now - birth_result;

                //divide the days with 365
                int age = lifeLength.Days / 365;

                //Output how old you are.
                Console.WriteLine("Du er {0} år gammel", age);   

            //If it is "lige" then you are a woman
            if (genderResult == 0)
            {
                Console.WriteLine("Du er en kvinde");


            }
                //else you are a man
            else
            {
                Console.WriteLine("Du er en mand");
            }

            }
            //finish the try catch block, with an error if the CPR number is not correct.
            catch
            {
                //Output the error.
                Console.WriteLine("Der skete en fejl, du har indtast et CPR nummer der enten er for langt eller kort!");
                Console.WriteLine("Prøv at starte programmet op igen.");
            }
        }

        //Make the menu method
        public static void menuChooser()
        {
            //set the variables
            string userChoosen;
            int runned = 0;

            //Do the menu loop, this helps so we can run the program multiple times.
            do
            {
                //Ask for feature
                Console.WriteLine("Vælg venligst vil du køre (a)realberegning, (o)rdoptælling, (exit)");

                //read the input
                userChoosen = Console.ReadLine();
                
                //Make a switch between which feature the user makes.
                switch (userChoosen.ToLower())
                {
                    //Incase of A do this
                    case "a":
                        //Here we Console Writeline and inside it call the method arealberegning.
                        Console.WriteLine("Arealet er: {0}", arealberegning());
                        //Stop
                        break;
                    //Incase of O do this
                    case "o":
                        //Set the text string we need
                        string text = "Jan og Jokum var jordens bedste hjertevenner. Jannie var også med i kliken men fik jod i øjet. Jokum og Jessie var med på vejen til Jerusalum. De havde jordbæris på hjernen og jord i hovedet.";
                        //Console Writeline the result we get from ordoptælling
                        Console.WriteLine("Alle ord der starter med J og er ikke duplikeret: {0}", ordoptælling(text));
                        //Stop
                        break;
                        //Run the default, its exit stop the program.
                    default:
                        //Multiply the looped times plus 10
                        int runned_multiplied = runned + 10;

                        Random rand = new Random();

                        //Generate a number between 1 and runned_multiplied
                        int random_generated_number = rand.Next(1, runned_multiplied);

                        //Output the number of runs.
                        Console.WriteLine("Programmet har kørt {0}", runned);
                        //Output the random generated number.
                        Console.WriteLine("Den random tal er {0}", random_generated_number);

                        //check if the random generated number matches the number of runned times.
                        if (random_generated_number == runned)
                        {
                            //Write bingo!
                            Console.WriteLine("Bingo!");
                        }

                        //tell the user the program is done, and they can press any key to close.
                        Console.WriteLine("Bye!, tryk en knap for at afslutte programmet...");
                        break;
                }
                //Add 1 to runned.
                runned++;
                //stop if its exit
            } while (userChoosen != "exit");
        }

        //Make the method
        public static string ordoptælling(string text)
        {
            //Make the list with lowercase and uppercase
            var filter_character = new List<string> { "J", "j" };

            //Split it into a list all the words
            string[] words_splittet_character = text.Split(' ');

            //Set the wordlooped to 0
            int word_looped = 0;

            //Make the list, to check if the word already is in the list.
            List<string> check_exists_list = new List<string>();

            do
            {
                //Select the word in the loop
                string word_selected = words_splittet_character[word_looped];

                //Check if the first letter is J
                bool contains_value = filter_character.Contains(word_selected.Substring(0, 1), StringComparer.OrdinalIgnoreCase);

                //Check if it contains this is a boolean.
                if (contains_value)
                {
                    //If it already exists in the list the word. Then don't do it twice.
                    if (!check_exists_list.Contains(word_selected))
                    {
                        //Add the word.
                        check_exists_list.Add(word_selected);
                        //Output the word.
                        Console.WriteLine(word_selected);
                    }
                }
                //add on to the looped variable.
                word_looped++;
                //Stop when all words have been looped
            } while (words_splittet_character.Count() > word_looped);

            //Return nothing.
            return "";
        }
        //Make the method.
        public static double arealberegning()
        {
            //Ask the user the height.
            Console.Write("Indtast højde -> ");
            double height = Convert.ToDouble(Console.ReadLine());

            //Ask the user about the bottomline.
            Console.Write("Indtast grundlinje -> ");
            double grundlinje = Convert.ToDouble(Console.ReadLine());

            //Calcutelate.
            double areal = 0.5 * height * grundlinje;
            
            //return the value.
            return areal;
        }
    }
}
