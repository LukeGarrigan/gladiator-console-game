using GladiatorGame.Items;
using GladiatorGame.Items.Weapons;

namespace GladiatorGame.Entities
{


    public interface IEntity
    {
        string Name { get; set; }
        Weapon Weapon { get; set; }
        ArmourBase Armour { get; set; }
        int Health { get; set; }

        void TakeDamage(int attackDamage);
    }

}