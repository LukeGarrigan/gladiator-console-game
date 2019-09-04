using System;

namespace Weapons
{
    public abstract class Weapon
    {
        public Weapon(int minDamage, int maxDamage, double attackSpeed, string name, string movement) 
        {
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;    
            this.Name = name;
            this.AttackSpeed = attackSpeed;
            this.Movement = movement;
        }


        public int MinDamage { get; }
        public int MaxDamage { get; }
        public double AttackSpeed {get;}
        public string Name { get; }
        public string Movement { get; }


        public int DoAttack() 
        {
            var random = new Random();
            var damage = random.Next(MinDamage, MaxDamage);
            return damage;   
        }

        public void OutputStats()
        {
            System.Console.WriteLine($"Weapon: {this.Name}");
            System.Console.WriteLine($"Damage: [{this.MinDamage}-{this.MaxDamage}]");
            System.Console.WriteLine($"Speed: {this.AttackSpeed}s ");
            System.Console.WriteLine($"Attack Type: {this.Movement}");   
        }

        
        
    }

}