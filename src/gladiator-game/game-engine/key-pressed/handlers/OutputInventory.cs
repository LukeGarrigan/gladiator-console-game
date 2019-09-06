using GladiatorGame.Players;

namespace GladiatorGame.SimpleGameEngine.Handler
{
    public class OutputInventory : IKeyPressedHandler
    {
        private Player player;

        public OutputInventory(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            this.player.OutputInventory();
        }
    }
}