using System;
using System.Collections.Generic;

class Student : IComparable<Student>
{
    public int ID;
    public string Name;
    public int Age;
    public int CompareTo(Student other)
    {
        return string.Compare(Name, other.Name);
    }
}
class Course : IComparable<Course>
{
    public int ID;
    public string Name;
    public int CompareTo(Course other)
    {
        return string.Compare(Name, other.Name);
    }
}
class StudentCourses
{
    public int StudentID;
    public int CourseID;
}


class Program
{


    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();
        List<StudentCourses> studentCourses = new List<StudentCourses>();


        string[] studentsNames = { "Osama", "Mohammad", "Laith", "Omar", "Ayman", "Tareq", "Alaa", "Abdullah", "Samer" };
        string[] coursesNames = { "DOS", "Micro", "PIC", "OS", "Arch", "GP", "IT", "Communication", "Signal", "Calculus" };

        Random random = new Random();

        for (int i=0; i < studentsNames.Length; i++)
        {
            Student student = new Student();
            student.Name = studentsNames[i];
            student.ID = i;
            student.Age = random.Next(6, 25);
            students.Add(student);

        }

        for (int i = 0; i < coursesNames.Length; i++)
        {
            Course course = new Course();
            course.Name = coursesNames[i];
            course.ID = 1000+i;
            courses.Add(course);

        }

        for (int i = 0; i < studentsNames.Length; i++)
        {
           for (int j = 0; j < coursesNames.Length; j++){
                int isRegistered = random.Next(0, 2);
                if (isRegistered == 1)
                {
                    StudentCourses studentCourse = new StudentCourses();
                    studentCourse.CourseID = j + 1000;
                    studentCourse.StudentID = i;
                    studentCourses.Add(studentCourse);

                }
            }
        }


        Console.WriteLine("Display the list of students sorted by their names in ascending order.");
        List<Student> ascendingOrder =
            (from student in students
             orderby student ascending
             select student).ToList();

        foreach (Student s in ascendingOrder){
            Console.WriteLine("Name: {0}, Age: {1}", s.Name, s.ID);

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
