using System;
using System.Collections.Generic;
using System.Globalization;



namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            // Список элементов структуры, заполняем значениями по умолчанию
            List<Worker> Workers = new List<Worker>();

            // Основной цикл меню
            while (true) {
                Console.WriteLine(" ---------------МЕНЮ---------------");
                Console.WriteLine(" Добавить.........................1");
                Console.WriteLine(" Отфильтрованный список...........2");
                Console.WriteLine(" Исходный список..................3");
                Console.WriteLine(" Настроить фильтр.................4");
                Console.WriteLine(" Выход............................0");
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));
                switch (n) {

                    case 1: // Добавление элемента в список
                            Console.Clear();
                            Worker Temp = new Worker();                 
                            Workers.Add(Temp.Push());
                            break;
                    
                    case 2: // Вывод отфильтрованного списка
                            /*Console.Clear();
                            // Применяем фильтр для копии списка, чтобы не испортить исходную последовательность
                            List<Worker> Copy = new List<Worker>(Workers);
                            Copy.Sort(new Filter());
                            // Вывод списка с помощью перегруженного метода ToString()
                            foreach (Worker i in Copy) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();*/
                            break;
                        
                    case 3: // Вывод исходного списка
                            Console.Clear();
                            // Вывод списка с помощью перегруженного метода ToString()
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                            break;
                    case 4:
                        Filter filter = new Filter();
                        filter.CreateFilter();
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

        struct Filter
        {
            private String Name;

            private String Post;

            private int MaxSalary;
            private int MinSalary;

            private DateTime MaxDate;
            private DateTime MinDate;

            public void CreateFilter()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(" ---------Настройки фильтра---------");
                    Console.WriteLine(" Имя...............................1");
                    Console.WriteLine(" День рождения.....................2");
                    Console.WriteLine(" Должность.........................3");
                    Console.WriteLine(" Зарплата..........................4");
                    Console.WriteLine(" Отмена............................0");
                    int n = 0;
                    do
                    {
                        Console.Write(" > ");
                    } while (!Int32.TryParse(Console.ReadLine(), out n));
                    switch (n)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write(" ФИО: ");
                            this.Name = Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine(" Максимальная дата...........1");
                            Console.WriteLine(" Минимальная дата............2");
                            Console.WriteLine(" Назад.......................0");
                            int dateSwitch = 0;
                            do
                            {
                                Console.Write(" > ");
                            } while (!Int32.TryParse(Console.ReadLine(), out dateSwitch));
                            switch (dateSwitch)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write(" Максимальная дата рождения (дд.ММ.гггг): ");
                                    } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out this.MaxDate));
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write(" Минимальная дата рождения (дд.ММ.гггг): ");
                                    } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out this.MinDate));
                                    break;

                                case 0:
                                    break;
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write(" Должность: ");
                            this.Post = Console.ReadLine();
                            break;


                        case 4:
                            Console.Clear();
                            Console.WriteLine(" Максимальная зарплата...........1");
                            Console.WriteLine(" Минимальная зарплата............2");
                            Console.WriteLine(" Назад...........................0");
                            int salarySwitch = 0;
                            do
                            {
                                Console.Write(" > ");
                            } while (!Int32.TryParse(Console.ReadLine(), out salarySwitch));
                            switch (salarySwitch)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write("Максимальная зарплата: ");
                                    } while (!Int32.TryParse(Console.ReadLine(), out this.MaxSalary));
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write("Минимальная заплата зарплата: ");
                                    } while (!Int32.TryParse(Console.ReadLine(), out this.MinSalary));
                                    break;

                                case 0:
                                    break;
                            }
                            break;

                        case 0:
                            return;

                        default:
                            return;
                    }
                }
            }
        }

        /*
        class Filter : IComparer<Worker> {
            // Перегруженный метод Compare для сравнения элементов, сравнение осуществляется по полю Birthday
            public int Compare(Worker a, Worker b) {
                if (a.getBirthday() > b.getBirthday())
                    return 1;
                else if (a.getBirthday() < b.getBirthday())
                    return -1;
                else
                    return 0;
            }
        }*/
    }
}
