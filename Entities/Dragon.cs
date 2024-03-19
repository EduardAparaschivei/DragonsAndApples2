using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Dragon
    {
        string Name;
        int Difficulty {  get; set; }
        public int Loot {  get; set; }
        public float HealthPoints { get; set; }

        public Dragon()
        {
            Name = string.Empty;
            Difficulty = 0;
            Loot = 0;
            HealthPoints = 0;
        }

        public Dragon(string name, int difficulty, int loot)
        {
            Name = name;
            Difficulty = difficulty;
            Loot = loot;
            HealthPoints = 20*Difficulty;
        }

        public string InfoDragon()
        {
            return $"Dragon`s Name: {Name} Difficulty: {Difficulty} Loot: {Loot} Gold HealthPoints: {HealthPoints}";
        }
    }
}
