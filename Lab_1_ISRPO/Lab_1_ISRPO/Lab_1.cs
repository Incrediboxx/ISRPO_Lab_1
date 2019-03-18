using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            // Список элементов структуры, заполняем значениями по умолчанию
            List<Worker> Workers = new List<Worker>();
            Filter filter = new Filter();

            
            while (true) {//Вывод главного меню
                Console.WriteLine(" ---------------МЕНЮ---------------");
                Console.WriteLine(" Добавить.........................1");
                Console.WriteLine(" Отфильтрованный список...........2");
                Console.WriteLine(" Исходный список..................3");
                Console.WriteLine(" Установить фильтр................4");
                Console.WriteLine(" Выход............................0");
                int n = 0;
                //Выбор действия
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));

                switch (n) { //Выполение выбранного действия

                    case 1: // Добавление элемента в список
                            Console.Clear();
                            Worker Temp = new Worker();                 
                            Workers.Add(Temp.Push());
                            break;
                    
                    case 2: // Вывод отфильтрованного списка
                            Console.Clear();
                            foreach (Worker i in Workers.Where(w => filter.UseFilter(w)))
                            {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                            break;
                        
                    case 3: // Вывод исходного списка
                            Console.Clear();
                            // Вывод списка с помощью переопределённого метода ToString()
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

                    default: // Значение по умолчания, для незарезервированных вариантов
                            break;
                }
                Console.Clear();
            }
        }

        struct Worker {
            private String Name ;       // ФИО
            private DateTime Birthday;  // День рождения
            private String Post;        // Должность
            private int Salary;         // Зарплата

            public Worker Push() {
                // Вводим ФИО
                Console.Write(" ФИО: ");
                this.Name = Console.ReadLine();
                // Вводим дату рождения, проверяем вводимые данные на их корректность
                do {
                    Console.Write(" Дата рождения (дд.ММ.гггг): ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out this.Birthday));
                // Вводим должность
                Console.Write(" Должность: ");
                this.Post = Console.ReadLine();
                // Вводим зарплату, проверяем вводимые данные на их корректность
                do {
                    Console.Write(" Зарплата: ");
                } while (!Int32.TryParse(Console.ReadLine(), out this.Salary));
                return this;
            }

            // Получаем ФИО рабочего (для сравнения)
            public String getName() {
                return Name;
            }

            // Получаем дату рождения рабочего (для сравнения)
            public DateTime getBirthday() {
                return Birthday;
            }

            // Получаем должность рабочего (для сравнения)
            public String getPost() {
                return Post;
            }

            // Получаем зарплату рабочего
            public int getSalary() {
                return Salary;
            }

            // Перегруженный метод ToString() для данной структуры
            public override string ToString() {
                return String.Format(" ФИО:           {0}\n Дата рождения: {1:dd.MM.yyyy}\n Должность:     {2}\n Зарплата:      {3}\n", Name, Birthday, Post, Salary);
            }
        }

        // Структура Фильтр
        struct Filter
        {
            private string NameSubstr;  // Значение фильтра ФИО
            private string PostSubstr;  // Значение фильтра Должность
            private int? SalaryLower;   // Нижнее значение фильтра Зарплата
            private int? SalaryUpper;   // Верхнее значение фильтра Зарплата
            private DateTime? BirthdayLower; // Нижнее значение фильтра День рождения
            private DateTime? BirthdayUpper; // Верхнее значение фильтра День рождения

            // Сравнение с фильтром, true - подходит, false - не подходит
            public bool UseFilter(Worker worker)
            {
                if (NameSubstr != null && !worker.getName().Contains(NameSubstr))
                    return false;
                if (PostSubstr != null && !worker.getPost().Contains(PostSubstr))
                    return false;
                if (SalaryLower != null && worker.getSalary() < SalaryLower)
                    return false;
                if (SalaryLower != null && worker.getSalary() > SalaryUpper)
                    return false;
                if (BirthdayLower != null && worker.getBirthday() < BirthdayLower)
                    return false;
                if (BirthdayUpper != null && worker.getBirthday() > BirthdayUpper)
                    return false;
                return true;
            }

            // Функция установки значений фильтра с консоли
            public void FiilFromConsole()
            {
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
            public static string EnterString()
            {
                string value = Console.ReadLine();
                if (value != string.Empty)
                    return value;
                return null;
            }

            // Функция для ввода опционального числа
            public static int? EnterInt(string reEnterText)
            {
                while (true)
                {
                    try
                    {
                        string value = Console.ReadLine();
                        if (value != string.Empty)
                            return int.Parse(value);
                        else return null;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(reEnterText);
                    }
                }
            }

            // Функция для ввода опциональной даты
            public static DateTime? EnterDateTime(string reEnterText)
            {
                while (true)
                {
                    try
                    {
                        string value = Console.ReadLine();
                        if (value != string.Empty)
                            return DateTime.Parse(value);
                        else return null;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(reEnterText);
                    }
                }
            }
        }
    }
}
