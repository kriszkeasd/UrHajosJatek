using System.Diagnostics;
using System.Numerics;
namespace UrHajosJatek
{
    internal class Program
    {
        static int sor = 20;
        static int oszlop = 40;

        static char[,] palya = new char[sor, oszlop];
        static int[] jateksorIndex = new int[oszlop];
        static int jatekosHely = oszlop / 2;
        static Random r = new Random();
        static int pontSzam = 0;
        static bool jatekVege = false;
        static char ures = ' ';
        static char ellenseg = 'X';
        static char lovedek = '|';
        static char anyahajo = 'A';
        static void AlapHelyzet()
        {
            for (int i = 0; i < oszlop / 10; i++)
            {
                int index = r.Next(1, 39);
                palya[0, index] = ellenseg;
            }
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (palya[i, j] != ellenseg)
                    {
                        palya[i, j] = ures;
                    }
                }
            }
        }
        
            
         

        static void PalyaKirajzol()
        {
            Console.Clear();
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (i == sor - 1 && j == jatekosHely)
                    {
                        Console.Write(anyahajo);
                    }
                    else
                    {
                        Console.Write(palya[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void AnyahajoKirajzol()
        {
            Console.SetCursorPosition(jatekosHely-1, sor - 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(jatekosHely + 1, sor - 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(jatekosHely, sor - 1);
            Console.Write(anyahajo);
        }



        static void EllensegMozgat()
        {
            Stopwatch ora = Stopwatch.StartNew();
            Console.CursorVisible = false;

            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;

            const int gyorsKozMs = 500;
            const int lassuKozMs = 1000;

            while (ora.ElapsedMilliseconds < 10000 )
            {
                for (int i = 0; i < oszlop / 10; i++)
                {
                    int index = r.Next(1, 39);
                    palya[0, index] = ellenseg;
                }
                for (int i = 0; i < sor; i++)
                {
                    for (int j = 0; j < oszlop; j++)
                    {
                        if (palya[i, j] != ellenseg)
                        {
                            palya[i, j] = ures;
                        }
                    }
                }

                long most = ora.ElapsedMilliseconds;
                if (Console.KeyAvailable)
                {
                    char billentyu = Console.ReadKey(true).KeyChar;

                    if (billentyu == 'a' && jatekosHely > 0)
                    {
                        jatekosHely--;
                    }
                    else if (billentyu == 'd' && jatekosHely < oszlop - 1)
                    {
                        jatekosHely++;
                    }
                    AnyahajoKirajzol();

                    
                }
                if (most - utolsoGyorsEsemeny >= gyorsKozMs)
                {
                    for (int i = palya.GetLength(0) - 2; i >= 0; i--)
                    {
                        for (int j = 0; j < palya.GetLength(1); j++)
                        {
                            if (palya[i, j] == ellenseg)
                            {
                                if (i + 1 == sor - 1)
                                {
                                    jatekVege = true;
                                }
                                else
                                {
                                    palya[i + 1, j] = ellenseg;
                                    palya[i, j] = ures;
                                }
                            }
                        }
                    }
                PalyaKirajzol();
                utolsoGyorsEsemeny = most;
                }
                if (most - utolsoLassuEsemeny >= lassuKozMs)
                {
                    utolsoLassuEsemeny = most;
                }

            }
            
           
        }

        static void Lovedek()
        {
            char billentyu = Console.ReadKey(true).KeyChar;

            
        }









                static void Main(string[] args)
            {
                AlapHelyzet();
                PalyaKirajzol();
                EllensegMozgat(); 
                Lovedek();
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("           JÁTÉK VÉGE!            ");
                Console.WriteLine($"     Elért pontszámod: {pontSzam}");
                Console.WriteLine("==================================");
            }
        }
    }




