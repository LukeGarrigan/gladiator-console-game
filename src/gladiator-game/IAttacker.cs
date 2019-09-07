
using GladiatorGame.Items.Weapons;

namespace GladiatorGame.Attacker
{
    
    public interface IAttacker<T> 
    {
        Weapon Weapon { get; set; }
        
        void Attack(T attackee);
    }

}