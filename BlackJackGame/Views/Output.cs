using System;

namespace BlackJackGame



    {
    public class Output
        {

        public static void Logo()
            {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========================================================================================================================\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #            Welcome to BlackJackGame...            #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine("========================================================================================================================\n");
            }

        public static void LogoMeddelande(string meddelande)
            {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================================================================================================\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.Write("                             *  #");
            for (int i = 0; i < (51 - meddelande.Length) / 2; i++)
                Console.Write(" ");
            Console.Write(meddelande);
            for (int i = 0; i < (52 - meddelande.Length) / 2; i++)
                Console.Write(" ");
            Console.WriteLine("#  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine("=======================================================================================================================\n");
            }


        public static void ShowMenu()
            {
            Logo();
            Agelimit();

            }

        private static void Agelimit()
            {
            var agelimit = false;
            while (!agelimit )
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                       *=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");
                Console.WriteLine("                                       *=        Age limit  18 years!     =*");
                Console.WriteLine("                                       *=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\nTo move forwad to the game pleace enter your age: ");
                var check = int.TryParse(Console.ReadLine(),out var age);
                //var age = PlayerInput.InvalidInputCheck();
                if (age >= 18 && check )

                    {
                    Console.Clear();
                    agelimit = true;
                    }
                else
                    {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    LogoMeddelande("Invalid input, try again");
                    }

                }

            }

        public static void ShowCards()
            {
            //throw new System.NotImplementedException();
            }


        public static void ShowActivePlayers()
            {

            //throw new System.NotImplementedException();
            }
        }
    }