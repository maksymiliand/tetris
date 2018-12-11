using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] plansza = new bool[24,12];

            plansza[0, 3] = true;
            plansza[1, 3] = true;
            plansza[1, 2] = true;
            plansza[1, 4] = true;
            for (int i = 0; i < plansza.GetLength(0) - 1; i++)
            {
                wyswietlStan(plansza);
                String decyzja = Console.ReadLine();
                int ruch = 0;
                if (decyzja == "A" || decyzja == "a")
                {
                    ruch = -1;
                } 
                else if (decyzja == "D" || decyzja == "d")
                {
                    ruch = +1;
                }
                else if (decyzja == "S" || decyzja == "s")
                {
                    i--;
                }
                wDół(plansza, ruch);
            }
            Console.ReadKey();
                
        }

        static void wDół(bool[,] plansza, int kierunek)
        {
            for (int i = plansza.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = plansza.GetLength(1) - 1; j >= 0; j--)
                {
                    if (plansza[i, j] == true && i + 1 < plansza.GetLength(0))
                    {
                        plansza[i + 1, j + kierunek] = true;
                        plansza[i, j] = false;
                    }

                }
            }
        }

        static void wyswietlStan(bool[,] plansza)
        {
            Console.Clear();
            for (int i = 0; i < plansza.GetLength(0); i++)
            {
                for (int j = 0;  j<plansza.GetLength(1); j++)
                {
                    if(plansza[i,j] == true)
                    {
                        Console.Write("|X");
                    }
                    else
                    {
                        Console.Write("| ");
                    }

                }
                Console.WriteLine("|");
            }
        }
    }   
}
