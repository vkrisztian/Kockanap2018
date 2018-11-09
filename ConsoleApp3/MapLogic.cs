using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MapLogic
    {
        // Úgy szar ahogy van
        bool[,] map = new bool[11, 9];

        public string[] enemieNames = new string[5];
        public string[] ourNames = new string[5];
        public int[] enemyNumbers = new int[5];
        public int[] ourNumbers = new int[5];

        public void Modosit(List<Entity> lista)
        {
        }
        

        public int[,] FromAttack(int ourX, int ourY, int ourRange, int enemyX, int enemyY)
        {

            return null;
        }
    }
}
