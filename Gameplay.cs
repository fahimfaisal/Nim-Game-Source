using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Transactions;

namespace NimGame
{
    class Gameplay
    {
        Piletree gameTree = new Piletree();

        System.Random rand = new System.Random();


        public Gameplay()
        {

        }
        public int start()
        {

            Console.WriteLine("Please Select a Game mode[1/2]");
            Console.WriteLine();
            Console.WriteLine("1. Normal Mode");
            Console.WriteLine();
            Console.WriteLine("2. Misere Mode");

            int input = Convert.ToInt32(Console.ReadLine());

            int pileNumber = rand.Next(2, 6);

            gameTree.GeneratePile(pileNumber);

            gameTree.PrintStack();

            return input;

        }

        public void Computer()
        {
            Console.WriteLine("It's Computers Turn");
            
            int count = 0;

           

            foreach (Pile pile in gameTree.Piles)
            {

                


                if (gameTree.NimSum() != 0)
                {


                    int xor = gameTree.FindXor(pile.value, gameTree.NimSum());

                    if (xor < pile.value)
                    {
                        int op = pile.value - xor;
                        pile.remove(op);
                        Console.WriteLine("Computer Removed " + op + " object from Pile " + pile.name);
                        break;
                    }

                }
                else
                {
                    if (pile.value > 1)
                    {
                        int ran = rand.Next(1, pile.value - 1);
                        pile.remove(ran);
                        Console.WriteLine("Computer Removed " + ran + " object from Pile " + pile.name);
                        break;
                    }
                    else
                    {
                        count++;
                    }


                    
                }

                
            }
            
            if (count == gameTree.Piles.Count)
            {
                foreach (Pile pile in gameTree.Piles)
                {
                    if (pile.value == 1)
                    {
                        pile.remove(1);
                        Console.WriteLine("Computer Removed 1 object from Pile " + pile.name);
                        break;
                    }

                }
            }

           

        }

        public void Human()
        {
            
            Console.WriteLine("Select a Pile");

            Pile pile;

            do
            {
                string name = Console.ReadLine();

                pile = gameTree.GetPile(name);

                if (pile == null)
                {

                    Console.WriteLine("Please Select a valid pile");
                }
                else
                {
                    break;
                }




            } while (true);

            Console.WriteLine("Enter amount of objects to remove");

            try
            {
                do
                {
                    int obj = Convert.ToInt32(Console.ReadLine());

                    if (obj == 0 || obj > pile.value)
                    {
                        Console.WriteLine("Please Enter a valid amount of object to remove");
                    }
                    else
                    {
                        pile.remove(obj);
                        Console.WriteLine();
                        Console.WriteLine("You Removed " + obj + " object from Pile " + pile.name);
                        break;
                    }

                } while (true);
            }
            catch(Exception)
            {
                Console.WriteLine("Sorry you have to Enter a number");
                Console.WriteLine();
                Human();
            }

        }
        

        public int CheckStatus()
        {
            if (gameTree.IsEmpty() == true)
            {

                return 1;

            }
            else
            {
                return 0;
            }

        }

        public void Humanfirst()
        {
            if (gameTree.NimSum() == 0)
            {
                Console.WriteLine("Computer will win this Game");
            }
            else
            {
                Console.WriteLine("You Will Win the Game if you play optimally");   
            }

            while (true)
            {


                Human();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("CONGRATULATIONS !!! You Won the Game");
                    gameTree.Piles.Clear();
                    break;
                }


                Computer();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("SORRY :( You lose the Game ");
                    gameTree.Piles.Clear();

                    break;
                }

            }
        }
        public void ComputerFirst()
        {
            if (gameTree.NimSum() == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You will win this Game if you play optimally");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Computer will win this game");
            }

            while (true)
            {
              
                
                Computer();
                
               
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("SORRY :( You lose the Game ");
                    gameTree.Piles.Clear();
                    break;
                }


                Human();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("CONGRATULATIONS !!! You Won the Game");
                    gameTree.Piles.Clear();
                    break;
                }

            }
        }

        public void PrintInfo()
        {
            int millsec = 3000;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thanks FOR PLAYING :)");
            Console.WriteLine();
            Console.Write("Game Created By");
            Console.Write(" FAHIM FAISAL KHAN");
            Console.WriteLine();
            Console.WriteLine("Student ID : 219361242");
            Thread.Sleep(millsec);
        }
        
        public void MisereComputer()
        {
            Console.WriteLine("It's Computers Turn");

            int count = 0;

            int take = 0;
            foreach(Pile pile  in gameTree.Piles)
            {
                if (pile.value > 1)
                {
                    take++;
                }

            }
           



            foreach (Pile pile in gameTree.Piles)
            {
                
              


                if (gameTree.NimSum() != 0)
                {


                    int xor = gameTree.FindXor(pile.value, gameTree.NimSum());

                    if (xor < pile.value)
                    {
                        int op = pile.value - xor;

                        if(take == 1)
                        {
                            if (op == pile.value)
                            {
                                op = op - 1;

                            }
                            else
                            {
                                op = op + 1;
                            }
                        }
                      
                        pile.remove(op);
                        Console.WriteLine("Computer Removed " + op + " object from Pile " + pile.name);
                        break;
                    }

                }
                else
                {
                    if (pile.value > 1)
                    {
                        int ran = rand.Next(1, pile.value - 1);
                        pile.remove(ran);
                        Console.WriteLine("Computer Removed " + ran + " object from Pile " + pile.name);
                        break;
                    }
                    else
                    {
                        count++;
                    }



                }


            }

            if (count == gameTree.Piles.Count)
            {
                foreach (Pile pile in gameTree.Piles)
                {
                    if (pile.value == 1)
                    {
                        pile.remove(1);
                        Console.WriteLine("Computer Removed 1 object from Pile " + pile.name);
                        break;
                    }

                }
            }



        }

        public void MisereComputerFirst()
        {
            if (gameTree.NimSum() == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You will win this Game if you play optimally");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Computer will win this game");
            }

            while (true)
            {


                MisereComputer();


                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("CONGRATULATIONS!!! You Won the Game");
                    gameTree.Piles.Clear();
                    break;
                }


                Human();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("Sorry :( You lose the Game");
                    gameTree.Piles.Clear();
                    break;
                }

            }

        }
        public void MisereHumanFirst()
        {
            if (gameTree.NimSum() == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You will win this Game if you play optimally");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Computer will win this game");
            }

            while (true)
            {




                Human();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("SORRY :( You lose the Game");
                    gameTree.Piles.Clear();
                    break;
                }


                MisereComputer();
                gameTree.PrintStack();
                if (CheckStatus() == 1)
                {
                    Console.WriteLine("CONGRATULATIONS !!! You Won the Game");
                    gameTree.Piles.Clear();
                    break;
                }

            }
        }
    }
}

