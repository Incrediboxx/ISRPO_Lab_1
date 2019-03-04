using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO {
    class Lab_1 {
        static void Main(string[] args) {
            Worker Ivanov = new Worker("Иванов Иван Иванович", "Директор", 25000, new DateTime(1990, 01, 12));
            Worker Petrov = new Worker("Петров Петр Петрович", "Менеджер", 25000, new DateTime(1990, 02, 12));
            Worker Sidorov = new Worker("Сидоров Михаил Михайлович", "Рабочий", 25000, new DateTime(1990, 01, 10));

            Worker[] Workers = new Worker[] { Ivanov, Petrov, Sidorov };
            Array.Sort(Workers, new DateComparer());
            foreach (Worker i in Workers) {
                Console.WriteLine(i);
                break;
            }
            Console.ReadLine();
        }
    }
}
