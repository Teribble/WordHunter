using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHunter
{
    public sealed class Application
    {
        private Application() { }

        public Lexicon Lexicon { get; set; }

        private static Application _instance;

        public static Application GetApplication()
        {
            if (_instance == null)
                _instance = new Application();

            return _instance;
        }
        /// <summary>
        /// Создать словарик
        /// </summary>
        public void CreateLexicone()
        {
            if (Lexicon == null)
                Lexicon = new Lexicon();
        }
        /// <summary>
        /// Заполнить словарь
        /// </summary>
        public void FillLexicone()
        {
            string words = "Безобразие Биография Разлагать Совать Тур Кабарга Ливанцы Между Различить Решетка Ротонда Абсурд Бланк Заржать Пирожок Buffet Contraceptive Gadenosh Glaciation Nashatny Newsboy Rostepel Skillful Sniffy Split";
            var wordsArray = words.Split(' ');

            string translations = "Disgrace Biography Decompose Poke Tour Musk Deer Lebanese Between Distinguish Lattice Rotunda Absurd Blank Neigh Буфет Контрацептив Гаденош Оледенение Нашатный Газетчик Ростепель Умелый Сниффи Сплит";
            var translationsArray = translations.Split(' ');

            for (int i = 0; i < wordsArray.Length; i++)
            {
                Lexicon.AddWord(wordsArray[i]);
                if (i <= translationsArray.Length)
                {
                    Lexicon.AddTranslation(wordsArray[i], translationsArray[i]);
                }
            }

            Lexicon.AddWord("Echelon");
            Lexicon.AddTranslation("Echelon", "эшелон");

            Lexicon.AddWord("get");
            Lexicon.AddTranslation("get", "получить");
            Lexicon.AddTranslation("get", "получение");

            Lexicon.AddWord("enough");
            Lexicon.AddTranslation("enough", "достаточный");
            Lexicon.AddTranslation("enough", "столько");

            Lexicon.AddTranslation("Deer", "Лань");
            Lexicon.AddTranslation("Deer", "Красный зверь");

            Console.WriteLine("Добавлено {0} новых записей", Lexicon.GetCount());

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Вывести на экран словарик
        /// </summary>
        public void DrawLexicone()
        {
            Console.Clear();
            Lexicon.PrintLexicon();
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Поиск по слову
        /// </summary>
        /// <param name="key">Слово</param>
        public void WordSearch()
        {
            Console.Clear();
            Console.WriteLine("Введите пожалуйста ключ, это может быть как слово, так и идентификатор");
            Console.WriteLine("1: Идентификатор \n2: Слово");
            try
            {
                Console.Write("Ваш выбор: ");
                var res = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                if (res > 2 || res < 0)
                {
                    Console.WriteLine("Давай по новой");
                    Console.WriteLine("Для продолжения нажмите Enter");
                    Console.ReadLine();
                    WordSearch();
                }
                switch (res)
                {
                    case 1:
                        try
                        {
                            Console.Write("Введите идентификатор: ");
                            var result1 = Int32.Parse(Console.ReadLine());
                            Lexicon.Search(result1);
                        }
                        catch
                        {
                            Console.WriteLine("Ерунду ввели");

                            Console.WriteLine("Для продолжения нажмите Enter");
                            Console.ReadLine();

                            WordSearch();
                        }
                        break;
                    case 2:
                        Console.Write("Введите слово: ");
                        var result = Console.ReadLine();
                        Lexicon.Search(result);
                        break;
                }
                Console.WriteLine("Для продолжения нажмите Enter");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("На цифры не похоже, давай по новой");
                Console.WriteLine("Для продолжения нажмите Enter");
                Console.ReadLine();
                WordSearch();
            }

        }
        /// <summary>
        /// Сортировка по языку
        /// </summary>
        /// <param name="language">Язык</param>
        public void Sorting()
        {
            Console.Clear();
            Console.WriteLine("1: Russian\n 2: English");
            try
            {
                var t = Int32.Parse(Console.ReadLine());

                switch (t)
                {
                    case 1:
                        Lexicon.Sort(Language.Russian);
                        break;
                    case 2:
                        Lexicon.Sort(Language.English);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Давайка цифры вводи");
                Sorting();
            }
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Изменить перевод слова
        /// </summary>
        public void Change()
        {
            int buf = 0;
            Console.WriteLine("Введите слово, или часть слова перевод которого нужно изменить");
            string word = Console.ReadLine();

            WordSearch(word, ref buf);

            if(buf > 0)
            {
                Console.WriteLine("Введите слово, перевод которого нужно изменить");
                string word1 = Console.ReadLine();

                Console.WriteLine("Введите перевод, который нужны изменить");
                string wordTranslation = Console.ReadLine();

                Console.WriteLine("Введите новый перевод");
                string translation = Console.ReadLine();


                Lexicon.ChangeTranslation(word1, wordTranslation, translation);
            }

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Добавить новое слово
        /// </summary>
        public void AddWord()
        {
            Console.Write("Введите новое слово: ");
            string word = Console.ReadLine();
            Console.WriteLine();

            Lexicon.AddWord(word);

            AddTranslation(word);

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Добавить перевод к слову
        /// </summary>
        public void AddTranslation()
        {
            int buf = 0;
            Console.WriteLine("Введите слово или часть к которому нужно добавить перевод, если оно есть, добавим)");
            string? word = Console.ReadLine();

            WordSearch(word, ref buf);

            if(buf > 0) 
            {
                Console.WriteLine("Введи слово");
                string? word1 = Console.ReadLine();

                Console.WriteLine("Введи новый перевод слова");
                string? translation = Console.ReadLine();

                Lexicon.AddTranslation(word1, translation);

                Console.WriteLine("Для продолжения нажмите Enter");
                Console.ReadLine();
            }

        }
        /// <summary>
        /// Добавить перевод к слову
        /// </summary>
        /// <param name="word"></param>
        public void AddTranslation(string? word)
        {

            Console.WriteLine("Введи новый перевод слова");
            string? translation = Console.ReadLine();

            Lexicon.AddTranslation(word, translation);

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }
        /// <summary>
        /// Приватный поиск слова
        /// </summary>
        /// <param name="word"></param>
        /// <param name="buf"></param>
        private void WordSearch(string? word,ref int buf)
        {
            Lexicon.Search(word, ref buf);
        }
    }
}
