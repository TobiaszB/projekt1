using System;
using System.IO;

class Program
{
    public static int MaxLiczbaWatkow()
    {
        try
        {
            using (StreamReader sr = new StreamReader("MaxLiczbaWatkow.txt"))
            {
                string line = sr.ReadLine();
                int maxLiczbaWatkow = int.Parse(line);
                if (maxLiczbaWatkow < 2)
                    return 2;
                else if (maxLiczbaWatkow > 100)
                    return 100;
                else
                    return maxLiczbaWatkow;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Problem z odczytem pliku");
            Console.WriteLine(e.Message);
        }
        //wartość domyślna
        return 5;
    }

    public static int losujLiczbeWatkow(int max)
    {
        Random rnd = new Random();
        return rnd.Next(2, max);
    }

    static void Main()
    {
        System.Console.WriteLine("projekt1");

        int maxLiczbaWatkow = MaxLiczbaWatkow();
        Console.Write("Maksymalna liczba wątków: ");
        Console.WriteLine(maxLiczbaWatkow);

        int liczbaWatkow = losujLiczbeWatkow(maxLiczbaWatkow);
        Console.Write("Wylosowana liczba wątków: ");
        Console.WriteLine(liczbaWatkow);
    }
}
