using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Rat
    {
        public const int ID = 2;
        public int Health = 16;
        public int Damage = 5;

        private int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, false, inputOppositeArmor, inputOppositeDodgeChance);
        }

        public void Fighting(Player player, Rat rat)
        {
            Console.WriteLine("На вашем пути жирная крыса! Сойдет для завтрака.");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("Текущее здоровье врага: " + rat.Health);
            Console.WriteLine("");
            while (player.Health > 0 && rat.Health > 0)
            {
                Optional.GetAttckKey();
                TakeDamage(player, rat);
                DealDamage(player, rat);
            }

            if (player.Health <=0)
            {
                Console.WriteLine("Вы стали обедом жирной крысы. Хотите ли вы начать игру сначала?");
                Optional.Restart();
                player.Alive = false;
            }
            else
            {
                Console.WriteLine("Вы одержали победу! Так держать! ");
                Console.WriteLine("");
                EatRat(player);
            }
        }

        private void TakeDamage(Player player, Rat rat)
        {
            int damageTaken = player.DamageCurrentTime(0, 0);
            rat.Health -= damageTaken;
            Console.WriteLine("Вы нанесли: " + damageTaken + " урона.");
            Console.WriteLine("Текущее здоровье жирной крысы: " + rat.Health);
            Console.WriteLine("");
        }
        private void DealDamage(Player player, Rat rat)
        {
            int damageGiven = rat.DamageCurrentTime(player.Armor, player.DodgeChance);
            player.Health -= damageGiven;
            Console.WriteLine("Вам нанесли: " + damageGiven + " урона.");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }

        private void EatRat(Player player)
        {
            string poisonedPhraseRat = "Поедание сырого мяса пагубно сказалось на вашем здоровье."; 
            string healedPhraseRat = "Крысиное мясо оказалось очень даже съедобным.";

            Console.WriteLine("Мёртвая крыса выглядит аппетитно. ");
            Console.WriteLine("Вы можете съесть ее, чтобы воостановить здоровье, но учтите,что ");
            Console.WriteLine("крысы могут являться переносчиками заразы. ");
            Console.WriteLine("Съесть жирную крысу?");
            Optional.GetEatCommand(player, poisonedPhraseRat, healedPhraseRat, "");
        }
    }
}
