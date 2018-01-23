using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace WindowsFormsApp1
{
static class Program
{
    static String WybierzPlik()
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        openFileDialog1.InitialDirectory = "c:\\";
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            return openFileDialog1.FileName;
        }
        else return "";
    }

    public static int MaxLiczbaWatkow(String plik)
    {
        try
        {
            using (StreamReader sr = new StreamReader(plik))
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
            MessageBox.Show("Problem z odczytem pliku");
            MessageBox.Show(e.Message);
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

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();

            data = null;
            NetworkStream stream = client.GetStream();

            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                String d = String.Concat("Otrzymano ", data);
                MessageBox.Show(d);
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

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        String plik = WybierzPlik();

        int maxLiczbaWatkow = MaxLiczbaWatkow(plik);
        String wiadomosc = String.Concat("Maksymalna liczba wątków: ", maxLiczbaWatkow);
        MessageBox.Show(wiadomosc);

        int liczbaWatkow = losujLiczbeWatkow(maxLiczbaWatkow);
        wiadomosc = String.Concat("Wylosowana liczba wątków: ", liczbaWatkow);

        Thread watekSerwera = new Thread(Server);
        watekSerwera.Start();

        MessageBox.Show("Zaczynamy test");

        Thread.Sleep(1000);

        for (int i = 0; i < liczbaWatkow; i++)
        {
            Thread watekKlienta = new Thread(Client);
            watekKlienta.Start(i);
        }

        Thread.Sleep(10000);

        MessageBox.Show("Koniec programu");
    }
}
}
