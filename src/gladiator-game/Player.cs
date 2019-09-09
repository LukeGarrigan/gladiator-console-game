using GladiatorGame.Items.Weapons;
using GladiatorGame.Attacker;
using GladiatorGame.Entities;
using System;
using GladiatorGame.Items;

namespace GladiatorGame.Players
{

    public class Player : IEntity, IAttacker<IEntity>
    {

        public Player(string name)
        {
            this.Health = 100;
            this.Name = name;
            this.Inventory = new Inventory();
            System.Console.WriteLine($"You have equiped a [{Weapon.Name}] which does damage from [{Weapon.MinDamage}-{Weapon.MaxDamage}] every [{Weapon.AttackSpeed}s]");
        }

        public void EquipNewWeapon(Weapon newWep)
        {
            this.Inventory.EquipNewWeapon(newWep);
        }

        public void SwitchWeapon(string weapon)
        {
            this.Inventory.SwitchWeapon(weapon);
        }

        public void Attack(IEntity enemy)
        {
            var attackDamage = Weapon.DoAttack();
            enemy.TakeDamage(attackDamage);
            var enemyHealth = enemy.Health < 0 ? 0 : enemy.Health;
            System.Console.WriteLine(String.Format("|{0, 20}|{1, 20}|", $"{Health} (0) ", $"{enemyHealth} (-{attackDamage}) "));
        }

        public void OutputInventory()
        {
            Inventory.OutputInventory();
        }


        [ToBeEnhanced("A more clever way to reduce damage depending on armour")]
        public void TakeDamage(int attackDamage)
        {
            var totalDamage = attackDamage - Armour.Armour;
            if (totalDamage > 0)
            {
                this.Health -= totalDamage;
            }
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public Inventory Inventory { get; }
        public Weapon Weapon { get => this.Inventory.WieldedWeapon; set => this.Inventory.EquipNewWeapon(value); }
        public ArmourBase Armour { get =>this.Inventory.WieldedHelmet; set => this.Inventory.EquipNewHelmet(value);} 
    }
}