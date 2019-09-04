using Weapons;
using Attacks;
using Entities;
using System;

namespace Enemies
{

    public class Enemy : Entity, IAttacker<Entity>
    {

        public Enemy(int health, Weapon weapon, string name) : base(health, weapon, name)
        {
        }

    
        public int Attack(Entity player)
        {
            var attackDamage = Weapon.DoAttack();
            player.Health -= attackDamage;
            var playerHealth = player.Health < 0 ? 0 : player.Health;
            System.Console.WriteLine(String.Format("|{0, 20}|{1, 20}|", $"{playerHealth} (-{attackDamage}) ", $"{Health} (0) "));
            return attackDamage;
        }
    }
}