using System;

namespace Dictionary
{
    class Program
    {
        class Dict
        {
            public bool start = true;
            public ConsoleKeyInfo keyPressed;
            Dictionary<String, String> dict = new Dictionary<String, String>();
            public void Run()
            {
                DictionaryEx();
            }

            public bool Search(String arg)
            {
                List<String> list = new List<String>();
                foreach(var it in dict)
                {
                    if(it.ToString().Contains(arg))
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
            public void Menu()
            {
                Console.WriteLine("Англо-русский словарь");
                Console.WriteLine("1 - Найти перевод на Русский");
                Console.WriteLine("2 - Найти перевод на Английский");
                Console.WriteLine("3 - Добавить запись");
                Console.WriteLine("0 - Выход");
                keyPressed = Console.ReadKey(true);
            }
            public void DictionaryEx()
            {
                
                dict.Add("hello", "привет");
                dict.Add("bye", "пока");
                #region Menu
                Menu();
                #endregion
                
                while (start)
                {
                    #region Поиск по англ слову
                    if (keyPressed.KeyChar == '1')
                    {
                        Console.WriteLine("Введите английское слово : ");
                        String enWord = Console.ReadLine();
                        String ruWord = null;
                        try
                        {
                            ruWord = dict[enWord.ToLower()];
                            Console.WriteLine($"ru : {ruWord.ToLower()}");
                        }
                        catch
                        {
                            if (Search(enWord))
                            {
                                Console.WriteLine("Попробуйте еще раз!");
                            }
                            else
                                ruWord = "НЕ НАЙДЕНО";
                        }
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить. Консоль очистится!");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                    #endregion
                    #region Поиск по русскому слову
                    else if (keyPressed.KeyChar == '2')
                    {
                        Console.WriteLine("Введите русское слово : ");
                        String ruWord = Console.ReadLine();

                        foreach (var it in dict)
                        {
                            if (it.Value == ruWord.ToLower())
                            {
                                Console.WriteLine($"Перевод: {it.Key}");
                                break;
                            }
                            else if(Search(ruWord))
                            {
                                Console.WriteLine("Попробуйте еще раз!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("НЕ НАЙДЕНО");
                                break;
                            }
                        }
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить. Консоль очистится!");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                    #endregion

                    #region Добавить запись
                    else if(keyPressed.KeyChar == '3')
                    {
                        Console.WriteLine("Вы хотите добавить слово. Следуйте инструкциям ниже: ");
                        Console.WriteLine("Введите слово на английском языке: ");
                        String enWord = Console.ReadLine();
                        String ruWord = null;
                        try
                        {
                            dict.Add(enWord.ToLower(), ruWord.ToLower());
                            
                        }
                        catch
                        {
                            Console.WriteLine("Такое слово уже существует!");
                        }
                        finally
                        {
                            Console.WriteLine("Отлично. Такого слова не существует!");
                            Console.WriteLine("Теперь введите перевод на русском языке: ");
                            ruWord = Console.ReadLine();
                            dict.Add(enWord.ToLower(), ruWord.ToLower());
                            Console.WriteLine($"{enWord} - {ruWord}");
                        }
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить. Консоль очистится!");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                    #endregion
                    #region Выход
                    else if (keyPressed.KeyChar == '0')
                    {
                        Console.WriteLine("Подтвердите выход из программы! Нажмите Enter!");
                        keyPressed = Console.ReadKey();
                        if(keyPressed.Key == (ConsoleKey)13)
                        {
                            Console.WriteLine("Спасибо за использование нашего словаря! До свидания!");
                            start = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы отменили выход из программы!");
                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить. Консоль очистится!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    #endregion

                }
            }
        }
        static void Main(string[] args)
        {
            new Dict().Run();
        }
    }
   

}