using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHunter
{
    public class Menu
    {
        public Application Application { get; }
        public Menu(Application application)
        {
            Application = application;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1: Поиск\n2: Вывести словарик\n3: Сортировка по языку\n4: Добавить новое слово\n5: Изменить перевод\n6: Добавить перевод\n7: Exit");

                int result;
                try
                {
                    result = Int32.Parse(Console.ReadLine());

                    switch (result)
                    {
                        case 1:
                            Application.WordSearch();
                            break;
                        case 2:
                            Application.DrawLexicone();
                            break;
                        case 3:
                            Application.Sorting();
                            break;
                        case 4:
                            Application.AddWord();
                            break;
                        case 5:
                            Application.Change();
                            break;
                        case 6:
                            Application.AddTranslation();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Что-то не то ввели");
                            break;
                    }
                }
                catch (Exception)
                {
                    Start();
                }
            }
        }
    }
}
