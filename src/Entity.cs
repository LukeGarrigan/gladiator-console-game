using Weapons;

namespace Entities
{


    public class Entity
    {

        public Entity(int health, Weapon weapon, string name)
        {
            this.Weapon = weapon;
            this.Health = health;
            this.Name = name;
        }

        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int Health { get; set; }


    }

}