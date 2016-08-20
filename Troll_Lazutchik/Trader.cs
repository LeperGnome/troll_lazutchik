using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Trader
    {
        public const int ID = 5;

        private int Health = 15;
        private int Damage = 15;
        private int DodgeChance = 10;
        private int Armor = 10;

        private int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, false, inputOppositeArmor, inputOppositeDodgeChance);
        }

        public void Fighting (Player player, Trader trader)
        {
            Console.WriteLine("Проходя очередной километр, вы замечаете, что за вами кто-то следит. Немного сбавив темп, вы пытаетесь высмотреть таинственного наблюдателя, но долго искать не приходится. Из-за гниющей берёзы выходит знакомый надоедливый торговец Хасана."); // при встерче 
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("Текущее здоровье врага: " + trader.Health);

            while (player.Health > 0 && trader.Health > 0)
            {
                Optional.GetAttckKey();
                TakeDamage(player, trader);
                DealDamage(player, trader);
            }

            if (player.Health <= 0)
            {
                if (trader.Health > 0)
                {
                    Console.WriteLine(""); // поражение игрока
                    Optional.Restart();
                    player.Alive = false;
                }
                else
                {
                    Console.WriteLine("");
                    Optional.Restart();
                    player.Alive = false;
                }
            }
            else
            {
                Console.WriteLine("Вы выходите победителем из этой схватки.");
                Console.WriteLine("Пора двигаться дальше.");
                Console.WriteLine("");
            }
        }

        private void TakeDamage(Player player, Trader trader)
        {
            int damageTaken = player.DamageCurrentTime(0, trader.DodgeChance);
            trader.Health -= damageTaken;
            Console.WriteLine("Вы нанесли: " + damageTaken + " урона.");
            Console.WriteLine("Текущее здоровье вора: " + trader.Health);
            Console.WriteLine("");
        }

        private void DealDamage(Player player, Trader trader)
        {
            int damageGiven = trader.DamageCurrentTime(player.Armor, player.DodgeChance);
            player.Health -= damageGiven;
            Console.WriteLine("Вам нанесли: " + damageGiven + " урона.");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }
    }
}
