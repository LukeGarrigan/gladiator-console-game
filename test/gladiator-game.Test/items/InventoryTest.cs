
using Xunit;
using GladiatorGame.Items;
using System;
using GladiatorGame.Items.Weapons;
using GladiatorGame.Items.Helmets;

namespace gladiator_game.Test
{
    public class InventoryTest
    {

        private Inventory inventory = new Inventory();

        [Fact]
        public void TestDeleteItem()
        {
            var itemToDelete = inventory.Items[0];
            inventory.DeleteItem(itemToDelete.Name);
            Assert.False(inventory.Items.Contains(itemToDelete));
        }

        [Fact]
        public void TestHasAMaul()
        {
            var inventory = new InventoryBuilder().HasWeapon(new Maul());
            Assert.True(inventory.Items.Contains(new Maul()));
        }

        [Fact]
        public void TestHasWeaponWielded()
        {
            var maul = new Maul();
            var inventory = new InventoryBuilder().HasWeaponWielded(maul);
            Assert.True(inventory.WieldedWeapon.Equals(maul));
        }

        
        [Fact]
        public void TestHasEquippedNewHelmet()
        {
            var strawHat = new StrawHat();
            var inventory = new InventoryBuilder().HasHelmetEquipped(strawHat);
            Assert.True(inventory.WieldedHelmet.Equals(strawHat));
        }

        [Fact]
        public void TestFailToEquipAChestPieceAsAHemlmet()
        {
            var strawChest = new StrawChest();
            var inventory = new InventoryBuilder().HasHelmetEquipped(strawChest);
            Assert.False(inventory.WieldedHelmet.Equals(strawChest));
        }

    }
}
