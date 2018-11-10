using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    public class UDPServer
    {
        public void Listen()
        {
            UdpClient listener = new UdpClient(1940);
            //1.15
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.1.34"), 1940); // 123 módosítani
            //IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.1.34"), 1940);
            while (true)
            {
                byte[] data = listener.Receive(ref serverEP);
                RaiseDataReceived(new ReceivedDataArgs(serverEP.Address, serverEP.Port, data));
            }
        }
        public delegate void DataReceived(object sender, ReceivedDataArgs args);
        public event DataReceived DataReceivedEvent;
        private void RaiseDataReceived(ReceivedDataArgs args)
        {
            if (DataReceivedEvent != null)
                DataReceivedEvent(this, args);
        }
    }
    public class ReceivedDataArgs
    {
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
        public byte[] ReceivedBytes;
        public ReceivedDataArgs(IPAddress ip, int port, byte[] data)
        {
            this.IpAddress = ip;
            this.Port = port;
            this.ReceivedBytes = data;
        }
    }
    public class HandleDataClass
    {
        public void SubscribeToEvent(UDPServer server)
        {
            server.DataReceivedEvent += server_DataReceivedEvent;
        }

        void server_DataReceivedEvent(object sender, ReceivedDataArgs args)
        {
            /*Console.WriteLine("Received message from [{0}:{1}]:\r\n{2}",
                args.IpAddress.ToString(), args.Port.ToString(),
                Encoding.ASCII.GetString(args.ReceivedBytes));*/
            Entity unit = JsonConvert.DeserializeObject<Entity>(Encoding.ASCII.GetString(args.ReceivedBytes));
            if (Game.Entities.Find(x=> x.ID == unit.ID) == null)
            {
                Game.Entities.Add(unit);
            }
            else
            {
                Game.Update(unit);
            }
        }
    }

}
