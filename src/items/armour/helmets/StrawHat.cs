using System;
using GladiatorGame.Items.ArmourTypes;

namespace GladiatorGame.Items.Helmets
{
    public class StrawHat : ArmourBase
    {
        public StrawHat()
        {
            this.Name = "Straw Hat";
            this.ArmourType = ArmourType.HELMET;
            this.SetArmour();       
        }

        public void SetArmour(int newArmourValue = 10)
        {
            this.Armour = newArmourValue;
        }
    }

}