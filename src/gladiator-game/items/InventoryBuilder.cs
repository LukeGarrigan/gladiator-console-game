

using GladiatorGame.Items.ArmourTypes;
using GladiatorGame.Items.Weapons;

namespace GladiatorGame.Items
{
    public class InventoryBuilder
    {

        private Inventory inventory = new Inventory();

        public Inventory HasWeapon(Weapon weapon)
        {
            this.inventory.AddItem(weapon);
            return inventory;
        }

        public Inventory HasWeaponWielded(Weapon weapon)
        {
            this.inventory.EquipNewWeapon(weapon);
            return inventory;
        }

        public Inventory HasArmour(ArmourBase armour)
        {
            this.inventory.AddItem(armour);
            return inventory;
        }

        public Inventory HasHelmetEquipped(ArmourBase armour)
        {
            if (armour.ArmourType.Equals(ArmourType.HELMET))
            {
                this.inventory.EquipNewHelmet(armour);
            }
            return inventory;
        }

    }

}