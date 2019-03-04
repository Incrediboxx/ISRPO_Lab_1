using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO {  
    class Worker {
        private String fullName ;   // ФИО
        private String post;        // Должность
        private int salary;         // Зарплата
        private DateTime birthday;  // День рождения

        public Worker(String fullName, String post, int salary, DateTime birthday) {
            this.fullName = fullName;
            this.post = post;
            this.salary = salary;
            this.birthday = birthday;
        }

        public DateTime getBirthday() {
            return birthday;
        }

        public override string ToString() {
            return String.Format("ФИО:           {0} \nДолжность:     {1} \nЗарплата:      {2} \nДата рождения: {3:dd.MM.yyyy}\n", fullName, post, salary, birthday);
        }


    }
}
