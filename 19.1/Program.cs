using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._1
{
    class Student
    {

        int ID;
        string Name;
        string Papaname;
        string Surname;

        public Student(int id, string name, string papa, string surn)
        {
            ID = id;
            Name = name;
            Papaname = papa;
            Surname = surn;
        }
        public int idd
        {
            get { return ID; }
            set { }
        }
        public string NAME
        {
            get { return Name; }
            set { }
        }
        public string PAPA
        {
            get { return Papaname; }
            set { }
        }
        public string SURN
        {
            get { return Surname; }
            set { }
        }
    }
    class Mark
    {
        int IDStudi;
        int mark;
        string Obj;
        string Data;
        public Mark(int idstud, int marke, string obj, string data)
        {
            IDStudi = idstud;
            mark = marke;
            Obj = obj;
            Data = data;
        }
        public int iddstud
        {
            get { return IDStudi; }
            set { }
        }
        public int Marks
        {
            get { return mark; }
            set { }
        }
        public string Objs
        {
            get { return Obj; }
            set { }
        }
        public string Datas
        {
            get { return Data; }
            set { }
        }
    }

    class MarkList
    {
       public Student[] studmas;
       public Mark[] markmas;
        public MarkList(int n)
        {
            studmas = new Student[n];
            markmas = new Mark[0];
        }
        public MarkList(Student[] s)
        { studmas = s; }
        public MarkList(Mark[] m)
        { markmas=m;}

        public void DobavMark()
        {
            Console.WriteLine("vvedite ID studenta: ");

            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("vvedite subj studenta: ");

            string c = Console.ReadLine() ; 

            Console.WriteLine("vvedite mark studenta: ");
            
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("vvedite data ");

            string d = Console.ReadLine();

            Mark m = new Mark(a, b, c, d);

            Mark[] temp = new Mark[markmas.Length + 1];

            for (int i = 0; i < temp.Length - 1; i++)
            {
                temp[i] = markmas[i];
            }
            temp[temp.Length - 1] = m;
            markmas = temp;
        }
    }


        class Analistic
        {
            Student[] students;
            Mark[] mark;
            public Analistic(Student[] s, Mark[] m)
            {
                students = s;
                mark = m;
            }
            public Analistic(MarkList m)
            {
                students = m.studmas;
                mark = m.markmas;
            }
            public void fun(string subject) 
            { 
                var t = from x in students
                        join y in mark
                        on x.idd equals y.iddstud
                        where y.Objs== subject
                        select  new{Id=x.idd,F=x.NAME};
                foreach(var i in t)
                {
                    Console.WriteLine(i.Id + " " + i.F);
                }
            }
            public void fun2(string subject){
      
                var t = from x in students
                        join y in mark
                        on x.idd equals y.iddstud
                        where y.Objs== subject
                        where y.Marks>=90

                        select  new{Id=x.idd,F=x.NAME};
                foreach(var i in t)
                {
                    Console.WriteLine(i.Id + " " + i.F);
                }
            }
            public void fun3(string subject)
            {

                var t = from x in students
                        join y in mark
                        on x.idd equals y.iddstud
                        where y.Objs == subject
                        where y.Marks <= 60
                        select new { Id = x.idd, F = x.NAME };
                foreach (var i in t)
                {
                    Console.WriteLine(i.Id + " " + i.F);
                }
            }
            public void fun4()
            {
                var t = from x in students
                              orderby x.NAME, x.PAPA, x.SURN
                              select x;
                foreach (var i in t)
                {
                    Console.WriteLine(i.NAME + " " + i.PAPA+" "+i.SURN);
                }
            }
          


        }

    
    class Progpam
    {
        static void Main()
        {
            Console.WriteLine("Введите количество студентов которых хотите добавить в таблицу:");
            int n = Convert.ToInt32(Console.ReadLine());

            Student[] mass = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите номер зачетки:");
                int nomer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите Имя:");
                string imya = Console.ReadLine();
                Console.WriteLine("Введите отчество:"); 
                string otchestvo = Console.ReadLine();
                Console.WriteLine("Введите фамилию:");
                string fam = Console.ReadLine();
                mass[i] = new Student(nomer, imya, otchestvo, fam);
            }
            MarkList sessiya1 = new MarkList(mass);

            //for (int i = 0; i < n; i++)
            //{
            //    sessiya1.DobavMark();
            //}

            Analistic s = new Analistic(sessiya1);
            Console.WriteLine("Введите предмет:");
            string sub = Console.ReadLine();
            s.fun(sub);
            Console.WriteLine("студенты получившие \"отлично\" по предмету "+sub);
            s.fun2(sub);
            Console.WriteLine("студенты получившие \"два\" по предмету " + sub);
            s.fun3(sub);
            s.fun4();
            Console.ReadKey();
        }
    }

}