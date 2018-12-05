using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator;
namespace CaveGen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Cave
            Cave cave = new Cave(100, 210, 65);
            //Render 20 times
            for (int a = 0; a < 20; a++)
            {
                //Get the cave display
                string display = cave.Display();
                //Generate the cave
                cave.Generate();
                //Turn the cave data into readable graphics
                for (int i = 0; i < (display.Length); i++)
                {
                    if (display[i].ToString() != "l")
                    {
                        int num = int.Parse(display[i].ToString());
                        if (num == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        if (num == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (num == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write("0");
                    }
                    else
                    {
                        //Create new line
                        Console.Write("\n");
                    }
            }
                Console.Clear();
            }
        Console.ReadKey();
        }
}
}
