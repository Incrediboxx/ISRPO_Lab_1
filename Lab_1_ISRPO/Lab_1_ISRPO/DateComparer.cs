using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO {
    class DateComparer : IComparer<Worker> {
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
