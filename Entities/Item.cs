using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Item
    {
        private const char SeparatorFisier = ';';

        private const int IDUL = 0;
        private const int NAME = 1;
        private const int DAMAGE = 2;
        private const int CONDITION = 3;

        public int ID;
        public string Name;
        public int Damage {  get; set; }
        public int Condition { get; set; }

        public Item() 
        {
            ID = 0;
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

        public Item(string linieFisier) 
        {
            string[] dateFisier = linieFisier.Split(SeparatorFisier);
            this.ID =Convert.ToInt32(dateFisier[IDUL]);
            this.Name = dateFisier[NAME];
            this.Damage = Convert.ToInt32(dateFisier[DAMAGE]);
            this.Condition = Convert.ToInt32(dateFisier[CONDITION]);

        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectItempentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SeparatorFisier,
                ID.ToString(),
                (Name ?? "Necunoscut"),
                Damage.ToString(),
                Condition.ToString());
            return obiectItempentruFisier;
        }

        public string Info()
        {
            return $"{Name} D: {Damage} C: {Condition}";
        }
    }
}
