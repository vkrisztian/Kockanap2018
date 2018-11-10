using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
             // simple geometry
            UDPServer server = new UDPServer();
            HandleDataClass hdc = new HandleDataClass();

            var xyz = Game.Olvas();

            Thread serverThread = new Thread(() => server.Listen());
            serverThread.Start();

            Thread dataHandlerThread = new Thread(() =>
            hdc.SubscribeToEvent(server));
            dataHandlerThread.Start();
            Thread http = new Thread(() => httpClient.SimpleListenerExample());
            http.Start();

            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
