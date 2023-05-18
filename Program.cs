using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Be();
            Atlagmagassag();
            MaxHegy();
            magasabb();
        }
        static List<hegycsucs> hegyek = new List<hegycsucs>();
        static List<double> magashegyek = new List<double>();
        static void Be()
        {
            StreamReader beolvas = new StreamReader("hegyek.txt");
            beolvas.ReadLine();
            while (!beolvas.EndOfStream)
            {
                string[] data = beolvas.ReadLine().Split(';');
                hegyek.Add(new hegycsucs(data[0], data[1], int.Parse(data[2])));
            }
            beolvas.Close();
            Console.WriteLine($"Hegycsúcsok száma: {hegyek.Count} db");
        }

        


        static void MaxHegy()
        {
            string neve, hegyseg = "";
            int magassag, max = 0;
            foreach (var index in hegyek)
            {
                if (max <index.Magassag)
                    {magassag = index.Magassag;
                    neve = index.Hegycsúcs;
                    max = index.Magassag;
                    hegyseg = index.Hegyseg;}
            }
            Console.WriteLine($"neve: {neve}, Hegység: {hegyseg}, Magassag: {magassag}m");
            Console.WriteLine($"legmagasabb:");
        }

        static void Atlagmagassag()
        {
            double atlagmagassag = 0;
            double sum = 0;
            foreach (var i in hegyek)
            {sum = sum + i.Magassag;}
            atlagmagassag = sum / hegyek.Count;
            Console.WriteLine($"átlag: {atlagmagassag}");
        }
        static void magasabb()
        {
            Console.Write("magassag: ");
            int vegeredmeny = 0;
            int RL = int.Parse(Console.ReadLine());
            foreach (var i in hegyek)
            {
                if (i.Hegyseg.Contains("Börzsöny"))
                {
                    if (RL < i.Magassag)
                    {vegeredmeny = i.Magassag;
                        Console.WriteLine($"Van magasabb hegycsúcs {RL}-nél, {vegeredmeny}.");
                        break;}
                    else
                    {Console.WriteLine($"{RL}m-nél nincs magasabb.");
                        break;}
                }
            }
        }
    }
}