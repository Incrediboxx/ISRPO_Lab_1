using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            // Список элементов структуры
            List<Worker> Workers = new List<Worker>();
            // Добавляем значения по умолчанию
            Workers.Add(new Worker("Иванов Иван Иванович", new DateTime(1990, 01, 12), "Директор", 25000));
            Workers.Add(new Worker("Петров Петр Петрович", new DateTime(1990, 02, 12), "Менеджер", 25000));
            Workers.Add(new Worker("Сидоров Михаил Михайлович", new DateTime(1990, 01, 10), "Рабочий", 25000));

            while (true) {
                Console.WriteLine(" ---------------МЕНЮ---------------");
                Console.WriteLine(" Добавить.........................1");
                Console.WriteLine(" Фильтр...........................2");
                Console.WriteLine(" Весь список......................3");
                Console.WriteLine(" Выход............................0");
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));
                switch (n) {
                    // Добавление элемента в список
                    case 1: {
                            // Очищаем консоль
                            Console.Clear();
                            // Вводим ФИО
                            Console.Write(" ФИО: ");
                            String Name = Console.ReadLine();
                            // Вводим дату рождения
                            DateTime Birthday;
                            do {
                                Console.Write(" Дата рождения (дд.ММ.гггг): ");
                            } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out Birthday));
                            // Вводим должность
                            Console.Write(" Должность: ");
                            String Post = Console.ReadLine();
                            // Вводим зарплату
                            int Salary = 0;
                            do {
                                Console.Write(" Зарплата: ");
                            } while (!Int32.TryParse(Console.ReadLine(), out Salary));

                            Workers.Add(new Worker(Name, Birthday, Post, Salary));
                        } break;
                    // Отфильтрованный список
                    case 2: {
                            // Очищаем консоль
                            Console.Clear();
                            Workers.Sort(new DateComparer());
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i);
                                break;
                            }
                            Console.ReadLine();
                        } break;
                    // Вывод всего списка
                    case 3: {
                            // Очищаем консоль
                            Console.Clear();
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                        }
                        break;
                    // Выход из программы
                    case 0: return;
                    // Значение по умолчания, для незарезервированных вариантов
                    default: break;
                }
                // Очищаем консоль
                Console.Clear();
            }
        }
    }
}
