using System;
using System.Reflection;

namespace PropertyInfoCanReadDemo
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static int Main(string[] args)
        {
            //  Type typeS = Type.GetType("PropertyInfoCanReadDemo.Student");

            Mypropertya mypropertya = new Mypropertya();
            Mypropertyb mypropertyb = new Mypropertyb();

            Console.Write("\nMypropertya.Caption = " + mypropertya.Caption);

            Type MyTypea = Type.GetType("PropertyInfoCanReadDemo.Mypropertya");
            PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
            Type MyTypeb = Type.GetType("PropertyInfoCanReadDemo.Mypropertyb");
            PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("Caption");


            Console.Write("\nCanRead a - " + Mypropertyinfoa.CanRead);
            Console.WriteLine("\nCanRead b - " + Mypropertyinfob.CanRead);


            Student student = new Student() { Id = 1, Name = "mustafa" };
            Type typeStudent= Type.GetType("PropertyInfoCanReadDemo.Student");

            Console.WriteLine("*************************************************");
            foreach (var item in typeStudent.GetProperties())
            {
                Console.WriteLine($"{item.GetValue(student)}");
            }
            
            return 0;
        }
    }


    public class Mypropertya
    {
        private string caption = "A Default caption";
        public string Caption
        {
            get { return caption; }
            set
            {
                if (caption != value) { caption = value; }
            }
        }
    }
    public class Mypropertyb
    {
        private string caption = "B Default caption";
        public string Caption
        {
            set
            {
                if (caption != value)
                {
                    caption = value;
                }
            }
        }
    }

}
