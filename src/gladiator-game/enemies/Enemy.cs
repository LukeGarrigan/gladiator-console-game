using GladiatorGame.Attacker;
using GladiatorGame.Entities;
using GladiatorGame.Items;
using GladiatorGame.Items.Weapons;
using System;

namespace GladiatorGame.Enemies
{

    public class Enemy : IEntity, IAttacker<IEntity>
    {

        public Enemy(int health, Weapon weapon, string name)
        {
            this.Health = health;
            this.Weapon = weapon;
            this.Name = name;
        }
        
        public void Attack(IEntity player)
        {
            var attackDamage = Weapon.DoAttack();
            player.TakeDamage(attackDamage);

            var playerHealth = player.Health < 0 ? 0 : player.Health;
            System.Console.WriteLine(String.Format("|{0, 20}|{1, 20}|", $"{playerHealth} (-{attackDamage}) ", $"{Health} (0) "));
        }

        public void TakeDamage(int attackDamage)
        {
            this.Health -= attackDamage; // not putting armour on enemy at the moment
        }


        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int Health { get; set; }
        public ArmourBase Armour { get; set; }

    }
}