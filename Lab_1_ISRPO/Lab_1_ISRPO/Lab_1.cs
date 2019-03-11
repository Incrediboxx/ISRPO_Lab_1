using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            /// <summary>
            /// Список элементов структуры
            /// Заполняем значениями по умолчанию
            /// </summary>
            /// <param name="Workers"></param>
            List<Worker> Workers = new List<Worker>();
            Workers.Add(new Worker("Иванов Иван Иванович", new DateTime(1990, 01, 12), "Директор", 25000));
            Workers.Add(new Worker("Петров Петр Петрович", new DateTime(1990, 02, 12), "Менеджер", 25000));
            Workers.Add(new Worker("Сидоров Михаил Михайлович", new DateTime(1990, 01, 10), "Рабочий", 25000));
            /// <summary>
            /// Основной цикл меню
            /// </summary>
            while (true) {
                Console.WriteLine(" ---------------МЕНЮ---------------");
                Console.WriteLine(" Добавить.........................1");
                Console.WriteLine(" Отфильтрованный список...........2");
                Console.WriteLine(" Исходный список..................3");
                Console.WriteLine(" Выход............................0");
                int n = 0;
                do {
                    Console.Write(" > ");
                } while (!Int32.TryParse(Console.ReadLine(), out n));
                switch (n) {
                    /// <summary>
                    /// Добавление элемента в список
                    /// </summary>
                    case 1: {
                            /// <summary>
                            /// Очищаем консоль 
                            /// </summary>
                            Console.Clear();
                            /// <summary>
                            /// Вводим ФИО
                            /// </summary>
                            /// <param name="Name"></param>
                            Console.Write(" ФИО: ");
                            String Name = Console.ReadLine();
                            /// <summary>
                            /// Вводим дату рождения
                            /// Проверка вводимых данных на их корректность
                            /// </summary>
                            /// <param name="Birthday"></param>
                            DateTime Birthday;
                            do {
                                Console.Write(" Дата рождения (дд.ММ.гггг): ");
                            } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out Birthday));
                            /// <summary>
                            /// Вводим должность
                            /// </summary>
                            /// <param name="Post"></param>
                            Console.Write(" Должность: ");
                            String Post = Console.ReadLine();
                            /// <summary>
                            /// Вводим зарплату
                            /// Проверка вводимых данных на их корректность
                            /// </summary>
                            /// <param name="Salary"></param> 
                            int Salary = 0;
                            do {
                                Console.Write(" Зарплата: ");
                            } while (!Int32.TryParse(Console.ReadLine(), out Salary));
                            /// <summary>
                            /// Добавляем новый элемент в список
                            /// </summary>
                            Workers.Add(new Worker(Name, Birthday, Post, Salary));
                        } break;
                    /// <summary>
                    /// Вывод отфильтрованного списка
                    /// </summary>
                    case 2: {
                            /// <summary>
                            /// Очищаем консоль 
                            /// </summary>
                            Console.Clear();
                            /// <summary>
                            /// Применяем фильтр для копии списка
                            /// Чтобы не испортить входную последовательность
                            /// </summary>
                            List<Worker> Copy = new List<Worker>(Workers);
                            Copy.Sort(new DateComparer());
                            Copy.Sort(new Filter());
                            /// <summary>
                            /// Вывод списка с помощью перегруженного метода ToString()
                            /// </summary>
                            foreach (Worker i in Copy) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                        } break;
                    /// <summary>
                    /// Вывод исходного списка
                    /// </summary>
                    case 3: {
                            /// <summary>
                            /// Очищаем консоль 
                            /// </summary>
                            Console.Clear();
                            /// <summary>
                            /// Вывод списка с помощью перегруженного метода ToString()
                            /// </summary>
                            foreach (Worker i in Workers) {
                                Console.WriteLine(i);
                            }
                            Console.ReadLine();
                        }
                        break;
                    /// <summary>
                    /// Выход из программы
                    /// </summary>
                    case 0: return;
                    /// <summary>
                    /// Значение по умолчания, для незарезервированных вариантов
                    /// </summary>
                    default: break;
                }
                /// <summary>
                /// Очищаем консоль 
                /// </summary>
                Console.Clear();
            }
        }
    }
}
