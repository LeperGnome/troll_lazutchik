using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Thief
    {
        public const int ID = 4;

        private int Health = 20;
        private int Damage = 10;
        private int DodgeChance = 40;

        private int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, true, inputOppositeArmor, inputOppositeDodgeChance, false);
        }

        public void Fighting(Player player, Thief thief)
        {
            Console.WriteLine("На дороге вы встречаете странного мужчину, закрывшего повязкой лицо. "); // при встерче 
            Console.WriteLine("Приблизившись, он угрожает вам кинжалом. ");
            Console.WriteLine("");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("Текущее здоровье врага: " + thief.Health);

            while (player.Health > 0 && thief.Health > 0)
            {
                Optional.GetAttckKey();
                TakeDamage(player, thief);
                DealDamage(player, thief);
            }

            if (player.Health <= 0)
            {
                if (thief.Health > 0)
                {
                    Console.WriteLine("Какая досада! Вор-ловкач выходит победителем из этой схватки.");
                    Optional.Restart();
                    player.Alive = false;
                }
                else
                {
                    Console.WriteLine("Из этого боя никто не выходит поедителем.");
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

        private void TakeDamage(Player player, Thief thief)
        {
            int damageTaken = player.DamageCurrentTime(0, thief.DodgeChance);
            thief.Health -= damageTaken;
            Console.WriteLine("Текущее здоровье вора: " + thief.Health);
            Console.WriteLine("");
        }

        private void DealDamage(Player player, Thief thief)
        {
            int damageGiven = thief.DamageCurrentTime(player.Armor, player.DodgeChance);
            player.Health -= damageGiven;
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }
    }
}
