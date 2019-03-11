using System.Collections.Generic;

namespace Lab_1_ISRPO {
    class DateComparer : IComparer<Worker> {
        /// <summary>
        /// Перегруженный метод Compare для сравнения элементов
        /// Сравнение осуществляется по полю Birthday
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> Результат сравнения </returns>
        public int Compare(Worker a, Worker b) {
            if (a.getBirthday() > b.getBirthday())
                return 1;
            else if (a.getBirthday() < b.getBirthday())
                return -1;
            else
                return 0;
        }
    }
}
