using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class Person
    {
        public string Lastname { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime BtDate { get; set; }


        public Person() { }
        public Person(string lastname, double height, double weight, DateTime btdate)
        {
            Lastname = lastname;
            Height = height;
            Weight = weight;
            BtDate = btdate;
        }
        public Person( Person person)
        { 
            Lastname = person.Lastname;
            Height = person.Height;
            Weight = person.Weight;
            BtDate = person.BtDate;
        }


        public void Input()
        {
            Console.WriteLine("Введите данные о человеке: ");
            Console.WriteLine("Фамилия: ");
            Lastname = Console.ReadLine();
            Console.WriteLine("Рост(см)");
            Height = double.Parse(Console.ReadLine());
            Console.WriteLine("Вес(кг): ");
            Weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Дата рождения (дд.мм.гггг):");
            BtDate = DateTime.Parse(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine($"\nФамилия: {Lastname}\nРост: {Height} см\nВес: {Weight} кг\nДата рождения: {BtDate}");
        }

        public int FullAge()
        {
            DateTime HelpTime = new DateTime(1, 1, 1);
            TimeSpan span = DateTime.Now - BtDate;
            int age = (HelpTime + span).Year - 1;
            return age;
        }


    }
}
