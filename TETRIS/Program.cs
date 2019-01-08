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
            byte[,] plansza = new byte[24,12];
            while(true)
            {
                plansza[0, 3] = 1;
                plansza[1, 3] = 1;
                plansza[1, 2] = 1;
                plansza[1, 4] = 1;
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
                    bool ruchPoprawny = wDół(plansza, ruch);
                    if (ruchPoprawny == false)
                    {
                        i--;
                    }
                    
                }

            }
            Console.ReadKey();
                
        }

        static bool wDół(byte[,] plansza, int kierunek)
        {
            bool ruchPoprawny = true;
            for (int i = plansza.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = plansza.GetLength(1) - 1; j >= 0; j--)
                {
                    int szerokosc = plansza.GetLength(1);
                    int nastepneJ = j + kierunek;
                    if (plansza[i, j] == 1)
                    {
                        if (nastepneJ >= szerokosc || nastepneJ < 0)
                        {
                            ruchPoprawny = false;
                            break;
                        }
                        if (i + 1 < plansza.GetLength(0) && plansza[i + 1, nastepneJ] > 1)
                        {
                            ruchPoprawny = false;
                            break;
                        }
                    }
                }
            }

            if (!ruchPoprawny) 
            {
                for(int i = plansza.GetLength(0) - 1; i>=0 ; i--)
                {
                    for(int j = plansza.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (plansza[i, j] == 1)
                        {
                            plansza[i, j] = 2;
                        }
                    }
                }
            } 
            else
            {
                for (int i = plansza.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = plansza.GetLength(1) - 1; j >= 0; j--)
                    {
                        int szerokosc = plansza.GetLength(1);
                        int nastepneJ = j + kierunek;
                        if (nastepneJ < szerokosc && nastepneJ >= 0)
                        {
                            if (plansza[i, j] == 1 && i + 1 < plansza.GetLength(0)
                                && 0 == plansza[i + 1, nastepneJ])
                            {
                                plansza[i + 1, nastepneJ] = 1;
                                plansza[i, j] = 0;
                            }
                            else if (plansza[i, j] == 1)
                            {
                                plansza[i, j] = 2;
                            
                            }
                        }

                    }
                }

            }
            
            return ruchPoprawny;
        }

        static void wyswietlStan(byte[,] plansza)
        {
            Console.Clear();
            for (int i = 0; i < plansza.GetLength(0); i++)
            {
                for (int j = 0;  j<plansza.GetLength(1); j++)
                {
                    if(plansza[i,j] != 0)
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
