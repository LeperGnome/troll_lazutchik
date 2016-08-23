using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Skolopendra
    {
        public const int ID = 1;
        public int Health = 10;
        public int Damage = 2;

        public int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, false, inputOppositeArmor, inputOppositeDodgeChance);
        }

        public void Fighting(Player player, Skolopendra skolopendra)
        {
            Console.WriteLine("Вы встречаете сколопендру! Достаточно безобидный соперник. Как раз тот, кого вы можете победить с похмелья...");
            Console.WriteLine("");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("Текущее здоровье врага: " + skolopendra.Health);
            while(player.Health > 0 && skolopendra.Health > 0)
            {
                Optional.GetAttckKey();
                TakeDamage(player, skolopendra);
                DealDamage(player, skolopendra);
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Сколопендра защекотала вас до смерти.Хотите ли вы начать игру сначала?");
                Optional.Restart();
                player.Alive = false;
            }
            else
            {
                Console.WriteLine("Поздравляем с первой победой! ");
                Console.WriteLine("Жаль, праздновать нет времени, пора идти вперед... ");
                Console.WriteLine("");
            }
        }
        
        private void TakeDamage(Player player, Skolopendra skolopendra)
        {
            int damageTaken = player.DamageCurrentTime(0, 0);
            skolopendra.Health -= damageTaken;
            Console.WriteLine("Вы нанесли: " + damageTaken + " урона.");
            Console.WriteLine("Текущее здоровье сколопендры: " + skolopendra.Health);
            Console.WriteLine("");
        }

        private void DealDamage(Player player, Skolopendra skolopendra)
        {
            int damageGiven = skolopendra.DamageCurrentTime(player.Armor, player.DodgeChance);
            player.Health -= damageGiven;
            Console.WriteLine("Вам нанесли: " + damageGiven + " урона.");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }
    }
}
