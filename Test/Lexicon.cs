using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHunter
{
    /// <summary>
    /// Словарик
    /// </summary>
    public class Lexicon
    {
        private List<Word>? _words;
        /// <summary>
        /// Добавить слово
        /// </summary>
        /// <param name="word">Значение</param>
        public void AddWord(string? word)
        {
            if (_words != null)
                _words.Add(new Word(word));
            else
            {
                _words = new List<Word>();
                AddWord(word);
            }
        }
        /// <summary>
        /// Добавить перевод
        /// </summary>
        /// <param name="word">Слово к которому добавить перевод</param>
        /// <param name="translation">Перевод слова</param>
        public void AddTranslation(string? word, string? translation)
        {
            var vas = _words.Where(p => p.Meaning.ToLower() == word.ToLower());

            if (vas.Count() > 0)
            {
                vas.Last().AddTranslation(translation);
            }
        }
        /// <summary>
        /// Вывести на экран весь словарь
        /// </summary>
        public void PrintLexicon()
        {
            foreach (var item in _words)
            {
                if (item != null)
                    item.Print();
            }
        }
        /// <summary>
        /// Поиск по "ключу", где ключ идентификатор слова
        /// </summary>
        /// <param name="key">Идентификатор</param>
        public void Search(int key)
        {
            Console.WriteLine("\tПоиск по ключу '{0}'", key);

            try
            {
                var result = _words.Where(p => p.Id.ToString().Contains(key.ToString()));

                Console.WriteLine("  Ой, кажется нашлось {0} записи", result.Count());

                foreach (var t in result)
                    t.Print();
            }
            catch
            {
                Console.WriteLine(" Все-таки ерунду ввели))");
            }
        }
        /// <summary>
        /// Поиск по "ключу", где ключ слова в словаре
        /// </summary>
        /// <param name="key">Слово</param>
        public void Search(string? key)
        {
            Console.WriteLine(" Поиск по ключу '{0}'", key);

            try
            {

                var result = _words.Where(p => p.Meaning.ToLower().Contains(key.ToLower()));

                Console.WriteLine("  Ой, кажется нашлось {0} записи", result.Count());

                foreach (var t in result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    t.Print();
                    Console.ResetColor();
                }  
            }
            catch
            {
                Console.WriteLine(" К сожалению ничего не нашлось");
            }
        }
        /// <summary>
        /// Сортировка по языкам
        /// </summary>
        /// <param name="language">Язык</param>
        public void Sort(Language language)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tСортировка на {0} в алфавитном порядке", language);
                Console.ResetColor();
                foreach (var t in _words.Where(p => p.Language == language).OrderBy(p => p.Meaning))
                    t.Print();
            }
            catch
            {
            }
        }

        public void ChangeTranslation(string? word, string? translationWord, string? translation)
        {
            try
            {
                var t = _words.Where(p => p.Meaning.ToLower() == word.ToLower());
                t.First().Change(translationWord, translation);
            }
            catch
            {
            }
        }

        public int GetCount()
        {
            return _words.Count;
        }

        public void Search(string? key,ref int buf)
        {
            Console.WriteLine(" Поиск по ключу '{0}'", key);

            try
            {

                var result = _words.Where(p => p.Meaning.ToLower().Contains(key.ToLower()));

                buf = result.Count();

                Console.WriteLine("  Ой, кажется нашлось {0} записи", result.Count());

                foreach (var t in result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    t.Print();
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.WriteLine(" К сожалению ничего не нашлось");
            }
        }
    }
}
