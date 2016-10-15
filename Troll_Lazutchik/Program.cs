using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troll_Lazutchik
{
    class Program
    {
        private static string[,] phrasesMas = new string[201,2];
        
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

            phrasesMas[1, 1] = "Пройдя пару километров, вы замечаете растерзаный труп лошади своего соседа... ";
            phrasesMas[2, 1] = "Вы не замечаете ничего интересного. ";
            phrasesMas[3, 1] = "На вашем пути не встретилось ничего особенного.";
            phrasesMas[4, 1] = "Проходя мимо леса вы видите тролля-лазутчика, наблюдающего за вами из-за дерева. Без оружия в этом лесу не обойтись...";
            phrasesMas[5, 1] = "На своем пути вы встречаете старую мельницу и вспоминаете, как будучи маленьким сорванцом, вы бегали туда воровать зерно с соседскими мальчишками.";
            phrasesMas[6, 1] = "По пути домой вы натыкаетесь на болото и решаете его обойти.";
            phrasesMas[7, 1] = "Вы споткнулись, не бегите так быстро.";
            phrasesMas[8, 1] = "Из-за голода вы обратили внимание на куст с ягодами. Рискнёте полакомиться?";
            phrasesMas[9, 1] = "Вы немного заплутали, но вскоре нашли правильный путь.";
            phrasesMas[10, 1] = "Вам становится плохо. Алкоголь даёт о себе знать. Немного передохнув, вы        выдвигаетесь дальше...";

            phrasesMas[11, 1] = "На дорогоге вы замечаете сеймейство маслят. Эти ребята выглядят очень аппетитно. Рискнёте съесть их?";
            phrasesMas[12, 1] = "Вы не замечаете ничего интересного. ";
            phrasesMas[13, 1] = "Вы видите, что тучи сгущаются, видимо скоро начнётся дождь.";
            phrasesMas[14, 1] = "На дороге вы находите 5 гривен. Должно хватить на какую-либо мелочь.";
            phrasesMas[15, 1] = "Солнце садится, следеут двигаться быстрее...";
            phrasesMas[16, 1] = "Вы переутомились и хотите немного передохнуть. Позволите себе вздремнуть? ";

            phrasesMas[17, 1] = "";
            phrasesMas[18, 1] = "";
            phrasesMas[19, 1] = "";
            phrasesMas[20, 1] = "";
            phrasesMas[21, 1] = "";
            phrasesMas[22, 1] = "";
            phrasesMas[23, 1] = "";

            phrasesMas[100, 1] = "На подходе к деревне вы замечаете иcтоптанное конями поле...";
            phrasesMas[101, 1] = "Вы подходите к деревне и наблюдаете ужасное зрелище. Она разорена.";
            phrasesMas[102, 1] = "Окончательно протрезвев, вы понимаете, что на вас совсем нет одежды! Как же вы  раньше этого не заметили?";
            phrasesMas[103, 1] = "Вам следует проверить свой дом и заодно надеть что-нибудь.";
            phrasesMas[104, 1] = "Войдя в дом, вы видите, что он разграблен!";

            phrasesMas[105, 1] = "Подойдя к лесу вы видите две тропы, ведущие в разные стороны.";
            phrasesMas[106, 1] = "Одна из них ведет к таинственной пещере, заросшей кустами чертополоха.";
            phrasesMas[107, 1] = "Другая в глубь леса, к неизвестным вам местам. Вы решатете идти... ";
            phrasesMas[108, 1] = "1) к пещере. ";
            phrasesMas[109, 1] = "2) в глубь леса. ";

            phrasesMas[110, 1] = "Вы решаете проверить таинственную пещеру.";
            phrasesMas[111, 1] = "Из замшелого входа веет сыростью...";
            phrasesMas[112, 1] = "Войдя туда, вы видите маленького человека, предположительно гнома, копающегося в каком-то мусоре.";
            phrasesMas[113, 1] = "1) Заговорить с гномом.";
            phrasesMas[114, 1] = "2) Попытаться убить гнома.";
            phrasesMas[115, 1] = "3) Незаметно выйти из пещеры.";

            for (int i = 1; i <= 200; i++)  { phrasesMas[i, 0] = "n"; }

            #endregion

            player = new Player() { Damage = FistDamage };
            step = 0;
            
            Console.WriteLine("Вы просыпаетесь под старым дубом. ");
            Console.WriteLine("Кажется, вчера вы перебрали с элем в том кабаке.");
            Console.WriteLine("Пожалуй, следует добраться до дома и привести себя в порядок. Наверное, вас уже заждались... ");
            Console.WriteLine("Вы поднимаетесь с земли и отправляетесь в путь.");

            stepsToVilage = random.Next(12, 14);
            Console.WriteLine("Введите 'stats', чтобы посмотреть ваши характеристики.");
            VilageTrip();

            Console.WriteLine("Введите 'stats', чтобы посмотреть ваши характеристики.");
            House();

            stepsForest = 8;
            Console.WriteLine("Введите 'stats', чтобы посмотреть ваши характеристики.");
            ForestTrip();

            #region ROAD CHOICE
            Optional.GetGoKey(player);
            for (int i = 105; i <= 109; i++) { Console.WriteLine(phrasesMas[i, 1]); }
            string roadChoice;
            do
            {
                roadChoice = Console.ReadLine();
                if (roadChoice != "1" && roadChoice != "2")
                {
                    Console.WriteLine("Неизвестная команда, попробуйте снова.");
                }
            } while (roadChoice != "1" && roadChoice != "2");
            #endregion

            switch (roadChoice)
            {
                case "1":
                    Cave();
                    break;

                case "2":
                    TrollCamp();
                    break;
            }

        }

        private void VilageTrip()
        {
            stepsToEnemy = NextEnemyStep();
            for (step = 1; step < stepsToVilage; step++)
            {
                Optional.GetGoKey(player);
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
            Optional.GetGoKey(player);
            for (int i = 100; i <= 104; i++) { Console.WriteLine(phrasesMas[i, 1]); Optional.GetGoKey(player); }
            Console.WriteLine("--------------------------------");
        }

        private void House()
        {
            string playerClass;
            Console.WriteLine("Хотя у вас - бедного...");
            Console.WriteLine("1) отставного офицера;   (Легко)");
            Console.WriteLine("2) сторожа;   (Средне)");
            Console.WriteLine("3) крестьянина;   (Сложно)");

            playerClass = Optional.PhraseChoice(3);

            Console.WriteLine("...нечего взять, разбойники нашли чем поживиться.");
            Console.WriteLine("");

            Console.WriteLine("Но кое-что они всё же оставили.");
            Console.Write("Тщательно обыскав дом, вы находите ");

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
                Optional.GetGoKey(player);
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
                    ViewPhrase(11, 17);
                }
                
            }
            
        }

        private void Cave()
        {
            for (int k = 110; k <= 116; k++) { Console.WriteLine(phrasesMas[k,1]); }
            string choice = Optional.PhraseChoice(3);

            switch (choice)
            {
                case "1":
                    CaveDialog();
                    break;

                case "2":
                    Console.WriteLine("Вы пытаетесь незаметно подкрасться к гному, но он замечает вас и быстро убегает в глубь пещеры.");
                    Console.WriteLine("У вас есть последний шанс уйти.");
                    Console.WriteLine("1) Пройти в глубь пещеры в след за гномом.");
                    Console.WriteLine("2) Выйти и продолжить свой путь по лесу.");
                    #region BACK CHOICE
                    string backChoice = Optional.PhraseChoice(2);
                    
                    switch (backChoice)
                    {
                        case "1":
                            Console.WriteLine("Вы отправляетесь а погоню за гномом.");
                            Optional.GetGoKey(player);
                            Console.WriteLine("За углом вас встречает толпа гномов.");
                            CaveFight();
                            break;

                        case "2":
                            Console.WriteLine("ВЫ разворачиваетесь и выходите из пещеры.");
                            Optional.GetGoKey(player);
                            TrollCamp();
                            break;
                    }
                    #endregion
                    break;
                    
                case "3":
                    Console.WriteLine("Вы развернулись и вышли из пещеры. К счастью, вы остались незамечаными.");
                    Optional.GetGoKey(player);
                    TrollCamp();
                    break;
            } 
        }

        private void CaveDialog()
        {
            
            Console.WriteLine("1) Гхм... Добрый день.");
            Console.WriteLine("2) Ты еще кто такой?!");
            string dialogPhrase = Optional.PhraseChoice(2);
            
            switch (dialogPhrase)
            {
                case "1":
                    Console.WriteLine("         [Вы]: Гхм... Добрый день.");
                    Console.WriteLine("         [Гном]: !@#$% ");
                    Console.WriteLine("         [Гном]: Напугал! Людям тут не место, убирайся!");

                    Console.WriteLine("1) Ахаха, да что ты мне сделаешь, карлик?");
                    Console.WriteLine("2) Прости, я не хотел тебя напугать...");
                    Console.WriteLine("3) Ладно, ладно, уже ухожу.");
                    dialogPhrase = Optional.PhraseChoice(3);
                    switch (dialogPhrase)
                    {
                        case "1":
                            Console.WriteLine("         [Вы]: Ахаха, ну и что ты мне сделаешь, карлик?");
                            Console.WriteLine("         [Гном]: Да как ты смеешь, жалкий человечишка! ");
                            Console.WriteLine("         [Гном]: Живым тебе отсюда не уйти.");
                            break;
                        case "2":
                            Console.WriteLine("         [Вы]: Прости, я не хотел тебя напугать...");
                            Console.WriteLine("         [Гном]: К чёрту извинения. Что тебе надо?");
                            break;
                        case "3":
                            Console.WriteLine("         [Вы]: Ладно, ладно, уже ухожу.");
                            Console.WriteLine("         [Гном]: Пошивеливайся!");
                            Console.WriteLine("Вы развернулись и вышли из пещеры.");
                            Optional.GetGoKey(player);
                            TrollCamp();
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("         [Вы]: Ты еще кто такой?!");
                    Console.WriteLine("         [Гном]: !@#$%*& ");
                    Console.WriteLine("         [Гном]: Ах ты мерзавец, проваливай, пока цел!");

                    Console.WriteLine("1) Ахаха, да что ты мне сделаешь, карлик?");
                    Console.WriteLine("2) Очаровательный хам...");
                    Console.WriteLine("3) Хорошо, только без глупостей. (уйти)");
                    dialogPhrase = Optional.PhraseChoice(3);

                    switch (dialogPhrase)
                    {
                        case "1":
                            Console.WriteLine("         [Вы]: Ахаха, ну и что ты мне сделаешь, карлик?");
                            Console.WriteLine("         [Гном]: Сдавайся сейчас, и, возможно, я пощажу тебя!");
                            break;
                        case "2":
                            Console.WriteLine("         [Вы]: Очаровательный хам...");
                            Console.WriteLine("         [Гном]: Готовься, сейчас мы тебе устрим взбучку!");
                            Console.WriteLine("         [Вы]: Мы?...");
                            Optional.GetGoKey(player);
                            Console.WriteLine("Из глубины пещеры на вас выходит толпа гномов.");
                            CaveFight();
                            break;
                        case "3":
                            Console.WriteLine("         [Вы]: Хорошо, только без глупостей.");
                            Console.WriteLine("         [Гном]: Пошивеливайся!");
                            Console.WriteLine("Вы развернулись и вышли из пещеры.");
                            Optional.GetGoKey(player);
                            TrollCamp();
                            break;
                    }

                    break;
            }

        }

        private void CaveFight()
        {

        }

        private void TrollCamp()
        {
            Console.ReadLine();
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
                    Console.WriteLine("Количество ваших денег: " + player.Gold);
                    break;

                case 16:        // отдых
                    Optional.GetSleepCommand(player, true);
                    break;
            }
        }

        private int NextEnemyStep()
        {
            return (random.Next(2, 4) + step);
        }

    }
}
