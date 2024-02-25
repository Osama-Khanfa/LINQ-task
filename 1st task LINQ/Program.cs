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

        List<Student> ascendingOrder = students.OrderBy(student => student.Name).ToList();
        foreach (Student s in ascendingOrder){
            Console.WriteLine("Name: {0}, Age: {1}", s.Name, s.Age);

        }




        Console.WriteLine("______________________________________________________________________\n");

        Console.WriteLine("Display the names of students who are older than 20 years.");

        List<Student> greaterThan20 = students.Where(s => s.Age > 20).ToList();
        foreach (Student s in greaterThan20)
        {
            Console.WriteLine("Name: {0}, Age: {1}", s.Name, s.Age);

        }



        Console.WriteLine("______________________________________________________________________\n");

        Console.WriteLine("Calculate the average age of all students");

        double avg = students.Select(s => s.Age).Average();
        Console.WriteLine("The average age is: {0}", avg);



        Console.WriteLine("______________________________________________________________________\n");

        Console.WriteLine("Display the results of the join operation showing the StudentId, Name, CourseId, and CourseName for each matching pair");

        var queryResult = from StudentCourse in studentCourses
                          join student in students on StudentCourse.StudentID equals student.ID
                          join course in courses on StudentCourse.CourseID equals course.ID
                          select new
                          {
                              StudentID = StudentCourse.StudentID,
                              StudentName = student.Name,
                              CourseID = StudentCourse.CourseID,
                              CourseName = course.Name
                          };
        foreach(var result in queryResult)
        {
            Console.WriteLine("Student ID: {0}, Student Name: {1}, Course ID: {2}, Course Name: {3}", result.StudentID, result.StudentName, result.CourseID, result.CourseName);

        }

    }
}
