using GladiatorGame.Players;

namespace GladiatorGame.SimpleGameEngine.Handler
{
    internal class SwitchPlayerWeapon : IKeyPressedHandler
    {
        private Player player;
        private string input;

        public SwitchPlayerWeapon(Player player, string input)
        {
            this.player = player;
            this.input = input;
        }

        public void Execute()
        {
            var wep = input.Substring(6, input.Length - 6);
            player.SwitchWeapon(wep);
        }
    }
}