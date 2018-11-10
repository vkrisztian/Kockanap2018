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

       
    }
}
