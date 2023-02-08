using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace JustDoIt
{
    public static class Constants
    {
        public const string DatabaseFileName = "JustToDoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Открытие базы данных в read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Создание бд, если она отсутствует
            SQLite.SQLiteOpenFlags.Create; 
            //|
            //// Многопоточный доступ к бд
            //SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                return Path.Combine(basePath, DatabaseFileName);
            }
        }

        public static Color HighPriority = Color.FromArgb(226, 109, 0);
       
        public static Color MediumPriority = Color.FromArgb(255, 219, 90);
        
        public static Color LowPriority = Color.FromArgb(29, 222, 125); 

        public static string DefaultSite = "https://dev.by/";

        public static List<List<string>> ForSql;

        public static string[] MotivatingQuotes;

        public static string[] MotivatingQuotesEng;

        public static string FileLanguageName = "AppLanguage.txt";

        public const string ChosenMessageEng = "You chosen";

        public const string ChosenMessageRu = "Вы выбрали";

        static Constants()
        {
            ForSql = new List<List<string>>()
            {
                new List<string>() { "0", "1" },
                new List<string>() { "0", "1" },
                new List<string>() { "0", "1", "2" },
            };

            MotivatingQuotes = new string[]
            {
                "«Ваше время ограничено, поэтому не тратьте его зря на чужую жизнь». \n – Стив Джобс",
                "«Мы находимся здесь, чтобы внести свой вклад в этот мир. А иначе зачем мы здесь?». \n – Стив Джобс",
                "«Оставайтесь голодными. Оставайтесь безрассудными». Я всегда желал себе этого. \nИ теперь, когда вы заканчиваете институт и начинаете заново, я желаю этого вам». \n – Стив Джобс",
                "«Если вы ещё не нашли своего дела, ищите. Не останавливайтесь. \nКак это бывает со всеми сердечными делами, вы узнаете, когда найдёте. \nИ, как любые хорошие отношения, они становятся лучше и лучше с годами. \nПоэтому ищите, пока не найдёте. Не останавливайтесь». \n - Стив Джобс",
                "«Если бы у меня было пять минут и возможность донести до аудитории только одну, максимально полезную мысль \n - я посоветовал бы «записать свои цели, составить план по их достижению и \n работать над ним каждый день». \n - Брайан Трейси",
                "«Никто не лучше вас. Никто не умнее вас. Просто они раньше начали». \n - Брайан Трейси",
                "«Если хочешь получить то, что никогда не имел, стань тем, кем никогда не был». \n - Брайан Трейси",
                "«Если не ставить себе цели и не планировать способы их достижения - шансы дойти до конца и получить результат минимальны». \n - Брайан Трейси",
                "«Думаете ли вы, что можете, или думаете, что не можете - в обоих случаях вы правы». \n - Генри Форд",
                "«Ты не проигравший до тех пор, пока не сдался!». \n - Майкл Джордан",
                "«Идеального момента не бывает. Самое идеальное время что-то начать делать - сейчас». - Джейсон Фрайд"
            };

            MotivatingQuotesEng = new string[]
            {
                "\"Your time is limited, so don't waste it on someone else's life\". \n - Steve Jobs",
                "\"We are here to contribute to this world. Why else would we be here?\" \n Steve Jobs",
                "Stay hungry. Stay reckless.\" That's what I've always wished for myself. \n And now that you're graduating and starting over, that's what I wish for you\". - \n Steve Jobs",
                "If you haven't found your business yet, look for it. Don't stop. \n You'll know when you find it, as you do with all affairs of the heart. \n And like all good relationships, they get better and better over the years. \n So keep looking until you find it. Don't stop\". \n - Steve Jobs",
                "If I had five minutes and the opportunity to deliver just one, maximally useful message \n my advice would be to 'write down your goals, make a plan to achieve them, and \n work on it every day\". \n - Brian Tracy",
                "Nobody is better than you. Nobody's smarter than you. \n They're just ahead of you\". \n - Brian Tracy",
                "If you want to get what you've never had, become what you've never been\". \n - Brian Tracy",
                "If you don't set goals and plan ways to achieve them, \n the chances of getting to the end and getting results are minimal\".\n - Brian Tracy",
                "Whether you think you can or think you can't, \n in both cases you're right\". \n - Henry Ford",
                "You're not a loser until you've given up!\" \n - Michael Jordan",
                "There is no perfect moment. The most perfect time \n to start doing something is now\". \n - Jason Fryde"
            };
        }
    }
}

