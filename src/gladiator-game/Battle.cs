using System;
using System.Threading;
using System.Threading.Tasks;
using GladiatorGame.Attacker;
using GladiatorGame.Enemies;
using GladiatorGame.Entities;
using GladiatorGame.Players;
using GladiatorGame.SimpleGameEngine;
using GladiatorGame.Attributes;

namespace GladiatorGame.Battles
{
    public class Battle
    {

        private Player player;
        private Enemy enemy;

        public Battle(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        [ToBeEnhanced("Make it more obvious who is attacking who and maybe interactive in some way")]
        public void BeginBattle()
        {
            System.Console.WriteLine($"You enter the arena with {enemy.Name} they are using a {enemy.Weapon.Name}");
            var playerAttacks = GetFightTask(player, enemy);
            var enemyAttacks = GetFightTask(enemy, player);

            System.Console.WriteLine("-------------------------------------------");
            System.Console.WriteLine($"You (Health)     | {enemy.Name} (Health)");
            System.Console.WriteLine("-------------------------------------------");
            playerAttacks.Start();
            enemyAttacks.Start();

            Task.WaitAny(playerAttacks, enemyAttacks);

            this.DisplayWinner();
        }

        private Task GetFightTask(IEntity attacker, IEntity attackee)
        {
            return new Task(() =>
            {
                while (attackee.Health > 0 && attacker.Health > 0)
                {
                    ((IAttacker<IEntity>)attacker).Attack(attackee);
                    Thread.Sleep((int)(attacker.Weapon.AttackSpeed * 1000));
                }
            });
        }

        private void DisplayWinner()
        {
            System.Console.WriteLine("");
            if (enemy.Health < 0)
            {
                ExecutePlayerWinning();
            }
            else
            {
                System.Console.WriteLine($"You have been defeated by {enemy.Name}");
                System.Threading.Thread.Sleep(5000);
                new QuitGame().Execute();
            }
        }

        private void ExecutePlayerWinning()
        {
            player.Health = 100;
            System.Console.WriteLine($"You destroy {enemy.Name}");
            System.Console.WriteLine($"You loot the body and find: {enemy.Weapon.Name}");
            enemy.Weapon.OutputStats();
            System.Console.WriteLine("Would you like to pick it up and equip it? (y/n)");
            var input = System.Console.ReadLine();

            if (input.ToLower() == "y")
            {
                player.EquipNewWeapon(enemy.Weapon);
            }
        }
    }
}
