using System;
using GladiatorGame.Battles;
using GladiatorGame.Enemies;
using GladiatorGame.Players;
using GladiatorGame.SimpleGameEngine.Handler;

namespace GladiatorGame.SimpleGameEngine
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
                var keyHandler = KeyPressedHandlerFactory.GetHandler(input, player);
                if (keyHandler != null)
                {
                    keyHandler.Execute();
                } else 
                {
                    System.Console.WriteLine($"{input} is not a valid command");
                }
                System.Console.WriteLine("Type 'fight' to bring on your next opponent");
            }
        }

        private static void DisplayHelpScreen()
        {
            new DisplayHelpScreen().Execute();
        }
    }

}