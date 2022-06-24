using System.Text.RegularExpressions;


namespace WordHunter
{
    /// <summary>
    /// Слово
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Ширина поля в таблице
        /// </summary>
        private const int Width = 20;
        /// <summary>
        /// Счетчик
        /// </summary>
        private static int _id = 0;
        /// <summary>
        /// Идентификтор
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Язык, на котором написано слово
        /// </summary>
        public Language Language { get; }
        /// <summary>
        /// Значение слова
        /// </summary>
        public string Meaning { get; set; }
        /// <summary>
        /// Список слов перевода
        /// </summary>
        internal List<Word> _translation { get; set; }
        /// <summary>
        /// Конструктор для использования внутри этого класса
        /// </summary>
        /// <param name="language">Язык</param>
        /// <param name="word">Слово</param>
        protected Word(Language language, string? word)
        {
            Id = ++_id;

            Language = language;

            Meaning = word;
        }
        /// <summary>
        /// Слово
        /// </summary>
        /// <param name="word">Значение для слова</param>
        public Word(string? word)
        {
            Id = ++_id;

            if (IsEnglish(word))
                Language = Language.English;
            if (IsRussian(word))
                Language = Language.Russian;

            Meaning = word;
        }
        /// <summary>
        /// Конструктор для использования внутри этого класса, для присвоения ID головного слова, ID-кам слов перевода
        /// </summary>
        /// <param name="language">Язык</param>
        /// <param name="word">Значение</param>
        /// <param name="id">Идентификатор</param>
        protected Word(Language language, string word, int id)
        {
            Id = id;

            if (IsEnglish(word))
                Language = Language.English;
            if (IsRussian(word))
                Language = Language.Russian;

            Meaning = word;
        }
        /// <summary>
        /// Добавить перевод
        /// </summary>
        /// <param name="tranlation">Слово перевод</param>
        public void AddTranslation(string? tranlation)
        {
            switch (Language)
            {
                case Language.Russian:
                    if (_translation != null)
                    {
                        if (IsEnglish(tranlation.ToLower()))
                            _translation.Add(new Word(Language.English, tranlation, Id));
                    }
                    else
                    {
                        _translation = new List<Word>();
                        if (IsEnglish(tranlation.ToLower()))
                            _translation.Add(new Word(Language.English, tranlation, Id));
                    }
                    break;
                case Language.English:
                    if (_translation != null)
                    {
                        if (IsRussian(tranlation.ToLower()))
                            _translation.Add(new Word(Language.Russian, tranlation, Id));
                    }
                    else
                    {
                        _translation = new List<Word>();
                        if (IsRussian(tranlation.ToLower()))
                            _translation.Add(new Word(Language.Russian, tranlation, Id));
                    }

                    break;
            }
        }
        /// <summary>
        /// Проверка, является ли слово Английским
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns></returns>
        private bool IsEnglish(string? word)
        {
            if (new Regex(@"[a-zA-Z]").Match(word).Length > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Проверка, является ли слово Русским
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns></returns>
        private bool IsRussian(string? word)
        {
            if (new Regex(@"[а-яА-ЯёЁ]").Match(word).Length > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Вывести на экран слово с его переводом, если оно доступно
        /// </summary>
        public void Print()
        {
            if (_translation != null)
            {
                Console.WriteLine(new String('-', Width * 3 + 3));
                Console.Write(("|Id: " + Id).PadRight(Width) + "|");
                Console.Write((Meaning.ToUpper()).PadRight(Width) + "|");
                Console.WriteLine((_translation[0].Meaning.ToUpper()).PadRight(Width) + "|");

                for (int i = 1; i < _translation.Count; i++)
                {
                    Console.Write(("|").PadRight(Width) + "|");
                    Console.Write(("").PadRight(Width) + "|");
                    Console.WriteLine((_translation[i].Meaning.ToUpper()).PadRight(Width) + "|");
                }
                Console.WriteLine(new String('-',Width*3+3));
            }
        }
        /// <summary>
        /// Изменить перевод слова
        /// </summary>
        /// <param name="word">Слово в котором нужно изменить перевод</param>
        /// <param name="translation">на что изменить</param>
        public void Change(string? word, string? translation)
        {
            try
            {
                var t = _translation.Where(p => p.Meaning.ToLower() == word.ToLower());

                t.First().Meaning = translation;
            }
            catch
            {
            }
        }
    }
}
