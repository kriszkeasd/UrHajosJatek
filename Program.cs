using System.Diagnostics;
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


        static void AnyahajoMozgat()
        {
            Console.CursorVisible = false;
            while (true)
            {
                char beolvasas = Console.ReadKey(true).KeyChar;
                if (beolvasas == 'a')
                {
                    if (jatekosHely > 0)
                    {
                        jatekosHely--;
                    }
                }
                else if (beolvasas == 'd')
                {
                    if (jatekosHely < oszlop - 1)
                    {
                        jatekosHely++;
                    }
                }
                AnyahajoKirajzol();
            }
        }




        static void EllensegMozgat()
        {
            Stopwatch ora = Stopwatch.StartNew();

            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;

            const int gyorsKozMs = 250;
            const int lassuKozMs = 1000;

            while (ora.ElapsedMilliseconds < 3000)
            {
                long most = ora.ElapsedMilliseconds;

                if (most - utolsoGyorsEsemeny >= gyorsKozMs)
                {
                    Console.Write(".");
                    utolsoGyorsEsemeny = most;
                }

                if (most - utolsoLassuEsemeny >= lassuKozMs)
                {
                    Console.Write(" [1 mp] ");
                    utolsoLassuEsemeny = most;
                }

            }
        }




            //static void Lovesek()
            //{

            //    Console.CursorVisible = true;
            //    while (true)
            //    {
            //        Console.SetCursorPosition(anyahajo, sor + 1);

            //        char beolvasas2 = Console.ReadLine()[0];
            //        Console.SetCursorPosition(0, oszlop + 1);
            //        Console.WriteLine(" ");
            //        if (beolvasas2 == 'w')
            //        {
            //            oszlop++;
            //        }
            //    }
            //}










            static void Main(string[] args)
            {
                AlapHelyzet();
                PalyaKirajzol();
                EllensegMozgat();
                AnyahajoMozgat();

                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("           JÁTÉK VÉGE!            ");
                Console.WriteLine($"     Elért pontszámod: {pontSzam}");
                Console.WriteLine("==================================");
            }
        }
    }




