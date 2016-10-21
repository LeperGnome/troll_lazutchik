using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class GnomeArmy
    {
        private int Health = 10;
        private int gnomesCount = 3;
        private int Damage = 5;
        private int DodgeChance = 10;
        private int Armor = 20;

        private int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, true, inputOppositeArmor, inputOppositeDodgeChance, false);
        }

        public void Fighting(Player player, GnomeArmy gnomeArmy)
        {
            Console.WriteLine("");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("Текущее здоровье гнома: " + gnomeArmy.Health);

            while (player.Health > 10 && gnomeArmy.gnomesCount > 0)
            {
                Optional.GetAttckKey();
                TakeDamage(player, gnomeArmy);
                DealDamage(player, gnomeArmy);
                if (gnomeArmy.Health <= 0) { gnomesCount--; }
            }

            if (player.Health <= 10)
            {
                Console.WriteLine("");      //  Текст поражения
            }
            else if(gnomeArmy.gnomesCount == 0)
            {
                Console.WriteLine("");      // Текст победы
            }
        }

        private void TakeDamage(Player player, GnomeArmy gnomeArmy)
        {
            int damageTaken = player.DamageCurrentTime(gnomeArmy.Armor, gnomeArmy.DodgeChance);
            gnomeArmy.Health -= damageTaken;
            Console.WriteLine("Текущее здоровье гнома: " + gnomeArmy.Health);
            Console.WriteLine("Гномов осталось: {0}", gnomesCount);
            Console.WriteLine("");
        }

        private void DealDamage(Player player, GnomeArmy gnomeArmy)
        {
            for (int i = 1; i <= gnomesCount; i++)
            {
                int damageGiven = gnomeArmy.DamageCurrentTime(player.Armor, player.DodgeChance);
                player.Health -= damageGiven;
            }
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }
    }
}
