using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Dragon
    {
        //constante
        private const char Seprarator = ';';

        private const int ID = 0;
        private const int NAME = 1;
        private const int DIFFICULTY = 2;
        private const int LOOT = 3;
        private const int HEALTHPOINTS = 4;
        
        //identificare intre stagiu si dragon
        public int IdDragon { get; set; }
        public string Name { get; set; }
        public int Difficulty {  get; set; }
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
            IdDragon = 0;
            Name = name;
            Difficulty = difficulty;
            Loot = loot;
            HealthPoints = 20*Difficulty;
        }

        public Dragon(string linieFisier)
            {
            string[] dateFisier = linieFisier.Split(Seprarator);
            this.IdDragon = Convert.ToInt32(dateFisier[ID]);
            this.Name = dateFisier[NAME];
            this.Difficulty = Convert.ToInt32(dateFisier[DIFFICULTY]);
            this.Loot = Convert.ToInt32(dateFisier[LOOT]);
            this.HealthPoints = float.Parse(dateFisier[HEALTHPOINTS]);

            }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectDragonFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                Seprarator,
                IdDragon.ToString(),
                (Name ?? "NECUNSOCUT"),
                Difficulty.ToString(),
                Loot.ToString(),
                HealthPoints.ToString());
            return obiectDragonFisier;
        }

        public string InfoDragon()
        {
            return $"Dragon`s Name: {Name} ID: {IdDragon} Difficulty: {Difficulty} Loot: {Loot} Gold HealthPoints: {HealthPoints}";
        }
    }
}
