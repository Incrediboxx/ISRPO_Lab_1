using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO {  
    struct Worker {
        private String Name ;       // ФИО
        private DateTime Birthday;  // День рождения
        private String Post;        // Должность
        private int Salary;         // Зарплата
        

        public Worker(String Name, DateTime Birthday, String Post, int Salary) {
            this.Name = Name;
            this.Birthday = Birthday;
            this.Post = Post;
            this.Salary = Salary;
        }

        public DateTime getBirthday() {
            return Birthday;
        }

        public override string ToString() {
            return String.Format(" ФИО:           {0}\n Дата рождения: {1:dd.MM.yyyy}\n Должность:     {2}\n Зарплата:      {3}\n", Name, Birthday, Post, Salary);
        }
    }
}
