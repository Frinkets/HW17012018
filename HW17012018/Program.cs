using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17012018
{
    class Program
    {
        private string _connectionString = @"Initial Catalog=AFStudio;Data Source=AF-PC\SQLEXPRESS;Integrated Security=SSPI;";
        static Model1 db = new Model1();
        static void Main(string[] args)
        {
           
           
        }
   
        public void task1()
        {
            //Использовать цепочку состоящую не менее из 3 операторов. 
            //Выгрузить данные где TypeArea = 1, произвести сортировку данных 
            //от большего к меньшим и вывести на экран следующие данные – Name, FullName, IP

            var task1 = db.Area
                .Where(w=>w.TypeArea == 1)
                .OrderBy(w => w.Name)
                .OrderBy(w=>w.FullName)
                .OrderBy(w => w.IP)
                .Select(s => new
                {
                    s.Name,
                    s.FullName, 
                    s.IP
                });

        }
        public void task2()
        {
            //Используя синтаксис облегчающий восприятия выгрузить следующие данные:
            //для ParentId = 0, отобразить на экран следующие данные – Name, FullName, IP.
            //При этом необходимо использовать отложенную выгрузку данных.


            var task2 =
                 from ts in db.Area
                 where ts.ParentId == 0
                 select new
                 {
                     ts.Name,
                     ts.FullName,
                     ts.IP
                 };
                
                
        }
        public void task3()
        {
            //Создать массив целых чисел «Pavilion» от 1 до 6.
            //Произвести выгрузку данных из таблицы создав подзапрос.
            //В подзапросе необходимо выбрать из массива «Pavilion» только 2, 4, 6.
            //Затем вывести на экран следующие данные – PavilionId, Name, FullName, IP

            int[] Pavilion = new int[6] { 1, 2, 3, 4, 5, 6 };

            //var task3 =
            //    from ts in db.Area
            //    .Where(w => w.PavilionId != 0)
            //    .Select(s => new
            //    {
            //        //ts1 = from t in db.Area

            //        //      select new
            //        //      {
            //        //          //Pavilion.Skip(1).Take(1),
            //        //          //Pavilion.Skip(1).Take(1).Skip(1).Take(1),
            //        //          //Pavilion.Skip(1).Take(1).Skip(1).Take(1).Skip(1).Take(1),

            //        //          t.PavilionId,
            //        //          t.Name,
            //        //          t.FullName,
            //        //          t.IP
            //        //      },
            //    });
         

        }
        public void task4()
        {
        //Cоздать запрос с использованием ключевого слова «let»,
            //и выгрузить данные только где столбец «WorkingPeople» > 1.

            var task4 =
                from w in db.Area
                let w1 = w.WorkingPeople > 1
                select w1;
        }
        public void task5()
        {
            //Создать запрос с использованием ключевого слова «into»,  
            //где в первом запросе должны вывестись следующие данные: 
            //ParentId, FullName, ParentId, Dependence, 
            //далее во втором запросе отобразить только те зоны у которых Dependence > 0.

            var task5 =
                from w in db.Area
                select new
                {
                    w.ParentId,
                    w.FullName,
                    w.Dependence
                } into w1

                where w1.Dependence > 0
                select w1; 
        }
    }
}
