using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Item
    {
        public string Name;
        public int Damage {  get; set; }
        public int Condition { get; set; }

        public Item() 
        {
            Name = string.Empty;
            Damage = 0;
            Condition = 0;
        }

        public Item(string name, int damage, int condition)
        {
            Name = name;
            Damage = damage;
            Condition = condition;
        }

        public string Info()
        {
            return $"Item: {Name} Damage: {Damage} Condition: {Condition} uses until destruction";
        }
    }
}
