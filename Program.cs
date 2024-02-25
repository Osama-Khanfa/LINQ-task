using System;
using System.Collections.Generic;

class Student : IComparable<Student>
{
    public string Name;
    public int Age;
    public int CompareTo(Student other)
    {
        return string.Compare(Name, other.Name);
    }
}

class Program
{


    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        string[] names = { "Osama", "Mohammad", "Laith", "Omar", "Ayman", "Tareq", "Alaa", "Abdullah", "Samer" };
        Random random = new Random();

        for(int i=0; i < names.Length; i++)
        {
            Student student = new Student();
            student.Name = names[i];
            student.Age = random.Next(6, 25);
            students.Add(student);

        }

        Console.WriteLine("Display the list of students sorted by their names in ascending order.");
        List<Student> ascendingOrder =
            (from student in students
             orderby student ascending
             select student).ToList();

        foreach (Student s in ascendingOrder){
            Console.WriteLine("Name: {0}, Age: {1}", s.Name, s.Age);

        }
        Console.WriteLine("______________________________________________________________________\n");

        Console.WriteLine("Display the names of students who are older than 20 years.");
        List<Student> greaterThan20 =
            (from student in students
             where student.Age > 20
             select student).ToList();

        foreach (Student s in greaterThan20)
        {
            Console.WriteLine("Name: {0}, Age: {1}", s.Name, s.Age);

        }
        Console.WriteLine("______________________________________________________________________\n");

        Console.WriteLine("Calculate the average age of all students");
        double avg =
            (from student in students
             select student.Age).Average();
        Console.WriteLine("The average age is: {0}", avg);

    }
}
