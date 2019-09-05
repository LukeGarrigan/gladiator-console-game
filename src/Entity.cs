using GladiatorGame.Weapons;

namespace GladiatorGame.Entities
{


    public interface IEntity
    {
        string Name { get; set; }
        Weapon Weapon { get; set; }
        int Health { get; set; }

    }

}