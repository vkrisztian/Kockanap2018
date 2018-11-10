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

        public static Movement CalculateMove(int id)
        {
            Movement move = null;


            return move;
        }

        public static ModUnit[] Olvas ()
        {
            StreamReader sr = new StreamReader("../THIS.csv");
            List<string[]> kezdo = new List<string[]>();
            while (!sr.EndOfStream)
            {
                kezdo.Add(sr.ReadLine().Split(','));
            }
            sr.Close();
            ModUnit[] back = new ModUnit[kezdo.Count];
            for (int i = 0; i < back.Length; i++)
            {
                back[i] = new ModUnit()
                {
                    Filename = kezdo.ElementAt(i)[0],
                    Race = kezdo.ElementAt(i)[1],
                    Name = kezdo.ElementAt(i)[2],
                    Rank = int.Parse(kezdo.ElementAt(i)[3]),
                    HP = int.Parse(kezdo.ElementAt(i)[4]),
                    Attack = int.Parse(kezdo.ElementAt(i)[5]),
                    Defense = int.Parse(kezdo.ElementAt(i)[6]),
                    DmgMin = int.Parse(kezdo.ElementAt(i)[7]),
                    DmgMax = int.Parse(kezdo.ElementAt(i)[8]),
                    Speed = int.Parse(kezdo.ElementAt(i)[9]),
                    Shoot = int.Parse(kezdo.ElementAt(i)[10]),
                    Price = int.Parse(kezdo.ElementAt(i)[11]),
                    Specials = 0,
                    Fitness = double.Parse(kezdo.ElementAt(i)[14])
                };

            }
            return back;
        }

       
    }
}
