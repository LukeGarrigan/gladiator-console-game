using GladiatorGame.Battles;
using GladiatorGame.Players;
using GladiatorGame.SimpleGameEngine.Handler;

namespace GladiatorGame.SimpleGameEngine
{
    public class KeyPressedHandlerFactory
    {
        public static IKeyPressedHandler GetHandler(string input, Player player)
        {
            if (input.Equals("h"))
            {
                return new DisplayHelpScreen();
            }
            else if (input.Equals("i"))
            {
                return new OutputInventory(player);
            }
            else if (input.StartsWith("equip"))
            {
                return new SwitchPlayerWeapon(player, input);
            }
            else if (input.Equals("fight"))
            {
                return new StartFight(player);
            }
            else if (input.Equals("q"))
            {
                return new QuitGame();
            }
            return null;
        }
    }

}