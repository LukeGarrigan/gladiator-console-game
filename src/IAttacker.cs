using GladiatorGame.Weapons;

namespace GladiatorGame.Attacker
{
    
    public interface IAttacker<T> 
    {
        Weapon Weapon { get; set; }
        
        int Attack(T attackee);
    }

}