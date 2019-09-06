
using Xunit;
using GladiatorGame.Items;
using System;

namespace gladiator_game.Test
{
    public class InventoryTest {

        private Inventory inventory = new Inventory();

        [Fact]
        public void TestDeleteItem()
        {
            var itemToDelete = inventory.Items[0];
            inventory.DeleteItem(itemToDelete.Name);
            Assert.False(inventory.Items.Contains(itemToDelete));
        }



    }
}
