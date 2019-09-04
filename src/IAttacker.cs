using Weapons;

namespace Attacks
{
    
    public interface IAttacker<T> 
    {
        Weapon Weapon { get; set; }
        
        int Attack(T attackee);
    }

}