using System;
using Players;
using SimpleGameEngine;

namespace first_console_game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine.StartGame(Program.CreatePlayer());   
        }

        public static Player CreatePlayer()
        {
            System.Console.WriteLine("Hello gladiator, please choose the name of your champion:");
            string name = Console.ReadLine();
            System.Console.WriteLine($"Welcome {name}, we have awaited your arrival for many years.");
            return new Player(name);
        }
    }
}
