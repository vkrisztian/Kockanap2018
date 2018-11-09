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
            string prefixes = "http://192.168.1.34:1945/lennies/";
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
                string responseString = Calculate();
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

        private static string Calculate()
        {
            
            //JObject json = JObject.Parse(str);
            //return HandleDataClass.cucc.merkozesek.Find(x => x.merkozesazonosito == matchid).Move(player);
            return "";
        }
        
    }
}
