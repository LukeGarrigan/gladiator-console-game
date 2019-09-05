using GladiatorGame.Weapons;
using System.Collections.Generic;
using GladiatorGame.Attacker;
using GladiatorGame.Entities;
using System;
using System.Linq;
using GladiatorGame.Gear;
using GladiatorGame.Gear.Helmets;

namespace GladiatorGame.Players
{

    public class Player : IEntity, IAttacker<IEntity>
    {
        List<Weapon> weapons = new List<Weapon>();

        public Player(string name)
        {
            this.Health = 100;
            this.Name = name;
            SetupPlayerItems();
            System.Console.WriteLine($"You have equiped a [{Weapon.Name}] which does damage from [{Weapon.MinDamage}-{Weapon.MaxDamage}] every [{Weapon.AttackSpeed}s]");
        }

        private void SetupPlayerItems()
        {
            this.Helmet = new StrawHat();
            this.Weapon = new BasicSword();

            this.weapons.Add(this.Weapon);
            this.weapons.Add(new ButterKnife()); // secondary wep, mainly to show that you can switch between 
        }

        public void SwitchWeapon(string weaponName)
        {
            var newWep = GetWeapon(weaponName);
            if (newWep != null)
            {
                System.Console.WriteLine($"You put away the [{Weapon.Name}] and equip the [{newWep.Name}] ");
                this.Weapon = newWep;
            }
            else
            {
                System.Console.WriteLine($"You do not have a weapon called {weaponName}");
            }
        }

        private Weapon GetWeapon(string weaponName)
        {
            var weaponToSwitchTo = (from wep in weapons
                                    where wep.Name == weaponName
                                    select wep);

            return weaponToSwitchTo.FirstOrDefault();
        }

        public void EquipNewWeapon(Weapon newWep)
        {
            this.weapons.Add(newWep);
            System.Console.WriteLine($"You put away the {Weapon.Name} and equip the {newWep.Name} ");
            this.Weapon = newWep;
        }

        public int Attack(IEntity enemy)
        {
            var attackDamage = Weapon.DoAttack();
            enemy.Health -= attackDamage;
            var enemyHealth = enemy.Health < 0 ? 0 : enemy.Health;

            System.Console.WriteLine(String.Format("|{0, 20}|{1, 20}|", $"{Health} (0) ", $"{enemyHealth} (-{attackDamage}) "));
            return attackDamage;
        }

        public void OutputInventory()
        {

            System.Console.WriteLine("--------------------------------------------------------------------");
            System.Console.WriteLine("----------------------  Your inventory  ----------------------------");
            System.Console.WriteLine("--------------------------------------------------------------------");
            foreach (var wep in weapons)
            {
                wep.OutputStats();
                System.Console.WriteLine();
            }
        }

        
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int Health { get; set; }
        public Armour Helmet { get; set; }
    }
}