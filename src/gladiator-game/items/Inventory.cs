

using System;
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
            this.Items.Add(new ButterKnife()); // secondary wep, mainly to show that you can switch between 
        }

        public List<Item> Items { get; set; }

        internal void EquipNewWeapon(Weapon newWep)
        {
            System.Console.WriteLine($"You put away the {WieldedWeapon.Name} and equip the {newWep.Name} ");
            this.Items.Add(this.WieldedWeapon);
            this.WieldedWeapon = newWep;
            AddItem(newWep);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void SwitchWeapon(string weaponName)
        {
            var newWep = GetWeaponByName(weaponName);
            if (newWep != null)
            {
                this.Items.Remove(newWep);
                System.Console.WriteLine($"You put away the [{WieldedWeapon.Name}] and equip the [{newWep.Name}] ");
                this.Items.Add(this.WieldedWeapon);
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
            PrintItemsInInventory();
            PrintEquippedItems();
        }
        public void PrintItemsInInventory()
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

        public void PrintEquippedItems()
        {
            System.Console.WriteLine("--------------------------------------------------------------------");
            System.Console.WriteLine("----------------------  Equipped Items  ----------------------------");
            System.Console.WriteLine("--------------------------------------------------------------------");
            WieldedHelmet.OutputStats();
            System.Console.WriteLine();
            WieldedWeapon.OutputStats();
        }

        public void DeleteItem(string name)
        {
            for (var i = Items.Count - 1; i >= 0; i--)
            {
                if (Items[i].Name == name) 
                {
                    Items.Remove(Items[i]);
                }
            }
        }

        public ArmourBase WieldedHelmet { get; set; }
        public Weapon WieldedWeapon { get; set; }

    }

}

