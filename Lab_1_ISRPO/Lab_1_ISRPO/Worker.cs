using System;

namespace Lab_1_ISRPO {  
    struct Worker {
        private String Name ;       // ФИО
        private DateTime Birthday;  // День рождения
        private String Post;        // Должность
        private int Salary;         // Зарплата
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Birthday"></param>
        /// <param name="Post"></param>
        /// <param name="Salary"></param>
        public Worker(String Name, DateTime Birthday, String Post, int Salary) {
            this.Name = Name;
            this.Birthday = Birthday;
            this.Post = Post;
            this.Salary = Salary;
        }

        /// <summary>
        /// Получаем ФИО рабочего (для сравнения)
        /// </summary>
        /// <returns> ФИО </returns>
        public String getName() {
            return Name;
        }

        /// <summary>
        /// Получаем дату рождения рабочего (для сравнения)
        /// </summary>
        /// <returns> Дата рождения </returns>
        public DateTime getBirthday() {
            return Birthday;
        }

        /// <summary>
        /// Получаем должность рабочего (для сравнения)
        /// </summary>
        /// <returns> Должность </returns>
        public String getPost() {
            return Post;
        }

        /// <summary>
        /// Получаем зарплату рабочего
        /// </summary>
        /// <returns> Зарплата </returns>
        public int getSalary() {
            return Salary;
        }

        /// <summary>
        /// Перегруженный метод ToString() для данной структуры
        /// </summary>
        /// <returns>Данные в строковом формате</returns>
        public override string ToString() {
            return String.Format(" ФИО:           {0}\n Дата рождения: {1:dd.MM.yyyy}\n Должность:     {2}\n Зарплата:      {3}\n", Name, Birthday, Post, Salary);
        }
    }
}
