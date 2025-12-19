using System.Collections.Generic;

namespace University;

public class Courses
{
    public string Name { get; set; }
    public Teachers? Teacher { get; set; }
    public List<Student> Students { get; set; }
    
    public Courses(string name)
    {
        Name = name;
        Students = new List<Student>();
    }
    
    public void AddStudent(Student student)
    {
        Students.Add(student);
    }
    
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }
    
    public virtual string GetInfo()
    {
        return $"Курс: {Name}, Преподаватель: {Teacher?.Name}, Студентов: {Students.Count}";
    }
}