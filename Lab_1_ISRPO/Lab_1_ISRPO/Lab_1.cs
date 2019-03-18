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
                Console.WriteLine(" 1.Добавить работника");
                Console.WriteLine(" 2.Отфильтрованный список");
                Console.WriteLine(" 3.Полный список");
                Console.WriteLine(" 4.Установить фильтр");
                Console.WriteLine(" 0.Выход");
                
                // Выбор действия
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));

                // Выполнение выбранного действия
                switch (n) { 

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
                        
                    case 3: // Вывод полного списка
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
                }
                Console.Clear();
            }
        }

        // Работник
        struct Worker {
            public String Name ;       // ФИО
            public DateTime Birthday;  // День рождения
            public String Post;        // Должность
            public int Salary;         // Зарплата

            // Ввод нового работника
            public Worker Push() { 
                // Вводим ФИО
                Console.Write(" ФИО: ");
                Name = Console.ReadLine();

                // Вводим дату рождения
                do {
                    Console.Write(" Дата рождения (дд.ММ.гггг): ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out Birthday));

                // Вводим должность
                Console.Write(" Должность: ");
                Post = Console.ReadLine();

                // Вводим зарплату
                do {
                    Console.Write(" Зарплата: ");
                } while (!Int32.TryParse(Console.ReadLine(), out Salary));
                return this;
            }

            // Проверка полей на соответствие фильтру
            public Worker? ApplyFilter(Filter filter) {
                // Проверка по Имени
                if (filter.NameSubstr != null && !Name.Contains(filter.NameSubstr))
                    return null;

                // Проверка по Должности
                if (filter.PostSubstr != null && !Post.Contains(filter.PostSubstr))
                    return null;

                // Проверка по Минимальной зарплате
                if (filter.SalaryLower != null && Salary < filter.SalaryLower)
                    return null;

                // Проверка по Максимальной зарплате
                if (filter.SalaryLower != null && Salary > filter.SalaryUpper)
                    return null;

                // Проверка по Минимальной дате
                if (filter.BirthdayLower != null && Birthday < filter.BirthdayLower)
                    return null;

                // Проверка по Максимальной дате
                if (filter.BirthdayUpper != null && Birthday > filter.BirthdayUpper)
                    return null;
                
                return this;
            }

            // Вывод работника
            public override string ToString() {
                return String.Format("ФИО:           {0}\n " +
                                     "Дата рождения: {1:dd.MM.yyyy}\n " +
                                     "Должность:     {2}\n " +
                                     "Зарплата:      {3}\n", Name, Birthday, Post, Salary);
            }
        }

        //  Фильтр
        struct Filter {
            public string NameSubstr;       // Значение фильтра ФИО
            public string PostSubstr;       // Значение фильтра Должность
            public int? SalaryLower;        // Мин значение фильтра Зарплата
            public int? SalaryUpper;        // Макс значение фильтра Зарплата
            public DateTime? BirthdayLower; // Мин значение фильтра День рождения
            public DateTime? BirthdayUpper; // Макс значение фильтра День рождения

            //  Установка значений фильтра 
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

            //  Ввод строки
            public static string EnterString() {
                string value = Console.ReadLine();
                if (value != string.Empty)
                    return value;
                return null;
            }

            // Ввод опционального числа
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

            // Ввод опциональной даты
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