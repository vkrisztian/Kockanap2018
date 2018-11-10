using System;
namespace ConsoleApp3
{
    public class Movement
    {
        public double MoveX { get; set; }

        public double MoveY { get; set; }

        public double? AttackThis { get; set; }

        public Movement(double x, double y, double ? attack)
        {
            this.MoveX = x;
            this.MoveY = y;
            this.AttackThis = attack;
        }
    }
}
