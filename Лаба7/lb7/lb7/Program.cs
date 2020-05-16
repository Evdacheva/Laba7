using System;
using System.IO;

namespace laba7_2
{
    class Program
    {

        struct Time
        {
            public DateTime dateTime;
            //public int comparison;
            //public int permutation;
            public TimeSpan timeSpan;

            public Time(DateTime d, TimeSpan t)
            {
                dateTime = d;
                timeSpan = t;
            }
        }


        public static void Main(string[] args)
        {
            string path = @"H:\Лаба7\lb7\sorted.dat";
            int[] array = new int[1000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 30);
            }

            int[] array_ascending = FastSort(array);
            int[] array_descending = new int[array.Length];
            for (int i = array.Length - 1; i > -1; i--)
            {
                array_descending[i] = array_ascending[i];
            }

            using (StreamWriter text = new StreamWriter(path, false))
            {
                Console.WriteLine("Сортировка - выборкой (по возрастанию)");
                foreach (int selection in SelectionSort(array))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - выборкой (отсортированного массива по возрастанию)");
                foreach (int selection in SelectionSort(array_ascending))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - выборкой (отсортированного массива по убыванию)");
                foreach (int selection in SelectionSort(array_descending))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - вставкой");
                foreach (int insert in InsertSort(array))
                {
                    text.Write(insert + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - вставкой (отсортированного массива по возрастанию)");
                foreach (int insert in InsertSort(array_ascending))
                {
                    text.Write(insert + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - вставкой (отсортированного массива по убыванию)");
                foreach (int insert in InsertSort(array_descending))
                {
                    text.Write(insert + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Пузырьковая соритировка");
                foreach (int bubble in BubbleSort(array))
                {
                    text.Write(bubble + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Пузырьковая соритировка (отсортированного массива по возрастанию)");
                foreach (int bubble in BubbleSort(array_ascending))
                {
                    text.Write(bubble + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Пузырьковая соритировка (отсортированного массива по убыванию)");
                foreach (int bubble in BubbleSort(array_descending))
                {
                    text.Write(bubble + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шейкера");
                foreach (int shaker in ShakerSort(array))
                {
                    text.Write(shaker + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шейкера (отсортированного массива по возрастанию)");
                foreach (int shaker in ShakerSort(array_ascending))
                {
                    text.Write(shaker + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шейкера (отсортированного массива по убыванию)");
                foreach (int shaker in ShakerSort(array_descending))
                {
                    text.Write(shaker + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шелла");
                foreach (int shell in ShellSort(array))
                {
                    text.Write(shell + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шелла (отсортированного массива по возрастанию)");
                foreach (int shell in ShellSort(array_ascending))
                {
                    text.Write(shell + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Соритировка Шелла (по убыванию)");
                foreach (int shell in ShellSort(array_descending))
                {
                    text.Write(shell + " ");
                }
            }
            Check(path);
            Console.ReadKey();
        }

        static int[] FastSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i;
                while (j > 0 && temp > array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
            return array;
        }
        //______________________________________________________________________________________________________________________________________
        static int[] SelectionSort(int[] array)
        {
            DateTime start = DateTime.Now;
            int cnt = 0;
            int swap = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++, cnt++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
                swap++;
            }
            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, cnt, swap);
            return array;
        }

        //_________________________________________________________________________________________________________________________________________

        static int[] InsertSort(int[] array)
        {
            DateTime start = DateTime.Now;
            int cnt = 0;
            int swap = 0;
            for (int i = 1; i < array.Length; i++, cnt++)
            {
                int temp = array[i];
                int j = i;
                while (j > 0 && temp < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
                swap++;
            }
            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, cnt, swap);
            return array;
        }

        //____________________________________________________________________________________________________________________________________________

        static int[] BubbleSort(int[] array)
        {
            DateTime start = DateTime.Now;
            int cnt = 0;
            int swap = 0;
            for (int i = 0; i < array.Length - 1; i++, swap++)
            {
                for (int j = i + 1; j < array.Length - i - 1; j++, cnt++)
                {
                    if (array[j] > array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, cnt, swap);
            return array;


        }
        //________________________________________________________________________________________________________________________________________________


        //________________________________________________________________________________________________________________________________________
        static int[] ShakerSort(int[] array)
        {
            DateTime start = DateTime.Now;
            int cnt = 0;
            int swap = 0;
            int left = 1;
            int right = array.Length - 1;
            while (left <= right)
            {
                for (int i = right; i >= left; i--, cnt++)
                {
                    if (array[i - 1] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }

                }
                swap++;
                left++;
                for (int i = left; i <= right; i++, cnt++)
                {
                    if (array[i - 1] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                swap++;
                right--;
            }

            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, cnt, swap);
            return array;

        }
        //_______________________________________________________________________________________________________________________________________________

        static int[] ShellSort(int[] array)
        {
            DateTime start = DateTime.Now;
            int cnt = 0;
            int swap = 0;
            int s = array.Length;

            foreach (int step in array)
            {
                int i, j;
                for (i = step; i < array.Length; i++, cnt++)
                {
                    j = i;
                    int tmp = array[i];
                    while (j >= step && tmp < array[j - step])
                    {
                        array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = tmp;
                    swap++;
                }


            }
            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, cnt, swap);
            return array;
        }
        //____________________________________________________________________________________________________________________________________

        static void Check(string path)
        {

            using (StreamReader textReader = new StreamReader(path))
            {
                bool data_checking = true;
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    line = textReader.ReadLine();
                    if (line != null)
                    {
                        string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < nums.Length - 1; i++)
                        {
                            if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[i++]))
                            {
                                data_checking = false;
                                break;
                            }
                        }
                    }

                }
                if (data_checking)
                {
                    Console.WriteLine("Сортировка всех функций прошла успешно");
                }
                else
                {
                    Console.WriteLine("Сортировка прошланеудачно");
                }

            }


        }
    }
}
