using System;
using System.Reflection;
using System.Threading;

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

                int play = NimGame.start();

                if (play == 1)
                {
                    Console.WriteLine("This is the normal mode of the Game");
                    Console.WriteLine("Take the last object from piles to win the Game !!!!");

                    int start = rand.Next(1, 3);
                    //Normal Mode
                    
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
                }
                else
                {

                    Console.WriteLine("This is the Misere mode of the Game");
                    Console.WriteLine("Force the opponent to take the last object from piles to win the Game !!!!");
                    // misere mode
                    int start1 = rand.Next(1, 3);

                    if (start1 == 1)
                    {
                        Console.WriteLine("Player 1: Computer will start the Game");
                        NimGame.MisereComputerFirst();

                    }
                    else
                    {
                        Console.WriteLine("Player 2: You will start the Game");
                        NimGame.MisereHumanFirst();
                    }


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

