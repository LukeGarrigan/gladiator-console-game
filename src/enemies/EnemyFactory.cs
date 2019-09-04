using System;
using System.Collections.Generic;
using Players;
using Weapons;

namespace Enemies
{

    public class EnemyFactory
    {
        private static List<string> PRE_TITLES = new List<string> { "Junior", "Big", "Clumsy", "Strong", "Master", "Dancer" };
        private static List<string> TITLES = new List<string> { "Orc", "Demon", "Knight", "Villager", "Swordsman", "Blacksmith" };
        private static List<Weapon> WEAPON_PROGRESSION = new List<Weapon> { new ButterKnife(), new BasicSword(), new RustyAxe(), new Maul(), new Estoc(), new Zweihander() };

        public static Enemy CreateEnemy(Player player)
        {
            var name = GetEnemyName();
            var health = GetEnemyHealth(player);
            var wep = GetEnemyWep(player);

            return new Enemy(health, wep, name);
        }


        private static int GetEnemyHealth(Player player)
        {
            // very basic game where it creates an enemy based on the current wep the player has equipped
            var damage = player.Weapon.MaxDamage;
            return damage * 2;
        }

        public static String GetEnemyName()
        {
            Random random = new Random();

            var preTitle = PRE_TITLES[random.Next(0, PRE_TITLES.Count)];
            var title = TITLES[random.Next(0, TITLES.Count)];

            return $"{preTitle} {title}";

        }

        private static Weapon GetEnemyWep(Player player)
        {
            var playerWep = player.Weapon;


            for (var i = 0; i < WEAPON_PROGRESSION.Count - 1; i++)
            {
                if (playerWep.Name == WEAPON_PROGRESSION[i].Name)
                {
                    return WEAPON_PROGRESSION[i + 1];
                }
            }

            return WEAPON_PROGRESSION[WEAPON_PROGRESSION.Count - 1]; // on the Zweihander, best wep in the
        }



    }
}