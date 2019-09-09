
using Xunit;
using GladiatorGame.Items;
using System;
using System.Collections.Generic;
using GladiatorGame.Items.Weapons;
using GladiatorGame.Items.Helmets;

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

        [Fact]
        public void TestGetWeaponsInInventory()
        {   
            List<Weapon> weapons = inventory.GetItemsOfType<Weapon>();
            Assert.Equal(1, weapons.Count);
            Assert.Equal("Butter Knife", weapons[0].Name);
        }
        
        [Fact]
        public void TestGetAllArmourInInventory()
        {   
            inventory.AddItem(new StrawChest());

            List<ArmourBase> armour = inventory.GetItemsOfType<ArmourBase>();
            Assert.Equal(1, armour.Count);
            Assert.Equal("Straw Chest", armour[0].Name);
        }

    }
}
