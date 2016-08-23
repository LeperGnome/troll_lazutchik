using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Danila
    {
        public const int ID = 3;

        public int Health = 25;
        public int Damage = 10;

        private int DamageCurrentTime(int inputOppositeArmor, int inputOppositeDodgeChance)
        {
            return Optional.GetDamage(Damage, true, inputOppositeArmor, inputOppositeDodgeChance);
        }

        public void Fighting(Player player, Danila danila)
        {
            Console.WriteLine("На подходе к деревне вы встречаете местного пьяницу. ");
            Console.WriteLine("Вы узнаете в нем своего вчерашнего собутыльника - Данилу.");
            Console.WriteLine("Достав нож, Данила требует с вас денег за выпивку, которой он вас 'угостил'.");
            Console.WriteLine("");
            Console.WriteLine("Дать отпор Даниле - 'a'.");
            Console.WriteLine("Бежать к деревне, не ввязываясь в драку - 'g'.");
            Console.WriteLine("--------------------------------");

            string choice;

            do
            {
                choice = Console.ReadLine();
                if (choice != "g" && choice != "a")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (choice != "a" && choice != "g");

            if (choice == "a")
            {
                Console.WriteLine("Ваше текущее здоровье: " + player.Health);
                Console.WriteLine("Текущее здоровье врага: " + danila.Health);
                Console.WriteLine("");
                while (player.Health > 0 && danila.Health > 0)
                {
                    Optional.GetAttckKey();
                    TakeDamage(player, danila);
                    DealDamage(player, danila);
                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("Вам не удалось одолеть Данилу.Хотите ли вы начать игру сначала?");
                    Optional.Restart();
                    player.Alive = false;
                }
                else
                {
                    Console.WriteLine("Данила побежден. Сегодня он останется без денег. ");
                    Console.WriteLine("В руке изувеченного Данилы лежит зазубренный нож. ");
                    Console.WriteLine("Вы подбираете его.");
                    player.Damage = 10;
                    Console.WriteLine("Ваш текущий урон: " + player.Damage);
                    Console.WriteLine("--------------------------------");
                }

            }
        }

        private void TakeDamage(Player player, Danila danila)
        {
            int damageTaken = player.DamageCurrentTime(0, 0);
            danila.Health -= damageTaken;
            Console.WriteLine("Вы нанесли: " + damageTaken + " урона.");
            Console.WriteLine("Текущее здоровье Данилы: " + danila.Health);
            Console.WriteLine("");
        }
        private void DealDamage(Player player, Danila danila)
        {
            int damageGiven = danila.DamageCurrentTime(player.Armor, player.DodgeChance);
            player.Health -= damageGiven;
            Console.WriteLine("Вам нанесли: " + damageGiven + " урона.");
            Console.WriteLine("Ваше текущее здоровье: " + player.Health);
            Console.WriteLine("");
        }
    }
}
