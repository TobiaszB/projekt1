using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


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


    public static void Server()
    {

        Int32 port = 13000;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        TcpListener server = new TcpListener(localAddr, port);
        server.Start();

        Byte[] bytes = new Byte[256];
        String data = null;

        while(true)
        {
            Console.Write("Czekam na polaczenie... ");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Połączono z klientem!");
            data = null;
            NetworkStream stream = client.GetStream();

            int i;
            while((i = stream.Read(bytes, 0, bytes.Length))!=0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Otrzymano: {0}", data);
            }

            client.Close();
        }
        //server.Stop();
    }

    public static void Client(object numer)
    {
        string server = "127.0.0.1";
        Int32 port = 13000;
        TcpClient client = new TcpClient(server, port);
        int numerKlienta = Convert.ToInt32(numer);

        string wiadomosc = String.Concat("wiadomosc od klient nr ", numerKlienta);
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(wiadomosc);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);

        stream.Close();
        client.Close();
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

        Thread watekSerwera = new Thread(Server);
        watekSerwera.Start();

        Thread.Sleep(1000);

        for (int i = 0; i < liczbaWatkow; i++)
        {
            Thread watekKlienta = new Thread(Client);
            watekKlienta.Start(i);
        }

        Thread.Sleep(5000);

    }
}
