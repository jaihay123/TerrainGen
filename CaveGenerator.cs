using System;

namespace CaveGenerator
{
    class Cave
    {
        int height;
        int width;
        int density;
        int mx = 2;
        int mn = 0;
        int[,] space;
        string display = "";
        public Cave(int h, int w, int d)
        {
            height = h;
            width = w;
            density = d;
            space = new int[height, width];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    space[x, y] = 0;

                }
            }
        }

        public void Generate()
        {
            display = "";
            Random rand = new Random();
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {

                    if (rand.Next(0, 100) < density)
                    {
                        space[x, y] = 1;
                    }
                }
            }
            for (int x = mx; x < (height - mx); x++)
            {
                for (int y = mx; y < (width - mx); y++)
                {
                    if (space[x, y] == 1)
                    {
                        for (int xa = x; xa < (x + rand.Next(mn, mx)); xa++)
                        {
                            for (int ya = y; ya < (y + rand.Next(mn, mx)); ya++)
                            {
                                space[xa, ya] = 1;
                            }
                        }
                        for (int xb = x; xb > (x - rand.Next(mn, mx)); xb--)
                        {
                            for (int yb = y; yb > (y - rand.Next(mn, mx)); yb--)
                            {
                                space[xb, yb] = 1;
                            }
                        }
                    }

                }


            }
            for (int i = 0; i < 5; i++)
            { 
            for (int x = 1; x < height - 1; x++)
            {
                    for (int y = 1; y < width - 1; y++)
                    {
                        if (space[x, y] == 0)
                        {
                            if (space[x + 1, y] == 1 && space[x - 1, y] == 1)
                            {
                                if (space[x, y + 1] == 1 && space[x, y - 1] == 1)
                                {
                                    space[x, y] = 1;
                                }
                            }
                            if (space[x + 1, y] == 0 && space[x - 1, y] == 1)
                            {
                                if (space[x, y + 1] == 0 && space[x, y - 1] == 1)
                                {
                                    space[x, y] = 1;
                                }
                            }
                            if (space[x + 1, y] == 1 && space[x - 1, y] == 0)
                            {
                                if (space[x, y + 1] == 1 && space[x, y - 1] == 0)
                                {
                                    space[x, y] = 1;
                                }
                            }
                            if (space[x + 1, y] == 0 && space[x - 1, y] == 1)
                            {
                                if (space[x, y + 1] == 1 && space[x, y - 1] == 0)
                                {
                                    space[x, y] = 1;
                                }
                            }
                            if (space[x + 1, y] == 1 && space[x - 1, y] == 0)
                            {
                                if (space[x, y + 1] == 0 && space[x, y - 1] == 1)
                                {
                                    space[x, y] = 1;
                                }
                            }

                        }
                    }
                }
            }
        }

        public string Display()
        {
            string reader = "";
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (space[x, y] == 1)
                    {
                        reader += ":";
                    }
                    else
                    {
                        reader += "|";
                    }

                }

                display += "\n" + reader;
                reader = "";
            }
            return display;
        }
    }

}
