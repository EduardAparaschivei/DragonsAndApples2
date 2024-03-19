using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        string Name;
        public float HealthPoints { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public float Money { get; set; }
        public int AbilityPoints { get; set; } = 5;

        static int AbilityCapPoints = 10;
        public Player()
        {
            Name = string.Empty;
            Strength = 0;
            Intelligence = 0;
            Agility = 0;
            Money = 0;
            HealthPoints = 100;

        }

        public Player(string name)
        {
            Name = name;
            Strength = 0;
            Intelligence = 0;
            Agility = 0;
            Money = 0;
            HealthPoints = 100;
        }

        public Player(string name, int strength, int intelligence, int agility)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Agility = agility;
            Money = 0;
            HealthPoints = 100;
        }
        public string Info()
        {
            return $"Name: {Name} Strength: {Strength} Intelligence: {Intelligence} Agility: {Agility} Money: {Money}";
        }


    }
}
