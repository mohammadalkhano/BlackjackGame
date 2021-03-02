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
            Console.WriteLine("                             *  #            Welcome to BlackJackGame!              #  *");
            Console.WriteLine("                             *  #           Press any key to continiue...           #  *");
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
            while (true)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                     = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =\n");
                Console.WriteLine("                                            * * * * * * * * * * * * * * * * * * *");
                Console.WriteLine("                                            *        Age limit  18 years!       *");
                Console.WriteLine("                                            * * * * * * * * * * * * * * * * * * *");
                Console.WriteLine("                     = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("To move forwad to the game pleace enter your age: ");
                var age = PlayerInput.InvalidInputCheck();
                //int.TryParse(Console.ReadLine(), out var age);

                Logo();
                if (age >= 18)

                {
                    Console.Clear();
                    LogoMeddelande("SelectPlayer");
                    Console.ReadKey();
                    ShowTable();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    LogoMeddelande("You do not fulfill the age limit");
                    Console.ReadKey();
                }
            }
        }

        public static void ShowTable()
        {
                Console.Clear();
                LogoMeddelande("Select Table");
                Console.WriteLine("\n [Table (1) \t Min-Bet: 100 \t Max-Bet 1000 ]\n [Table (2) \t Min-Bet: 100 \t Max-Bet 2000 ]\n [Table (3) \t Min-Bet: 200 \t Max-Bet 5000 ]\n [Table (4) \t Min-Bet: 1000 \t Max-Bet 10000]");
            
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