﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO
{
    class Worker
    {
        String fullName ; //ФИО
        String post; //должность
        int salary; //зарплата
        DateTime birthday; //день рождения

        Worker(String fullName,String post,int salary,DateTime birthday)
        {
            this.fullName = fullName;
            this.post = post;
            this.salary = salary;
            this.birthday = birthday;
        }

        public void ShowInfo()
        {
            Console.WriteLine("ФИО:           " + fullName);
            Console.WriteLine("Должность:     " + post);
            Console.WriteLine("Зарплатала:    " + salary);
            Console.WriteLine("День рождения: " + salary);
        }
        DateTime getBirthday()
        {
            return this.birthday;
        }
        public void MostYoung(List<Worker> workers)
        {
            Worker buff = new Worker("", "", 0, workers[0].getBirthday());
            for (int i = 1; i < workers.Count(); i++) 
            {
                if (workers[i].getBirthday() > buff.getBirthday)
            }
        }


    }
}