﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    static class Optional
    {
        static string attackKey;
        static string goKey;
        static string resrartKey;
        static string eatKey;

        static Random random = new Random();

        public static void GetAttckKey()            // forcing player to insert 'a' button for attacking
        {
            Console.WriteLine("Нажмите 'a', чтобы атаковать.");
            Console.WriteLine("--------------------------------");
            do
            {
                attackKey = Console.ReadLine();
                if (attackKey != "a")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (attackKey != "a");
        }

        public static void GetGoKey()               // forcing player to insert 'g' button for going forvard
        {
            Console.WriteLine("Введите 'g', чтобы пройти далее.");
            Console.WriteLine("--------------------------------");
            do
            { 
                goKey = Console.ReadLine();
                if(goKey != "g")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (goKey != "g");
        }

        public static void GetEatCommand(Player player, string poisinedPhrase, string healedPhrase, string deathPhrase)     // eating smth with chance of healing or taking damage (all unique phrases should be writen when used)
        {
            Console.WriteLine("Введите 'eat', для начала трапезы.");
            Console.WriteLine("Ведите 'dont eat', что бы идти далее.");
            Console.WriteLine("--------------------------------");
            do
            {
                eatKey = Console.ReadLine();
                if (eatKey != "eat" && eatKey != "dont eat")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (eatKey != "eat" && eatKey != "dont eat");

            if (eatKey == "eat")
            {
                int poisonChance = random.Next(1, 3);
                switch (poisonChance)
                {
                    case 1:
                    case 3:
                        int poisonDamageRandom = random.Next(10, 16);
                        player.Health -= poisonDamageRandom;
                        Console.WriteLine(poisinedPhrase);
                        Console.WriteLine("Потеряно здоровья: " + poisonDamageRandom);
                        Console.WriteLine("Текущее здоровье: " + player.Health);
                        Console.WriteLine("--------------------------------");

                        if(player.Health <= 0)
                        {
                            Console.WriteLine("deathPhrase");
                            Restart();
                            player.Alive = false;
                        }

                        break;

                    case 2:
                        int hpHealed = random.Next(5, 11);
                        player.Health += hpHealed;
                        Console.WriteLine(healedPhrase);
                        Console.WriteLine("Здоровья восстановлено: " + hpHealed);
                        Console.WriteLine("Ваше текущее здоровье: " + player.Health);
                        Console.WriteLine("--------------------------------");

                        break;
                }
            }
        }

        public static void Restart()        // restarting the game or quiting 
        {
            Console.WriteLine("Введите 'y' для продолжения или 'n' для выхода из игры.");
            Console.WriteLine("--------------------------------");
            do
            {
                resrartKey = Console.ReadLine();
                if (resrartKey != "y" && resrartKey != "n")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (resrartKey != "y" && resrartKey != "n");
            
            if(resrartKey == "n")
            {
                Environment.Exit(0);
            }
        }

        public static int GetDamage(int inputDamage, bool criticalChanceStatus, int inputOppositeArmor, int inputOppositeDodgeChance)   // seting random damage for obj using obj average damage, ability to deal critical damage, enemy armor and enemy dodge chance (dealing no damage in this case)
        {
            int dodge = random.Next(1, 100);
            if (dodge >= inputOppositeDodgeChance)
            {
                int damageRuducedByArmor = 0;
                int currentRaw = random.Next((int)(inputDamage - (inputDamage * 0.25)), (int)(inputDamage + (inputDamage * 0.25)));
                double armorPerc = (double)inputOppositeArmor / 100;
                int current = (int)(currentRaw - currentRaw * armorPerc);
                damageRuducedByArmor = currentRaw - current;
                if (criticalChanceStatus)
                {

                    int critChance = random.Next(1, 100);
                    if (critChance <= 50)
                    {
                        Console.WriteLine("Критический урон! ");
                        Console.WriteLine("Урона блокировано: " + damageRuducedByArmor);
                        return current + (int)(current * 0.5);
                    }
                    else
                    {
                        Console.WriteLine("Урона блокировано: " + damageRuducedByArmor);
                        return current;
                    }
                }
                else
                {
                    Console.WriteLine("Урона блокировано: " + damageRuducedByArmor);
                    return current;
                }
            } else
            {
                Console.WriteLine("Промах! ");
                return 0;
            }
        }

    }
}
