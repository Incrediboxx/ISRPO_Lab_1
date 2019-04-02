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
            Worker Temp = new Worker();

            // Меню
            while (true) {
                // Вывод главного меню                
                Console.WriteLine(" 1. Добавить работника");
                Console.WriteLine(" 2. Отфильтрованный список");
                Console.WriteLine(" 3. Полный список");
                Console.WriteLine(" 4. Установить фильтр");
                Console.WriteLine(" 0. Выход");
                
                // Выбор действия
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));

                // Выполнение выбранного действия
                switch (n) {                 
                    case 1: // Добавить работника
                            Console.Clear();
                            Workers.Add(Temp.AddWorker());
                            break;
                    
                    case 2: // Вывод отфильтрованного списка
                            Console.Clear();
                            Temp.PrintWithFilter(Workers, filter);
                            break;
                        
                    case 3: // Вывод полного списка
                            Console.Clear();
                            Temp.PrintAll(Workers);
                            break;

                    case 4: // Установка фильтра
                            Console.Clear();
                            filter.FillFromConsole();
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
            public Worker AddWorker() { 
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
            /*
                Входные параметры:
                    filter - фильтр
                Возвращаемые значения:
                    ссылку на работника, при соответствии полям фильтра
                    null, при несоответствии полям фильтра
            */            
                // Проверка по Имени
                if (filter.NameSubstr != null && !Name.Contains(filter.NameSubstr))
                    return null;

                // Проверка по Должности
                if (filter.PostSubstr != null && !Post.Contains(filter.PostSubstr))
                    return null;

                // Проверка по Минимальной зарплате
                if (filter.SalaryMin != null && Salary < filter.SalaryMin)
                    return null;

                // Проверка по Максимальной зарплате
                if (filter.SalaryMin != null && Salary > filter.SalaryMax)
                    return null;

                // Проверка по Минимальной дате
                if (filter.BirthdayMin != null && Birthday < filter.BirthdayMin)
                    return null;

                // Проверка по Максимальной дате
                if (filter.BirthdayMax != null && Birthday > filter.BirthdayMax)
                    return null;
                
                return this;
            }

            // Вывод работника
            public override string ToString() {
            /*
                Возвращаемые значения:
                    информация об одном работнике
            */  
                return String.Format(
                                        "ФИО:           {0}\n " +
                                        "Дата рождения: {1:dd.MM.yyyy}\n " +
                                        "Должность:     {2}\n " +
                                        "Зарплата:      {3}\n", 
                                         Name, Birthday, Post, Salary
                                     );
            }

            // Вывод отфильтрованного списка
            public void PrintWithFilter(List<Worker> Workers, Filter filter) {
            /*
                Входные параметры:
                    Workers - список работников
                    filter - фильтр
            */            
                foreach (Worker i in Workers) {
                    Console.WriteLine(i.ApplyFilter(filter));
                }
                Console.ReadLine();
            }

            // Вывод полного списка
            public void PrintAll(List<Worker> Workers) {
            /*
                Входные параметры:
                    Workers - список работников                    
            */                
                foreach (Worker i in Workers) {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
        }

        //  Фильтр
        struct Filter {
            public string NameSubstr;       // Фильтр для поля ФИО
            public string PostSubstr;       // Фильтр для поля Должность
            public int? SalaryMin;          // Мин Фильтр для поля Зарплата
            public int? SalaryMax;          // Макс Фильтр для поля Зарплата
            public DateTime? BirthdayMin;   // Мин Фильтр для поля День рождения
            public DateTime? BirthdayMax;   // Макс Фильтр для поля День рождения

            //  Установка значений фильтра 
            public void FillFromConsole() {
                // ФИО
                Console.Write("ФИО: ");
                NameSubstr = EnterString();

                // Должность
                Console.Write("Должность: ");
                PostSubstr = EnterString();

                // Минимальная зарплата
                Console.Write("Минимальная зарплата: ");
                SalaryMin = EnterInt("Неверный формат");

                // Максимальная зарплата
                Console.Write("Максимальная зарплата: ");
                SalaryMax = EnterInt("Неверный формат");

                // Минимальная дата
                Console.Write("Минимальная дата: ");
                BirthdayMin = EnterDateTime("Неверный формат");

                // Максимальная дата
                Console.Write("Максимальная дата: ");
                BirthdayMax = EnterDateTime("Неверный формат");
            }

            //  Ввод строки
            public static string EnterString() {
            /*
                Возвращаемые значения:
                    вводимая строка
                    null, при отсутствии значения
            */    
                string value = Console.ReadLine();
                if (value != string.Empty)
                    return value;
                return null;
            }

            // Ввод числового значения фильтра
            public static int? EnterInt(string reEnterText) {
            /*
                Входные параметры:
                    reEnterText - сообщение об ошибке
                Возвращаемые значения:
                    Числовое значение
                    null, при отсутствии значения
            */                
                while (true) {
                    // Проверка его наличия 
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

            // Ввод значения фильтра для даты
            public static DateTime? EnterDateTime(string reEnterText) {
            /*
                Входные параметры:
                    reEnterText - сообщение об ошибке
                Возвращаемые значения:
                    Дата
                    null, при отсутствии значения
            */           
                while (true) {
                    // Проверка его наличия
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