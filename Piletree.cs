using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;

namespace NimGame
{
    class Piletree
    {
        public List<Pile> Piles = new List<Pile>();

        public Piletree()
        {

        }

        public Pile GetPile(string name)
        {
            string nameCap = name.ToUpper();

            foreach(Pile pile in Piles)
            {
                string orgName = pile.name;
                bool ds = orgName.Equals(nameCap);
                if (ds == true)
                {
                    return pile;
                }
               
            }
            return null;
        }

        public bool IsEmpty()
        {
            int count = 0;
            
            foreach(Pile piles in Piles)
            {
                if (piles.value == 0)
                {
                    count++;
                }
            }

            if (count == Piles.Count)
            {
                return true ;
            }
            else
            {
                return false;
            }
            
        }

        public void Addpile(Pile pile)
        {
            Piles.Add(pile);
        }

        public void GeneratePile(int number)
        {
            System.Random random = new System.Random();

            int minNum = 2 * number + 1;

            int maxNum = minNum + 10;

            int minCap = random.Next(minNum, maxNum);
            
            for (int i = 0; i < number; i++)
            {
                int minpil = minCap - (number - (i+1));       //Amount of obejcts left
                
                if(i== 0)
                {

                    int num1 = random.Next(1, minpil);
                    //Maximum amount of object can enter
                    minCap= minCap - num1;
                   
                   Pile Pile1 = new Pile("A", num1);

                    Addpile(Pile1);
                }
                
                if(i == 1)
                {
                    if (number == i+1)
                    {
                        int num2 = minCap;
                        Pile Pile2 = new Pile("B", num2);
                        Addpile(Pile2);
                    }
                    else
                    {
                        int num2 = random.Next(1, minpil);
                        minCap = minCap - num2;
                        Pile Pile2 = new Pile("B", num2);
                        Addpile(Pile2);
                    }
                  
                }
                if(i == 2)
                {
                    if (number == i + 1)
                    {
                        int num3 = minCap;
                        Pile Pile3 = new Pile("C", num3);
                        Addpile(Pile3);
                    }
                    else
                    {
                        int num3 = random.Next(1, minpil);
                        minCap = minCap - num3;
                        Pile Pile3 = new Pile("C", num3);
                        Addpile(Pile3);
                    }
                       
                }
                if(i == 3)
                {

                    if (number == i + 1)
                    {
                        int num4 = minCap;
                        Pile Pile4 = new Pile("D", num4);
                        Addpile(Pile4);
                    }
                    else
                    {

                        int num4 = random.Next(1, minpil);
                        minCap = minCap - num4;
                        Pile Pile4 = new Pile("D", num4);

                        Addpile(Pile4);

                    }
                }
                
                if (i == 4)
                {

                    int num5 = minCap;
                    
                    Pile Pile5 = new Pile("E", num5);

                    Addpile(Pile5);
                }

            }

        }

        public void PrintStack()
        {


            
            Console.WriteLine();
            
            foreach(Pile pileName in Piles)
            {
                Console.Write(" "+pileName.name);
               
            }

            Console.WriteLine();

            int count = 0;
            
            int back = 0;
            
            bool isplay = true;
            
            while (isplay) 
            {
                
                foreach (Pile pileValue in Piles)
                {
                   
                    if (pileValue.value - count <= 0)
                    {
                        Console.Write(" " + " ");
                            
                        back++;
                            
                        if (back == Piles.Count) isplay = false;
                    
                    }
                    
                    else
                    {
                        Console.Write(" " + "*");
                    }
            
                }
                
                back = 0;
                
                count++;
                
                Console.WriteLine();
            }


        }

        public int FindXor(int x, int y)
        {
            return (x | y) & (~x | ~y);
        }
        public int NimSum()
        {
            int first = Piles[0].value;
            
            for (int i = 1; i < Piles.Count; i++)
            {
                int firstXor = FindXor(first, Piles[i].value);
                first = firstXor;
            }

            return first;
        }

       
           
    }
}
