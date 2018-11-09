using System;
namespace ConsoleApp3
{
    public class Match
    {
        public int ID { get; set; }
        public int Count { get; set; }
        public int CountAtStart { get; set; }
        public int LastHP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string HeroName { get; set; }
        public int HeroAttach { get; set; }
        public int HeroDefense { get; set; }
        public int HeroSpeed { get; set; }

        public bool IsReverse { get; set; }
        public int DamageCaused { get; set; }
        public int DistanceCovered { get; set; }
        public int HeroTotalHP { get; set; }

        public string Filename { get; set; }
        public string Race { get; set; }
        public int Rank { get; set; }
        public string UnitName { get;  set; }
        public int HP { get; set; }
        public int UnitAttack { get; set; }
        public int UnitDefense { get; set; }
        public int UnitDmgMin { get; set; }
        public int UnitDmgMax { get; set; }
        public int UnitSpeed { get; set; }
        public int Shoot { get; set; }
        public bool CanShoot { get; set; }
        public int Price { get; set; }
        public int Specials { get; set; }

        public bool RetalieatedThisRound{ get; set; }
        public int TotalHP {  get; set; }
        public int Speed{ get; set; }
        public int Attack{ get; set; }
        public int Defense { get; set; }




    }
}
