using System;

namespace CaveGenerator
{
    class Cave
    {
        int vHeight;
        int vWidth;
        int vDensity;
        
        int[,] vSpace;
        string vDisplay = "";
        public Cave(int pHeight, int pWidth, int pDensity)
        {
            //Cave Height
            vHeight = pHeight;
            //Cave Width
            vWidth = pWidth;
            //Cave Density
            vDensity = pDensity;
            //Create Cave Array
            vSpace = new int[vHeight, vWidth];
            //Make all the values to nothing
            for (int x = 0; x < vHeight; x++)
            {
                for (int y = 0; y < vWidth; y++)
                {
                    vSpace[x, y] = 0;
                }
            }
        }

        public void Generate()
        {
            vDisplay = "";
            Random rand = new Random();
            //Loop and create points
            for (int x = 0; x < vHeight; x++)
            {
                for (int y = 0; y < vWidth; y++)
                {

                    if (rand.Next(0, 100) < vDensity)
                    {
                        vSpace[x, y] = 1;
                    }
                }
            }
            //Expand those points
            for (int x = 0; x < vHeight; x++)
            {
                for (int y = 0; y < vWidth; y++)
                {

                    if (rand.Next(0, 400) < vDensity && vSpace[x, y] == 1)
                    {
                        vSpace[x, y] = 2;
                    }
                }
            }
            //Check for anomilies and remove them
            for (int x = 3; x < (vHeight - 3); x++)
            {
                for (int y = 3; y < (vWidth - 3); y++)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (vSpace[x + i, y] == 0 && vSpace[x - i, y] == 0 && vSpace[x, y + 1] == 0 && vSpace[x, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y] == 1 && vSpace[x - i, y] == 0 && vSpace[x, y + i] == 0 && vSpace[x, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y] == 0 && vSpace[x - i, y] == 1 && vSpace[x, y + i] == 0 && vSpace[x, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y] == 0 && vSpace[x - i, y] == 0 && vSpace[x, y + i] == 1 && vSpace[x, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y] == 0 && vSpace[x - i, y] == 0 && vSpace[x, y + i] == 0 && vSpace[x, y - i] == 1)
                        {
                            vSpace[x, y] = 0;
                        }
                      
                        if (vSpace[x + i, y + i] == 0 && vSpace[x - i, y + i] == 0 && vSpace[x + i, y - i] == 0 && vSpace[x - i, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y + i] == 1 && vSpace[x - i, y + i] == 0 && vSpace[x + i, y - i] == 0 && vSpace[x - i, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y + i] == 0 && vSpace[x - i, y + i] == 1 && vSpace[x + i, y - i] == 0 && vSpace[x - i, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y + i] == 0 && vSpace[x - i, y + i] == 0 && vSpace[x + i, y - i] == 1 && vSpace[x - i, y - i] == 0)
                        {
                            vSpace[x, y] = 0;
                        }
                        if (vSpace[x + i, y + i] == 0 && vSpace[x - i, y + i] == 0 && vSpace[x + i, y - i] == 0 && vSpace[x - i, y - i] == 1)
                        {
                            vSpace[x, y] = 0;
                        }

                    }
                }
            }

        }

        //creates the console display
        public string Display()
        {
            string reader = "";
            for (int x = 1; x < (vHeight - 1); x++)
            {
                for (int y = 1; y < (vWidth - 1); y++)
                {
                    if (vSpace[x, y] == 1)
                    {
                        reader += "1";
                    }
                    if (vSpace[x, y] == 2)
                    {
                        reader += "2";
                    }
                    
                    if (vSpace[x, y] == 0)
                    {
                        reader += "0";
                    }
                }
            vDisplay += "l" + reader;
            reader = "";
        }
            return vDisplay;
        }

        public int[,] getMap()
        {
            return vSpace;
        }
      
    }

}
