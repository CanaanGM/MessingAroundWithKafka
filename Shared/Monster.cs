namespace Shared
{
    public class Monster
    {
        public int Inti { get; set; }
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public string Name { get; set; }

        public Monster()
        {

        }

        public Monster(int inti, int vitality, int strength, int agility, string name)
        {
            Inti = inti;
            Vitality = vitality;
            Strength = strength;
            Agility = agility;
            Name = name;
        }
    }
}