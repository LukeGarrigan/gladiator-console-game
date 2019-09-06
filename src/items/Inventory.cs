

using System.Collections.Generic;
using System.Linq;
using System.Text;
using GladiatorGame.Items.Helmets;
using GladiatorGame.Items.Weapons;

namespace GladiatorGame.Items
{

    public class Inventory
    {
        public Inventory()
        {
            this.Items = new List<Item>();
            this.WieldedHelmet = new StrawHat();
            this.WieldedWeapon = new BasicSword();

            this.Items.Add(this.WieldedWeapon);
            this.Items.Add(this.WieldedHelmet);
            this.Items.Add(new ButterKnife()); // secondary wep, mainly to show that you can switch between 
        }

        public List<Item> Items { get; set; }


        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void SwitchWeapon(string weaponName)
        {
            var newWep = GetWeaponByName(weaponName);
            if (newWep != null)
            {
                System.Console.WriteLine($"You put away the [{WieldedWeapon.Name}] and equip the [{newWep.Name}] ");
                this.WieldedWeapon = newWep;
            }
            else
            {
                System.Console.WriteLine($"You do not have a weapon called {weaponName}");
            }
        }

        private Weapon GetWeaponByName(string weaponName)
        {

            var weaponToSwitchTo = (from wep in Items
                                    where wep.Name == weaponName
                                    select wep);

            return (Weapon)weaponToSwitchTo.FirstOrDefault();
        }


        public void OutputInventory()
        {
            System.Console.WriteLine("--------------------------------------------------------------------");
            System.Console.WriteLine("----------------------  Your inventory  ----------------------------");
            System.Console.WriteLine("--------------------------------------------------------------------");
            foreach (var item in Items)
            {
                item.OutputStats();
                System.Console.WriteLine();
            }
        }

        public ArmourBase WieldedHelmet { get; set; }
        public Weapon WieldedWeapon { get; set; }

    }

}

