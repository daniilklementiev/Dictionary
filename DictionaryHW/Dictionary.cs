using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExam
{
    internal class DictionaryEX
    {
        public ConsoleKeyInfo keyPressed;
        private Dictionary<String, String> dict;
        private int choiceLang;
        private string path;

        public DictionaryEX()
        {
            choiceLang = 2; // 1 - rus, 2 - eng
            dict = new Dictionary<String, String>();
            path = "dictionary.txt";
        }
        public void Run()
        {
            DictionaryEx();
        }

        public bool SearchOut(String arg)
        {
            List<String> list = new List<String>();
            foreach (var it in dict)
            {
                if (it.ToString().Contains(arg))
                {
                    list.Add(it.ToString());
                }
            }
            if (list.Count > 0)
            {
                Console.WriteLine("Возможно Вы имели ввиду : ");
                foreach (var it in list)
                {
                    Console.WriteLine($"{it}\n");
                }
                return true;
            }
            else
                return false;

        }
        public bool Search(String arg)
        {
            List<String> list = new List<String>();
            foreach (var it in dict)
            {
                if (it.ToString().Contains(arg))
                {
                    list.Add(it.ToString());
                }
            }
            if (list.Count > 0)
            {
                return true;
            }
            else
                return false;

        }

        public void Language()
        {
            Console.WriteLine("----Hello----");
            Console.WriteLine("Choose language/Выберите язык");
            Console.WriteLine("1. Русский");
            Console.WriteLine("2. English");
            keyPressed = Console.ReadKey(true);
            if(keyPressed.KeyChar == '1')
            {
                choiceLang = 1;
                Menu();
            }
            else if (keyPressed.KeyChar == '2')
            {
                choiceLang = 2;
                Menu();
            }
            else
            {
                keyPressed = Console.ReadKey(true);
            }
        }

        public void Menu()
        {
            Console.WriteLine(choiceLang == 1 ? "Англо-русский словарь" : "Translator");
            Console.WriteLine(choiceLang == 1 ? "1 - Найти перевод с Английского на Русский"
                : "1 - Find translate from English to Russian");
            Console.WriteLine(choiceLang == 1 ? "2 - Найти перевод с Русского на Английский"
                : "2 - Find translate from Russian to English");
            Console.WriteLine(choiceLang == 1 ? "3 - Добавить запись" : "3 - Add new word");
            Console.WriteLine(choiceLang == 1 ? "0 - Выход" : "0 - Exit");
            keyPressed = Console.ReadKey(true);
        }

        

        public async Task DictionaryEx()
        {
            //await ReadFileAndParse();
/*
            #region Menu
            Language();
            #endregion

            while (0 < 1)
            {
                #region Поиск по англ слову
                if (keyPressed.KeyChar == '1')
                {
                    Console.WriteLine(choiceLang == 1 ? "Введите английское слово : " 
                        : "Input english word");
                    Console.WriteLine("");
                    String enWord = Console.ReadLine();
                    String ruWord = null!;
                    if (Search(enWord))
                    {
                        try
                        {
                            ruWord = dict[enWord.ToLower()];
                            Console.WriteLine(choiceLang == 1 ? $"На русском это : {ruWord.ToLower()}"
                       : $"Russian : {ruWord.ToLower()}");
                            Console.WriteLine();
                        }
                        catch
                        {
                            SearchOut(enWord);
                        }
                    }
                    else
                    {
                        ruWord = choiceLang == 1 ? "Такого слова не существует в словаре."
                            : "This word doesn't exist";
                        Console.WriteLine($"{ruWord}");
                    }
                    Console.WriteLine(choiceLang == 1 ? "Нажмите любую кнопку чтобы продолжить. Консоль очистится!" :
                        "Press any button. Console will clear");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                #endregion
                #region Поиск по русскому слову
                else if (keyPressed.KeyChar == '2')
                {
                    Console.WriteLine(choiceLang == 1 ? "Введите русское слово : "
                        : "Input russian word");
                    String ruWord = Console.ReadLine();

                    foreach (var it in dict)
                    {
                        if (it.Value == ruWord?.ToLower())
                        {
                            Console.WriteLine(choiceLang == 1 ? $"Перевод: {it.Key}" :
                            $"Translation: {it.Key}");
                            break;
                        }
                        else if (SearchOut(ruWord))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(choiceLang == 1 ? "Не найдено" :
                            "Not found");
                            break;
                        }
                    }
                    Console.WriteLine(choiceLang == 1 ? "Нажмите любую кнопку чтобы продолжить. Консоль очистится!" :
                        "Press any button. Console will clear");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                #endregion

                #region Добавить запись
                else if (keyPressed.KeyChar == '3')
                {
                    String enWord = null!;
                    String ruWord = null!;
                    Console.WriteLine(choiceLang == 1 ? "Вы хотите добавить слово. Следуйте инструкциям ниже: " :
                        "You want to add a new word. Follow instructions");
                    Console.WriteLine(choiceLang == 1 ? "Введите слово на английском языке: " :
                        "Input english word");
                    try
                    {
                        enWord = Console.ReadLine();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        dict.Add(enWord?.ToLower(), ruWord.ToLower());
                        if (!Search(enWord))
                        {
                            Console.WriteLine(choiceLang == 1 ? "Отлично. Такого слова не существует!" :
                                "Gread, word doesn't exist");
                            Console.WriteLine(choiceLang == 1 ? "Теперь введите перевод на русском языке: " :
                                "Now input russian word");
                            ruWord = Console.ReadLine();
                            dict.Add(enWord.ToLower(), ruWord?.ToLower());
                            Console.WriteLine($"{enWord} - {ruWord}");
                        }
                        else
                            dict.Remove(enWord.ToLower());
                    }
                    catch
                    {
                        if (Search(enWord))
                            Console.WriteLine(choiceLang == 1 ? "Такое слово уже существует!" :
                                "This word already exist");
                        else 
                        {
                            Console.WriteLine(choiceLang == 1 ? "Отлично. Такого слова не существует!" :
                                "Gread, word doesn't exist");
                            Console.WriteLine(choiceLang == 1 ? "Теперь введите перевод на русском языке: " :
                                "Now input russian word");
                            ruWord = Console.ReadLine();
                            dict.Add(enWord.ToLower(), ruWord.ToLower());
                            Console.WriteLine($"{enWord} - {ruWord}");
                        }
                    }
                    Console.WriteLine(choiceLang == 1 ? "Нажмите любую кнопку чтобы продолжить. Консоль очистится!" :
                        "Press any button. Console will clear");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                #endregion
                #region Выход
                else if (keyPressed.KeyChar == '0')
                {
                    Console.WriteLine(choiceLang == 1 ? "Подтвердите выход из программы! Нажмите Enter!" :
                        "Confirm exit with pressing enter");
                    keyPressed = Console.ReadKey();
                    if (keyPressed.Key == (ConsoleKey)13)
                    {
                        Console.WriteLine(choiceLang == 1 ? "Спасибо за использование нашего словаря! До свидания!" :
                            "Thank you for using our dictionary");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(choiceLang == 1 ? "Вы отменили выход из программы!" :
                            "You canceled exiting");
                        Console.WriteLine(choiceLang == 1 ? "Нажмите любую кнопку чтобы продолжить. Консоль очистится!" :
                        "Press any button. Console will clear");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                #endregion

            }*/
        }
    }
}
