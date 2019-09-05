using System;
using Battles;
using Enemies;
using Players;

namespace SimpleGameEngine
{

    public class GameEngine
    {
        public static void StartGame(Player player)
        {
            System.Console.WriteLine("Before you get started here are a list of commands you can enter!");
            DisplayHelpScreen();
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("h"))
                {
                    DisplayHelpScreen();
                }
                else if (input.Equals("i"))
                {
                    player.OutputInventory();
                }
                else if (input.StartsWith("equip"))
                {
                    SwitchPlayerWeapon(player, input);
                }
                else if (input.Equals("fight"))
                {
                    StartFight(player);
                }
                else if (input.Equals("q"))
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine($"{input} is not a valid command");
                }
                System.Console.WriteLine("Type 'fight' to bring on your next opponent");
            }
        }

        private static void StartFight(Player player)
        {
            var enemy = EnemyFactory.CreateEnemy(player);
            var battle = new Battle(player, enemy);
            battle.BeginBattle();
        }

        private static void SwitchPlayerWeapon(Player player, string input)
        {
            var wep = input.Substring(6, input.Length - 6);
            player.SwitchWeapon(wep);
        }

        private static void DisplayHelpScreen()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Welcome to the help page..");
            System.Console.WriteLine("'h' for help (displays this screen)");
            System.Console.WriteLine("'i' to list your inventory");
            System.Console.WriteLine("'equip [Name of weapon]' to change weapon");
            System.Console.WriteLine("'fight' to fight your next oponent in the Colosseum");
            System.Console.WriteLine("'q' to quit the game");

        }

    }

}