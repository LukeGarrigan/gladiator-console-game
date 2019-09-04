using Weapons;
using System.Collections.Generic;
using Attacks;
using Entities;
using System;
using System.Linq;

namespace Players
{

    public class Player : Entity, IAttacker<Entity>
    {
        List<Weapon> weapons = new List<Weapon>();

        public Player(string name) : base(100, new BasicSword(), "Player")
        {
            this.Name = name;
            this.weapons.Add(this.Weapon);
            this.weapons.Add(new ButterKnife()); // secondary wep, mainly to show that you can switch between 

            System.Console.WriteLine($"You have equiped a [{Weapon.Name}] which does damage from [{Weapon.MinDamage}-{Weapon.MaxDamage}] every [{Weapon.AttackSpeed}s]");
        }

        public void SwitchWeapon(string weaponName)
        {
            var weaponToSwitchTo = (from wep in weapons
                                    where wep.Name == weaponName
                                    select wep);

            var newWep = weaponToSwitchTo.FirstOrDefault();

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

        public void EquipNewWeapon(Weapon newWep)
        {
            this.weapons.Add(newWep);
            System.Console.WriteLine($"You put away the {Weapon.Name} and equip the {newWep.Name} ");
            this.Weapon = newWep;
        }

        public int Attack(Entity enemy)
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
    }
}