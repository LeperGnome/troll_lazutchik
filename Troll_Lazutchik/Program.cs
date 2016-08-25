using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Program
    {
        private static string[,] phrasesMas = new string[200,2];
        
        // WEAPONS DAMAGE
        public const int FistDamage = 8;
        public const int KnifeDamage = 10;
        public const int dubinaDamage = 11;

        // STEPS TO LOCATIONS
        int stepsForest;
        int stepsToVilage;
        int stepsToEnemy;
        int step;
        

        private int nextEnemyID = 1;

        Player player;
        Random random = new Random();

        static void Main(string[] args)
        {
            Program Game = new Program();

           

            Game.NewGame();
            
            Console.ReadLine();
        }

        

        public void NewGame()
        {
            #region PHRASES

            phrasesMas[1, 1] = "Пройдя пару километров, вы замечаете растерзаный труп лошади своего соседа... "; phrasesMas[1, 0] = "n";
            phrasesMas[2, 1] = "Вы не замечаете ничего интересного. "; phrasesMas[2, 0] = "n";
            phrasesMas[3, 1] = "На вашем пути не встретилось ничего особенного."; phrasesMas[3, 0] = "n";
            phrasesMas[4, 1] = "Проходя мимо леса вы видите тролля-лазутчика, наблюдающего за вами из-за дерева. Без оружия в этом лесу не обойтись..."; phrasesMas[4, 0] = "n";
            phrasesMas[5, 1] = "На своем пути вы встречаете старую мельницу и вспоминаете, как будучи маленьким сорванцом, вы бегали туда воровать зерно с соседскими мальчишками."; phrasesMas[5, 0] = "n";
            phrasesMas[6, 1] = "По пути домой, вы натыкаетесь на болото и решаете его обойти."; phrasesMas[6, 0] = "n";
            phrasesMas[7, 1] = "Вы споткнулись, не бегите так быстро."; phrasesMas[7, 0] = "n";
            phrasesMas[8, 1] = "Из-за голода, вы обратили внимание на куст с ягодами. Рискнёте полакомиться?"; phrasesMas[8, 0] = "n";
            phrasesMas[9, 1] = "Вы немного заплутали, но вскоре нашли правильный путь."; phrasesMas[9, 0] = "n";
            phrasesMas[10, 1] = "Вам становится плохо. Алкоголь даёт о себе знать. Немного передохнув, вы выдвигаетесь дальше..."; phrasesMas[10, 0] = "n";

            phrasesMas[11, 1] = "На дорогоге вы замечаете сеймейство маслят. Эти ребята выглядят очень аппетитно. Рискнёте съесть их?"; phrasesMas[11, 0] = "n";
            phrasesMas[12, 1] = "Вы не замечаете ничего интересного. "; phrasesMas[12, 0] = "n";
            phrasesMas[13, 1] = "Вы видите, что тучи сгущаются, видимо скоро начнётся дождь."; phrasesMas[13, 0] = "n";
            phrasesMas[14, 1] = "На дорог вы находите 5 гривен. Должно хватить на какую-либо мелочь."; phrasesMas[14, 0] = "n";
            phrasesMas[15, 1] = "Солнце садится, следеут двигаться быстрее..."; phrasesMas[15, 0] = "n";
            phrasesMas[16, 1] = "Вы переутомились и хотите немного передохнуть. Позволите себе немного вздремнуть? "; phrasesMas[16, 0] = "n";


            phrasesMas[100, 1] = "На подходе к деревне вы замечаете иcтоптанное конями поле..."; phrasesMas[100, 0] = "n";
            phrasesMas[101, 1] = "Вы подходите к деревне, и наблюдаете ужасное зрелище. Она разорена."; phrasesMas[101, 0] = "n";
            phrasesMas[102, 1] = "Окончательно протрезвев, вы понимаете, что на вас совсем нет одежды!Как же вы   раньше этого не заметили?"; phrasesMas[102, 0] = "n";
            phrasesMas[103, 1] = "Вам следует проверить свой дом и заодно надеть что-нибудь."; phrasesMas[103, 0] = "n";
            phrasesMas[104, 1] = "Войдя в дом, вы видите,что он разграблен!"; phrasesMas[104, 0] = "n";
            phrasesMas[105, 1] = ""; phrasesMas[105, 0] = "n";

            #endregion

            player = new Player() { Damage = FistDamage };
            step = 0;
            
            Console.WriteLine("Вы просыпаетесь под старым дубом. ");
            Console.WriteLine("Кажется, вчера вы перебрали с элем в том кабаке.");
            Console.WriteLine("Пожалуй, следует добраться до дома и привести себя в порядок. Наверное, вас уже заждались... ");
            Console.WriteLine("Вы поднимаетесь с земли и отправляетесь в путь.");

            stepsToVilage = random.Next(12, 14);
            VilageTrip();

            House();

            stepsForest = 8;
            ForestTrip();
        }
        
        private void VilageTrip()
        {
            stepsToEnemy = NextEnemyStep();
            for (step = 1; step < stepsToVilage; step++)
            {
                Optional.GetGoKey();
                if (step == stepsToEnemy)
                {
                    switch (nextEnemyID)
                    {
                        case Skolopendra.ID:
                            Skolopendra skolopendra = new Skolopendra();
                            skolopendra.Fighting(player, skolopendra);
                            stepsToEnemy = NextEnemyStep();
                            nextEnemyID++;

                            break;
                        case Rat.ID:
                            Rat rat = new Rat();
                            rat.Fighting(player, rat);
                            stepsToEnemy = NextEnemyStep();
                            nextEnemyID++;

                            break;
                        case Danila.ID:
                            Danila danila = new Danila();
                            danila.Fighting(player, danila);
                            nextEnemyID++;

                            break;
                    }
                    if (player.Alive == false)
                    {
                        NewGame();
                    }
                }
                else
                {
                    ViewPhrase(1, 11);                    
                }
            }
            Optional.GetGoKey();
            for (int i = 100; i <= 104; i++) { Console.WriteLine(phrasesMas[i, 1]); Optional.GetGoKey(); }
            Console.WriteLine("--------------------------------");
        }

        private void House()
        {
            string playerClass;
            Console.WriteLine("Хотя у вас - бедного...");
            Console.WriteLine("1) отставного офицера;   (Легко)");
            Console.WriteLine("2) сторожа;   (Средне)");
            Console.WriteLine("3) крестьянина;   (Сложно)");
            do
            {
                playerClass = Console.ReadLine();
                if (playerClass != "1" && playerClass != "2" && playerClass != "3")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (playerClass != "1" && playerClass != "2" && playerClass != "3");


            Console.WriteLine("...нечего взять, разбойники нашли, чем поживиться.");
            Console.WriteLine("");

            Console.WriteLine("Но кое-что они всё же оставили.");
            Console.Write("Тщательно обыскав дом, вы нажодите ");

            switch (playerClass)
            {
                case "1":
                    player.Armor = 15;
                    Console.WriteLine("помятый стальной нагрудник, рваную рубаху, изношенные портки и пару сапог.");
                    break;

                case "2":
                    player.Armor = 10;
                    Console.WriteLine("поношенную кольчугу, хлопковые штаны и истоптанные сапоги.");
                    break;

                case "3":
                    player.Armor = 5;
                    Console.WriteLine("старый кафтан, лапти и облезлые портки.");
                    break;
            }

            player.Health += 30;
            Console.WriteLine("");
            Console.WriteLine("Вы отдохнули и восстановили здоровье - 30");
            Console.WriteLine("Ваше текущее здоровье: {0}", player.Health);

        }

        private void ForestTrip()
        {
            step = 1;
            stepsToEnemy = NextEnemyStep();
            for (step = 1; step < stepsForest; step++)
            {
                Optional.GetGoKey();
                if(step == stepsToEnemy)
                {

                    switch (nextEnemyID)
                    {
                        case Thief.ID:
                            Thief thief = new Thief();
                            thief.Fighting(player, thief);
                            stepsToEnemy = NextEnemyStep();
                            nextEnemyID++;
                            break;

                        case Trader.ID:
                            Trader trader = new Trader();
                            trader.Meeting(player, trader);
                            stepsToEnemy = NextEnemyStep();
                            nextEnemyID++;
                            break;
                    }

                    if (player.Alive == false)
                    {
                        NewGame();
                    }
                }
                else
                {
                    ViewPhrase(11, 16);
                }
                
            }

        }

        private void ViewPhrase(int startPhrase, int endPhrase)
        {
            int randomPhrase;
            do
            {
                randomPhrase = random.Next(startPhrase, endPhrase);
            } while (phrasesMas[randomPhrase, 0] != "n");
            Console.WriteLine(phrasesMas[randomPhrase, 1]);
            phrasesMas[randomPhrase, 0] = "y";

            switch (randomPhrase)
            {
                case 7:         // споткнулся
                    player.Health -= 1;
                    Console.WriteLine("Получено урона - 1.");
                    Console.WriteLine("Ваше текущее здоровье: " + player.Health);
                    Console.WriteLine("--------------------------------");

                    break;

                case 8:         // куст ягод
                    string poisonedPhraseBerry = "Вы отравлены! Жаль, вы не знали, что эти ягоды ядовиты.";
                    string healedPhraseBerry = "Вкусные ягоды уталили ваш голод.";

                    Optional.GetEatCommand(player, poisonedPhraseBerry, healedPhraseBerry, "");

                    break;

                case 11:        // маслята
                    string poisonedPhraseMushrooms = "С виду аппетитные маслята не оправдали ожиданий.";
                    string healedPhraseMushrooms = "Аппетитные маслята уталили голод.";
                    string deathPhraseMushrooms = "Маслята окончательно вас добивают.";

                    Optional.GetEatCommand(player, poisonedPhraseMushrooms, healedPhraseMushrooms, deathPhraseMushrooms);

                    break;

                case 14:        // нахождение золота
                    player.Gold += 5;
                    Console.WriteLine("Ваше текущее золото: " + player.Gold);
                    break;

                case 16:        // отдых
                    
                    break;
            }
        }

        private int NextEnemyStep()
        {
            return (random.Next(2, 4) + step);
        }

    }
}
