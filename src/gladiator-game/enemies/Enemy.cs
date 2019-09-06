using GladiatorGame.Attacker;
using GladiatorGame.Entities;
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

        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int Health { get; set; }

        public int Attack(IEntity player)
        {
            var attackDamage = Weapon.DoAttack();
            player.Health -= attackDamage;
            var playerHealth = player.Health < 0 ? 0 : player.Health;
            System.Console.WriteLine(String.Format("|{0, 20}|{1, 20}|", $"{playerHealth} (-{attackDamage}) ", $"{Health} (0) "));
            return attackDamage;
        }
    }
}