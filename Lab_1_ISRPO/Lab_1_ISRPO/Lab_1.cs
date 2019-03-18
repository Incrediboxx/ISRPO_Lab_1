using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            // Список элементов структуры
            List<Worker> Workers = new List<Worker>();
            Filter filter = new Filter();
            
            while (true) {
                // Вывод главного меню
                Console.WriteLine(" ---------------МЕНЮ---------------");
                Console.WriteLine(" Добавить.........................1");
                Console.WriteLine(" Отфильтрованный список...........2");
                Console.WriteLine(" Исходный список..................3");
                Console.WriteLine(" Установить фильтр................4");
                Console.WriteLine(" Выход............................0");
                
                // Выбор действия
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));

                switch (n) { // Выполение выбранного действия

                    case 1: // Добавление элемента в список
                            Console.Clear();
                            Worker Temp = new Worker();                 
                            Workers.Add(Temp.Push());
                            break;
                    
                    case 2: // Вывод отфильтрованного списка
                            Console.Clear();
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i.ApplyFilter(filter));
                            }
                            Console.ReadLine();
                            break;
                        
                    case 3: // Вывод исходного списка
                            Console.Clear();
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                            break;

                    case 4: // Установка значений фильтра
                            Console.Clear();
                            filter.FiilFromConsole();
                            break;

                    case 0: // Выход из программы
                            return;

                    default: break;
                }
                Console.Clear();
            }
        }

        // Cтруктура Работник
        struct Worker {
            public String Name ;       // ФИО
            public DateTime Birthday;  // День рождения
            public String Post;        // Должность
            public int Salary;         // Зарплата

            // Метод для установки полей рабочего, возвращает объект структуры Worker
            public Worker Push() { 
                // Вводим ФИО
                Console.Write(" ФИО: ");
                Name = Console.ReadLine();
                // Вводим дату рождения, проверяем вводимые данные на их корректность
                do {
                    Console.Write(" Дата рождения (дд.ММ.гггг): ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out Birthday));
                // Вводим должность
                Console.Write(" Должность: ");
                Post = Console.ReadLine();
                // Вводим зарплату, проверяем вводимые данные на их корректность
                do {
                    Console.Write(" Зарплата: ");
                } while (!Int32.TryParse(Console.ReadLine(), out Salary));
                return this;
            }

            // Проверка полей на соответствие фильтру, если не прошло возвращает NULL
            public Worker? ApplyFilter(Filter filter) {
                if (filter.NameSubstr != null && !Name.Contains(filter.NameSubstr))
                    return null;
                if (filter.PostSubstr != null && !Post.Contains(filter.PostSubstr))
                    return null;
                if (filter.SalaryLower != null && Salary < filter.SalaryLower)
                    return null;
                if (filter.SalaryLower != null && Salary > filter.SalaryUpper)
                    return null;
                if (filter.BirthdayLower != null && Birthday < filter.BirthdayLower)
                    return null;
                if (filter.BirthdayUpper != null && Birthday > filter.BirthdayUpper)
                    return null;
                return this;
            }

            // Перегруженный метод ToString() для данной структуры
            public override string ToString() {
                return String.Format(" ФИО:           {0}\n Дата рождения: {1:dd.MM.yyyy}\n Должность:     {2}\n Зарплата:      {3}\n", Name, Birthday, Post, Salary);
            }
        }

        // Структура Фильтр
        struct Filter {
            public string NameSubstr;       // Значение фильтра ФИО
            public string PostSubstr;       // Значение фильтра Должность
            public int? SalaryLower;        // Мин значение фильтра Зарплата
            public int? SalaryUpper;        // Макс значение фильтра Зарплата
            public DateTime? BirthdayLower; // Мин значение фильтра День рождения
            public DateTime? BirthdayUpper; // Макс значение фильтра День рождения

            // Функция установки значений фильтра с консоли
            public void FiilFromConsole() {
                Console.Write("ФИО: ");
                NameSubstr = EnterString();
                Console.Write("Должность: ");
                PostSubstr = EnterString();
                Console.Write("Минимальная зарплата: ");
                SalaryLower = EnterInt("Неверный формат");
                Console.Write("Максимальная зарплата: ");
                SalaryUpper = EnterInt("Неверный формат");
                Console.Write("Минимальная дата: ");
                BirthdayLower = EnterDateTime("Неверный формат");
                Console.Write("Максимальная дата: ");
                BirthdayUpper = EnterDateTime("Неверный формат");
            }

            // Функция которая при чтении пустой строки вернет null
            public static string EnterString() {
                string value = Console.ReadLine();
                if (value != string.Empty)
                    return value;
                return null;
            }

            // Функция для ввода опционального числа
            public static int? EnterInt(string reEnterText) {
                while (true) {
                    try {
                        string value = Console.ReadLine();
                        if (value != string.Empty)
                            return int.Parse(value);
                        else
                            return null;
                    }
                    catch (FormatException) {
                        Console.WriteLine(reEnterText);
                    }
                }
            }

            // Функция для ввода опциональной даты
            public static DateTime? EnterDateTime(string reEnterText) {
                while (true) {
                    try {
                        string value = Console.ReadLine();
                        if (value != string.Empty)
                            return DateTime.Parse(value);
                        else
                            return null;
                    }
                    catch (FormatException) {
                        Console.WriteLine(reEnterText);
                    }
                }
            }
        }
    }
}