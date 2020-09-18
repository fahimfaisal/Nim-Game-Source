using System;
using System.Collections.Generic;
using System.Text;

namespace NimGame
{
    class Pile
    {
        public int value { get; set; }
        public string name { get; set; }

        public Pile(string Name, int Value )
        {
            name = Name;
            value = Value;

        }
        
        public void remove(int num)
        { 
            
            if(num > value)  value = value - 0;
            value = value - num;
            
        }
            
        public void print()
        {
            Console.WriteLine();
            for (int i = 0; i < value; i++)
            {
                Console.WriteLine("*");
            }
            Console.WriteLine();
            Console.WriteLine(name);
        }

    }
}
