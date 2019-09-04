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
                if (input == "h")
                {
                    DisplayHelpScreen();
                }
                else if (input == "i")
                {
                    player.OutputInventory();
                }
                else if (input.StartsWith("equip"))
                {
                    var wep = input.Substring(6, input.Length - 6);
                    player.SwitchWeapon(wep);
                }
                else if (input.Equals("fight"))
                {

                    var enemy = EnemyFactory.CreateEnemy(player);
                    var battle = new Battle(player, enemy);
                    battle.BeginBattle();
                }
            }
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