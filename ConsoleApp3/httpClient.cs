using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class httpClient
    {
        public static void SimpleListenerExample()
        {
            string prefixes = "http://192.168.1.31:1945/lennies/";
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add(prefixes);

            listener.Start();
            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                string raw = request.Url.Query;
                // Obtain a response object.
              
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "";
                if (raw.Contains("squadMoney"))
                {
                    string[] amount = raw.Split('=');
                    responseString = CalculateSquad(int.Parse(amount[1]));
                }
                else
                {
                    responseString = Calculate(raw);
                }
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                //You must close the output stream.
                output.Close();
               // listener.Stop();
            }

        }

        private static string Calculate(string raw)
        {
            string [] parameters = raw.Split('&');

            string[] ours = parameters[0].Split('=');
            string[] theirs = parameters[1].Split('=');
            int id = int.Parse(parameters[2].Split('=')[1]);
            //return HandleDataClass.cucc.merkozesek.Find(x => x.merkozesazonosito == matchid).Move(player);
            Movement move = Game.CalculateMove(id);
            var res = JsonConvert.SerializeObject(move);
            return res;
        }
        private static string CalculateSquad(int amount)
        {
            SelectUnits su = new SelectUnits();
            su.Names[0] = "Skeleton";
            su.Names[1] = "VampireLord";
            su.Names[2] = "PowerLich";
            su.Names[3] = "BoneDragon";
            su.Names[4] = "Peasant";

            su.Numbers[0] = 80;
            su.Numbers[1] = 11;
            su.Numbers[2] = 12;
            su.Numbers[3] = 13;
            su.Numbers[4] = 14;

            var res = JsonConvert.SerializeObject(su);
            return res;

        }
    }
}
