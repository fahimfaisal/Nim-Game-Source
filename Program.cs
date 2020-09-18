using System;
using System.Reflection;

namespace NimGame
{
    class Program
    {

      
        static void Main(string[] args)
        {
            System.Random rand = new System.Random();

            Gameplay NimGame = new Gameplay();

            Console.WriteLine("Welcome To The Game of Nim ");
            Console.WriteLine("Player 1: is The Computer");
            Console.WriteLine("Player 2: is You");

          while(true)
          {

                NimGame.start();

                int start = rand.Next(1, 3);

                if (start == 1)
                {

                    Console.WriteLine("Player 1: Computer will start the Game");
                    NimGame.ComputerFirst();
                }
                else
                {
                    Console.WriteLine("Player 2: You will start the Game");
                    NimGame.Humanfirst();
                }

                Console.WriteLine();
                Console.WriteLine("Do you want to play again ??[Y/N]");
                string ans = Console.ReadLine();
                string capAns = ans.ToUpper();

                if (capAns == "N")
                {
                    
                    NimGame.PrintInfo();
                    break;
                }
                else if(capAns == "Y")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("The Game will start Again !!!");
                }
                
            }




        }

        
    }
}

