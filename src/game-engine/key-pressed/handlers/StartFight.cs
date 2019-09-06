using GladiatorGame.Battles;
using GladiatorGame.Enemies;
using GladiatorGame.Players;

namespace GladiatorGame.SimpleGameEngine
{
    internal class StartFight : IKeyPressedHandler
    {
        private Player player;

        public StartFight(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            var enemy = EnemyFactory.CreateEnemy(player);
            var battle = new Battle(player, enemy);
            battle.BeginBattle();
        }
    }
}