using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ConsoleApp3
{
    public class SelectUnits
    {
        public string[] Names { get; set; }

        public int[] Numbers { get; set; }

        public SelectUnits()
        {
            Names = new string[5];
            Numbers = new int[5];
        }
    }
}
