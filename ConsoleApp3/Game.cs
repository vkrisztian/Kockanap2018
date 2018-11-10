using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class Game
    {
        static List<Entity> entities = new List<Entity>();

        public static List<Entity> Entities { get { return entities; } }

        public static void Update(Entity entity)
        {
            Entity entityToUpdate = entities.Find(x => x.ID == entity.ID);
            entityToUpdate = entity;
        }

        public static Movement CalculateMove(int id,string [] ours,string[]theirs)
        {
            Movement move = new Movement(0, 0,null);
           
            List<Entity> our = new List<Entity>();
            List<Entity> their = new List<Entity>();
            
            Entity ToMove = entities.Find(x => x.ID == id);
            for (int i = 0; i < ours.Length; i++)
            {
                our.Add(Entities.Find(x => x.ID == int.Parse(ours[i])));
            }
              for (int i = 0; i < theirs.Length; i++)
            {
                their.Add(Entities.Find(x => x.ID == int.Parse(theirs[i])));
            }
            /*
            string[,] irat = new string[11, 9];
            for (int i = 0; i < irat.GetLength(0); i++)
            {
                for (int j = 0; j < irat.GetLength(1); j++)
                {
                    irat[i, j] = "_";
                }
            }
            for (int i = 0; i < our.Count; i++)
            {
                if(our[i]!=null)
                    irat[(int)our[i].X, (int)our[i].Y] = "O";
            }
            
            for (int i = 0; i < their.Count; i++)
            {
                if (their[i] != null)
                    irat[(int)their[i].X, (int)their[i].Y] = "X";
            }
            Console.Clear();
            for (int i = 0; i < irat.GetLength(1); i++)
            {
                for (int j = 0; j < irat.GetLength(0); j++)
                {
                    
                    Console.Write(irat[j,i]+"  ");
                }
                Console.Write("\n\n");
            }*/
            
            bool canKill2turns = false;
            Entity toKill = null;
            Entity toAttack = null;
            if (ToMove.Unit.CanShoot)
            {
                double dmg = (ToMove.Unit.DmgMax + ToMove.Unit.DmgMin) / 2;
                foreach (var item in their)
                {
                    if ((item.Unit.HP * item.Count) <= item.Attack)
                    {

                        if (toKill != null && toKill.Unit.Rank < item.Unit.Rank)
                        {
                            toKill = item;
                        }
                        else if (toKill == null)
                        {
                            toKill = item;
                        }
                    }
                    else if ((item.Unit.HP * item.Count) <= item.Attack / 2)
                    {
                        if (toAttack == null)
                        {
                            canKill2turns = true;
                            toAttack = item;
                        }
                        else if (toAttack.Unit.Rank < item.Unit.Rank)
                        {
                            toAttack = item;
                        }
                    }
                    else if (item.Unit.CanShoot && !canKill2turns)
                    {
                        if (toAttack == null)
                        {
                            toAttack = item;
                        }
                        else if (toAttack.Unit.Rank < item.Unit.Rank)
                        {
                            toAttack = item;
                        }
                    }
                    
                }
            }
            else
            {

            }


            if (!canKill2turns)
            {
                move.AttackThis = getClosestEnemy(ToMove,their);
            }
            if (toKill != null)
            {
                move.AttackThis = toKill.ID;
            }
            else if(toAttack != null)
            {
                move.AttackThis = toAttack.ID;
            }
            return move;
        }

        public static ModUnit[] Olvas ()
        {
            StreamReader sr = new StreamReader("../../THIS.csv");
            List<string[]> kezdo = new List<string[]>();
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                kezdo.Add(sr.ReadLine().Replace("y,","").Replace("l,", "").Replace("k,", "").Replace("e,", "").Split(','));
            }
            sr.Close();
            ModUnit[] back = new ModUnit[kezdo.Count];
            for (int i = 0; i < back.Length; i++)
            {
                for (int j = 0; j < kezdo.ElementAt(i).Length; j++)
                {
                    kezdo.ElementAt(i)[j] = kezdo.ElementAt(i)[j].Substring(1, kezdo.ElementAt(i)[j].Length - 2);
                }
                back[i] = new ModUnit()
                {
                    Filename = kezdo.ElementAt(i)[0].ToString(),
                    Race = kezdo.ElementAt(i)[1].ToString(),
                    Rank = int.Parse(kezdo.ElementAt(i)[2].ToString()),
                    Name = kezdo.ElementAt(i)[3].ToString(),                   
                    HP = int.Parse(kezdo.ElementAt(i)[4].ToString()),
                    Attack = int.Parse(kezdo.ElementAt(i)[5].ToString()),
                    Defense = int.Parse(kezdo.ElementAt(i)[6].ToString()),
                    DmgMin = int.Parse(kezdo.ElementAt(i)[7].ToString()),
                    DmgMax = int.Parse(kezdo.ElementAt(i)[8].ToString()),
                    Speed = int.Parse(kezdo.ElementAt(i)[9].ToString()),
                    Shoot = (kezdo.ElementAt(i)[10].ToString()!="")?int.Parse(kezdo.ElementAt(i)[10].ToString()):1,
                    Price = int.Parse(kezdo.ElementAt(i)[11].ToString()),
                    Specials = 0,

                    Fitness = double.Parse(kezdo.ElementAt(i)[14].Replace(".",",").ToString())
                };

            }
            return back;
        }
        public static SelectUnits PickSquad(int money)
        {
            SelectUnits su = new SelectUnits();
            double cash = money;

            string[] names = { "VampireLord", "Ranger", "Skeleton" , "Skeleton" , "Skeleton" };
            double[] costs = new double[5];
            int[] number = new int[5];

           
            ModUnit[] mu = Olvas();
            for (int i = 0; i < names.Length ; i++)
            {
                for (int j = 0; j < mu.Length; j++)
                {
                    if (names[i]==mu[j].Name)
                    {
                        costs[i] = mu[j].Price;
                    }                    
                }         
            }
            number[0] = (money / 2 )/ (int)costs[0]; // VampireLord
            money /= 2;
            number[1] = (money / 2) / (int)costs[1]; // Ranger
            money /= 2;
            int skeletons = (money) / (int)costs[2];

            number[2] = skeletons - 2*(skeletons/3);
            skeletons -= number[2];

            number[3] = skeletons /2;
            skeletons -= number[3];

            number[4] = skeletons ;


          

            su.Names = names;
            su.Numbers = number;
            return su;
        }

        public static int getClosestEnemy(Entity our,List<Entity>their)
        {
            int toAttackId = 0;
            double minDistance = double.MaxValue;

            foreach (var item in their)
            {
                double distance = Math.Sqrt((Math.Pow((item.X - our.X), 2) + Math.Pow((item.Y - our.Y), 2)));
                if (minDistance > distance)
                {
                    minDistance = distance;
                    toAttackId = item.ID;
                }
            }


            return toAttackId;
        }
    }
}
