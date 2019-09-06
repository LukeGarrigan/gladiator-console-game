using GladiatorGame.Items.ArmourTypes;

namespace GladiatorGame.Items
{
    public abstract class ArmourBase : Item
    {
        public int Armour { get; set; }
        public string Name { get; set; }
        public ArmourType ArmourType { get; set; }
   
        public void OutputStats()
        {
            System.Console.WriteLine(Name);
            System.Console.WriteLine($"Armour: {Armour}");
            System.Console.WriteLine($"Armour Type: {ArmourType}");
        }

    }
}