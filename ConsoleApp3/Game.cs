using System;
using System.Collections.Generic;
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
    }
}
