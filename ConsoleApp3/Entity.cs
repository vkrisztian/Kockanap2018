using System;
namespace ConsoleApp3
{
    public class Entity
    {
        public double ID { get; set; }
        public double Count { get; set; }
        public double CountAtStart { get; set; }
        public double LastHP { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Hero Hero { get; set; }
        public Unit Unit { get; set; }

        public bool RetalieatedThisRound{ get; set; }
        public double TotalHP {  get; set; }
        public double Speed{ get; set; }
        public double Attack{ get; set; }
        public double Defense { get; set; }




    }
}
