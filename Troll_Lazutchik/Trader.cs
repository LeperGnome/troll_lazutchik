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

        public void Meeting (Player player, Trader trader)
        {
            string choice;

            Console.WriteLine("Проходя очередной километр, вы замечаете, что за вами кто-то следит.");
            Console.WriteLine("Немного сбавив темп, вы пытаетесь высмотреть таинственного наблюдателя, но долго искать не приходится. ");
            Console.WriteLine("Из-за гниющей березы вылезает знакомый вам торговец Хасан.");
            Console.WriteLine("Понимая, что разговора не избежать, вы решаете его выслушать.");
            Console.WriteLine("Хасан предлагает купить у него броню. К сожалению у вас нет денег, но вы можете: ");

            
            Console.WriteLine("1. Попытаться ограбить Хасана.");
            Console.WriteLine("2. Уйти, отказавшись от сделки.");
            if (player.Damage != 8)
            {
                Console.WriteLine("3. Предложить обмен своего ножа на броню.");
                do
                {
                    choice = Console.ReadLine();
                    if (choice != "1" && choice != "2" && choice != "3")
                    {
                        Console.WriteLine("Неизвестная команда, попробуйте снова.");
                        choice = Console.ReadLine();
                    }
                } while (choice != "1" && choice != "2" && choice != "3");
            }
            else
            {
                do
                {
                    choice = Console.ReadLine();
                    if (choice != "1" && choice != "2")
                    {
                        Console.WriteLine("Неизвестная команда, попробуйте снова.");
                        choice = Console.ReadLine();
                    }
                } while (choice != "1" && choice != "2");
            }
            

            switch (choice)
            {
                case "3":
                    Console.WriteLine("Хасан соглашается на обмен.");
                    player.Damage = 8;
                    player.Armor = 20;
                    Console.WriteLine("Ваш текущий урон: " + player.Damage);
                    Console.WriteLine("Ваша текущая броня: " + player.Armor);
                    break;

                

                case "1":
                    
                    trader.Fighting(player, trader);
                    break;

                case "2":
                    Console.WriteLine("Вы отправляетесь дальше...");
                    break;
            }


        }
        private void Fighting (Player player, Trader trader)
        { 
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
                    Console.WriteLine("Вам не удалось одолеть надоедливого торговца. "); // поражение игрока
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
                Console.WriteLine("Вам удалось сразить Хасана. Вы забираете его лучшую броню. ");
                Console.WriteLine("Пора двигаться дальше.");
                Console.WriteLine("");
            }
        }

        private void TakeDamage(Player player, Trader trader)
        {
            int damageTaken = player.DamageCurrentTime(trader.Armor, trader.DodgeChance);
            trader.Health -= damageTaken;
            Console.WriteLine("Вы нанесли: " + damageTaken + " урона.");
            Console.WriteLine("Текущее здоровье Хасана: " + trader.Health);
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
