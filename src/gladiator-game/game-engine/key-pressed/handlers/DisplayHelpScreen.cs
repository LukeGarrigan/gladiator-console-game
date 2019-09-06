namespace GladiatorGame.SimpleGameEngine.Handler
{
    public class DisplayHelpScreen : IKeyPressedHandler
    {
        public void Execute()
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