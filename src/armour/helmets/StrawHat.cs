using System;

namespace GladiatorGame.Gear.Helmets
{

    public class StrawHat : IHelmet
    {
        public StrawHat()
        {
            this.Name = "Straw Hat";
            this.SetArmour();       
        }

        public void SetArmour(int newArmourValue = 10)
        {
            this.Armour = newArmourValue;
        }

        public int Armour { get; set; }
        public string Name { get; set; }
    }

}