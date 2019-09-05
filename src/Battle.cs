using System.Threading;
using System.Threading.Tasks;
using GladiatorGame.Attacker;
using GladiatorGame.Enemies;
using GladiatorGame.Entities;
using GladiatorGame.Players;

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

            this.DisplayWinner(player, enemy);
        }

        private Task GetFightTask(Entity attacker, Entity attackee)
        {
            return new Task(() =>
            {
                while (attackee.Health > 0 && attacker.Health > 0)
                {
                    ((IAttacker<Entity>)attacker).Attack(attackee);
                    Thread.Sleep((int)(attacker.Weapon.AttackSpeed * 1000));
                }
            });
        }



        private void DisplayWinner(Player player, Enemy enemy)
        {
            System.Console.WriteLine("");
            if (enemy.Health < 0)
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
            else
            {
                System.Console.WriteLine($"You have been defeated by {enemy.Name}");
            }
        }



    }
}
