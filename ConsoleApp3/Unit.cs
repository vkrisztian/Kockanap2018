﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Unit
    {

        public string Filename { get; set; }
        public string Race { get; set; }
        public double Rank { get; set; }
        public string Name { get; set; }
        public double HP { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public double DmgMin { get; set; }
        public double DmgMax { get; set; }
        public double Speed { get; set; }
        public double Shoot { get; set; }
        public bool CanShoot { get; set; }
        public double Price { get; set; }
        public double Specials { get; set; }
    }
    enum Special {Wide=1,Fly=2,Ray=4,Always=8,RoundAttack=16,NoMeleePenalty=32,Twice=64, Regenerates = 128, NoRetal=256,SucksBlood=512,Blast=1024};
    public class ModUnit : Unit
    {
        public double Fitness { get; set; }
    }
}
