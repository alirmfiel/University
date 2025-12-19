using System;
namespace University;

public class Program
{
    static void Main()
    {
        var service = new CourseService();

        var teacher1 = new Teachers("Екатерина Станиславовна");
        var teacher2 = new Teachers("Николай Викторович");
        
        var student1 = new Student("Ремнева Алиса");
        var student2 = new Student("Хлупина Анастасия");

        var mathCourse = new CourseBuilder("Математика")
            .SetTeacher(teacher1)
            .BuildOffline("Аудитория 2304");

        var oopCourse = new CourseBuilder("Объектно-ориентированное программирование")
            .SetTeacher(teacher2)
            .BuildOnline("Zoom");

        service.AddCourse(mathCourse);
        service.AddCourse(oopCourse);

        mathCourse.AddStudent(student1);
        oopCourse.AddStudent(student2);
        
        Console.WriteLine("\nВсе курсы:");
        foreach (var course in service.GetAllCourses())
        {
            Console.WriteLine(course.GetInfo());
        }
        
        Console.WriteLine($"\nКурсы преподавателя {teacher1.Name}:");
        foreach (var course in service.GetTeacherCourses(teacher1))
        {
            Console.WriteLine($"- {course.Name}");
        }
        Console.WriteLine("\nУдаляем курс Математика");
        service.RemoveCourse(mathCourse);
        
        Console.WriteLine($"Осталось курсов: {service.GetAllCourses().Count}");
    }
}