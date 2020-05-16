using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;



namespace laba5
{
    class Program
    {
        public enum type { F, U }
        struct table
        {
            public string country;
            public string capital;
            public int strength;
            public type form_of_goverment;
            public void DisplayInfo()
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}", country, capital, strength, form_of_goverment);
            }
        }
        struct log
        {
            public DateTime time;
            public string operation;
            public string name;

            public void DisplayLog()
            {
                Console.WriteLine("{0,-20} - {1,-15} {2,-30}", time, operation, name);
            }
        }


        static void Main(string[] args)
        {
            table Australia;
            Australia.country = "Австралия";
            Australia.capital = "Канберра";
            Australia.strength = 23130391;
            Australia.form_of_goverment = type.F;

            table Austria;
            Austria.country = "Австрия";
            Austria.capital = "Вена";
            Austria.strength = 8420010;
            Austria.form_of_goverment = type.F;

            table Italy;
            Italy.country = "Италия";
            Italy.capital = "Рим";
            Italy.strength = 61482020;
            Italy.form_of_goverment = type.U;

            table[] tableArray = new table[50];

            tableArray[0] = Australia;
            tableArray[1] = Austria;
            tableArray[2] = Italy;

            log[] logs = new log[50];
            DateTime time = DateTime.Now;
            DateTime time1 = DateTime.Now;
            TimeSpan span = time1 - time;
            bool error = true;
            int tableArray_log = 0;
            int cnt = 3;
            while (error)
            {
                try
                {

                    do
                    {
                        Console.WriteLine("1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход \n8 - Сортировка ");
                        int menu = Convert.ToInt32(Console.ReadLine());
                        if (menu == 1)
                        {
                            for (int i = 0; i < cnt; i++)
                            {
                                tableArray[i].DisplayInfo();
                            }


                        }
                        else if (menu == 2)
                        {
                            bool capital_lengh = true;
                            bool strength_quantity = true;
                            bool form_lengh = true;

                            Console.WriteLine("Введите страну");
                            string country = Console.ReadLine();
                            string capital = "";
                            int strength = 0;
                            var form_of_goverment = type.F;
                            do
                            {
                                Console.WriteLine("Введите столицу");
                                capital = Console.ReadLine();
                                {
                                    if (capital.Length <= 20)
                                    {
                                        capital_lengh = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Повторить");
                                    }
                                }
                            }
                            while (capital_lengh);
                            do
                            {
                                Console.WriteLine("Введите численность населения");
                                strength = Convert.ToInt32(Console.ReadLine());
                                if (strength < 1000000)
                                {
                                    strength_quantity = false;
                                }
                                else
                                {
                                    Console.WriteLine("Повторить");
                                }
                            }
                            while (strength_quantity);
                            do
                            {
                                Console.WriteLine("Введите тип государства: Ф или УГ");
                                string form_of_goverment1 = Console.ReadLine();
                                if (form_of_goverment1 == "Ф" || form_of_goverment1 == "Ф")
                                {
                                    form_of_goverment = type.F;
                                    form_lengh = false;
                                }
                                else if (form_of_goverment1 == "УГ" || form_of_goverment1 == "УГ")

                                {
                                    form_of_goverment = type.U;
                                    form_lengh = false;
                                }
                                else
                                {
                                    Console.WriteLine("Повторить");
                                }
                            }
                            while (form_lengh);
                            table new_line;
                            new_line.country = country;
                            new_line.capital = capital;
                            new_line.strength = strength;
                            new_line.form_of_goverment = form_of_goverment;

                            tableArray[cnt++] = new_line;

                            log ADD;
                            ADD.time = DateTime.Now;
                            ADD.operation = "Добавлена запись";
                            ADD.name = country;
                            logs[tableArray_log++] = ADD;


                            time1 = DateTime.Now;
                            TimeSpan span1 = time - time1;
                            if (span < span1)
                            {
                                span = span1;
                            }
                            time1 = ADD.time;
                        }
                        else if (menu == 3)
                        {
                            Console.WriteLine("Введите номер строки, которую нужно удалить");
                            int delete = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < tableArray_log; i++)
                            {
                                tableArray[delete - 1 + i] = tableArray[delete + 1];
                            }
                            log DELETE;
                            DELETE.time = DateTime.Now;
                            DELETE.operation = "Удалена строка";
                            DELETE.name = tableArray[delete].country;

                            logs[tableArray_log++] = DELETE;
                            cnt--;
                        }
                        else if (menu == 4)
                        {
                            bool capital_lengh = true;
                            bool strength_quantity = true;
                            bool form_lengh = true;


                            string country = "";
                            string capital = "";
                            int strength = 0;
                            var form_of_goverment = type.F;

                            Console.WriteLine("Введите номер записи для редактирования");
                            int delete_number = 0;
                            bool errorNumb = false;
                            do
                            {
                                delete_number = Convert.ToInt32(Console.ReadLine());
                                if (delete_number < tableArray.Length || delete_number > 0)
                                {

                                    errorNumb = false;
                                }

                                else
                                {
                                    Console.WriteLine("Введите верный индекс строки");
                                    errorNumb = true;
                                }

                            }
                            while (errorNumb);
                            Console.WriteLine("Введите страну");
                            string oldcountry = tableArray[delete_number - 1].country;
                            country = Console.ReadLine();
                            capital = "";
                            strength = 0;
                            form_of_goverment = type.F;
                            do
                            {
                                Console.WriteLine("Введите столицу");
                                capital = Console.ReadLine();
                                if (capital.Length <= 20)
                                {
                                    capital_lengh = false;
                                }
                                else
                                {
                                    Console.WriteLine("Повторить");
                                }
                            }
                            while (capital_lengh);
                            do
                            {
                                Console.WriteLine("Введите численность населения");
                                strength = Convert.ToInt32(Console.ReadLine());
                                if (strength < 1000000)
                                {
                                    strength_quantity = false;
                                }
                                else
                                {
                                    Console.WriteLine("Повторить");
                                }
                            }
                            while (strength_quantity);

                            /*for (int i = 0; i < tableArray.Length - 1; i++)
                            {
                                tableArray[delete_number - 1 + i] = tableArray[delete_number + 1];
                            }*/
                            do
                            {
                                Console.WriteLine("Введите тип государства: Ф или УГ");
                                string form_of_goverment1 = Console.ReadLine();
                                if (form_of_goverment1 == "Ф")
                                {
                                    form_of_goverment = type.F;
                                    form_lengh = false;
                                }
                                else if (form_of_goverment1 == "УГ")

                                {
                                    form_of_goverment = type.U;
                                    form_lengh = false;
                                }
                                else
                                {
                                    Console.WriteLine("Повторить");
                                }
                            }
                            while (form_lengh);
                            table new_line2;
                            new_line2.country = country;
                            new_line2.capital = capital;
                            new_line2.strength = strength;
                            new_line2.form_of_goverment = form_of_goverment;
                            tableArray[delete_number - 1] = new_line2;

                            log UPDATE;
                            UPDATE.time = DateTime.Now;
                            UPDATE.operation = "Запись обновлена";
                            UPDATE.name = oldcountry;
                            time1 = DateTime.Now;
                            TimeSpan span1 = time - time1;
                            if (span < span1)
                            {
                                span = span1;
                            }
                            time1 = UPDATE.time;
                            logs[tableArray_log++] = UPDATE;

                        }
                        else if (menu == 5)
                        {
                            Console.WriteLine("Поиск по строю страны");
                            Console.WriteLine("1 - Ф\n2 - УГ");
                            bool stroy_ex = true;
                            while (stroy_ex)
                            {
                                int choice = Convert.ToInt32(Console.ReadLine());

                                if (choice == 1)
                                {
                                    for (int i = 0; i < cnt; i++)
                                    {
                                        if (tableArray[i].form_of_goverment == type.F)
                                        {
                                            tableArray[i].DisplayInfo();
                                        }
                                    }
                                    stroy_ex = false;

                                }

                                else if (choice == 2)
                                {
                                    for (int i = 0; i < cnt; i++)
                                    {
                                        if (tableArray[i].form_of_goverment == type.U)
                                        {
                                            tableArray[i].DisplayInfo();

                                        }
                                    }
                                    stroy_ex = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите корректное число");
                                }
                            }
                        }
                        else if (menu == 6)
                        {
                            for (int i = 0; i < tableArray_log; i++)
                            {
                                logs[i].DisplayLog();
                            }
                            Console.WriteLine();
                            Console.WriteLine(span + " - Самый долгий период бездействия пользователя");
                        }
                        else if (menu == 7)
                        {
                            error = false;
                            break;
                        }
                        else if (menu == 8)
                        {
                            int temp;
                            for (int i = 0; i < tableArray.Length - 1; i++)
                            {
                                for (int j = i + 1; j < tableArray.Length; j++)
                                {
                                    if (tableArray[i].strength > tableArray[j].strength)
                                    {
                                        temp = tableArray[i].strength;
                                        tableArray[i].strength = tableArray[j].strength;
                                        tableArray[j].strength = temp;

                                    }
                                }
                            }
                            Console.WriteLine("________");
                            for (int i = 0; i < tableArray.Length; i++)
                            {
                                Console.WriteLine(tableArray[i].strength);
                            }
                            Console.ReadLine();
                           
                        }

                        else if (menu > 8)
                        {
                            Console.WriteLine("Введите верную строку");
                            error = true;
                            break;
                        }
                    } while (error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}


