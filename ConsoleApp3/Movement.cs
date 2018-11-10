using System;
namespace ConsoleApp3
{
    public class Movement
    {
        public int MoveX { get; set; }

        public int MoveY { get; set; }

        public int? AttackThis { get; set; }

        public Movement(int x, int y, int ? attack)
        {
            this.MoveX = x;
            this.MoveY = y;
            this.AttackThis = attack;
        }
    }
}
