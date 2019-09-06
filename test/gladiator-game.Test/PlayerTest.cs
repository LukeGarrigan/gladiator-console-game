using System;
using Xunit;
using GladiatorGame.Players;

namespace gladiator_game.Test
{
    public class PlayerTest
    {

        private Player player;

        public PlayerTest()
        {
            player = new Player("Luke");
        }

        [Fact]
        public void TestPlayerName()
        {
            
            Assert.Equal("Luke", player.Name);
        }

        [Fact]
        public void TestPlayerHealth()
        {
            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void TestPlayerEquipWep()
        {
            var player = new Player("Luke");
            var wepToSwitch = player.Inventory.Items[0];
        
            player.SwitchWeapon(wepToSwitch.Name);

            Assert.Equal(player.Inventory.WieldedWeapon, wepToSwitch);
        }


    }
}
